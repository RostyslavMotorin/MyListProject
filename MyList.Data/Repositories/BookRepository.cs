using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyList.Application.Common.Dto;
using MyList.Application.Common.Interfaces;
using MyList.Application.Common.Interfaces.Repositories;
using MyList.Data.Contexts;
using MyList.Domain.Common.Models.ContentModels;
using MyList.Domain.Common.Models.Tags;

namespace MyList.Data.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public BookRepository(ApplicationDBContext context, IMapper mapper, ICurrentUserService currentUserService) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<List<BookTag>> GetAllTags()
        {
            return await _context.BookTags.ToListAsync();
        }

        public async Task<List<ItemDto>> GetAllItems()
        {
            var contextList = await _context.Films.Where(x => x.ApplicationUserId == null).ToListAsync();
            var itemsList = _mapper.Map<List<ItemDto>>(contextList);
            foreach (var item in itemsList)
            {
                if (item.PictureURL == "")
                {
                    item.PictureURL = "Resources/Images/nonAviableImage.png";
                }
            }
            return itemsList;
        }
        public async Task<Book> GetByIdAsync(string id)
        {
            var result = await _context.Books.Include(x => x.Tags).FirstAsync(x => x.BookID == Guid.Parse(id));

            foreach (var tag in result.Tags)
            {
                tag.Books = new List<Book>();
            }

            if (result.PictureURL == "")
            {
                result.PictureURL = "Resources/Images/nonAviableImage.png";
            }

            return result;
        }
        public async Task CreateASyncDto(BookDto modelDto)
        {
            List<BookTag> tags = new List<BookTag>();
            var tagsList = await _context.BookTags.ToListAsync();
            var userId = _currentUserService.UserId;
            var user = await _context.Users.FindAsync(userId);

            foreach (var tag in modelDto?.Tags)
            {
                tags.Add((BookTag)tagsList?.Find(x => x.TagID == Guid.Parse(tag?.tagID)));
            }

            var item = new Book()
            {
                BookID = new Guid(),
                GlobalScore = modelDto.GlobalScore,
                Name = modelDto.Name,
                Description = modelDto.Description,
                Tags = tags,
                PictureURL = modelDto.Picture
            };

            user.Books.Add(item);
            await _context.Books.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task AddToList(AddCollectionDto collectionDto)
        {
            var userId = _currentUserService.UserId;
            var user = await _context.Users.FindAsync(userId);
            var item = await _context.Books.FindAsync(Guid.Parse(collectionDto.Id));
            
            if (user.Books.Any(x => x.Name == item.Name))
            {
                item.UserStatus = collectionDto.Status;
                _context.Books.Update(item);
                await _context.SaveChangesAsync();
                return;
            }

            Book itemClone = new Book()
            {
                UserStatus = collectionDto.Status,
                BookID = new Guid(),
                Name = item.Name,
                Description = item.Description,
                Tags = item.Tags,
                BookSeries = item.BookSeries,
                Authors = item.Authors,
                RelizeDate = item.RelizeDate,
                GlobalScore = item.GlobalScore,
                GlobalStatus = item.GlobalStatus,
                PictureURL = item.PictureURL
            };
            user.Books.Add(itemClone);
            await _context.SaveChangesAsync();
        }

        public override async Task<IEnumerable<Book>> GetBySearch(string search)
        {
            var result = await _context.Books
                .Where(x => EF.Functions.Like(x.Name.ToLower(), "%" + search.ToLower() + "%")).ToListAsync();
            return result;
        }
        public async override Task<IEnumerable<ItemDto>> GetTop()
        {
            var itemsList = await _context.Books.Take(5).Where(x => x.ApplicationUserId == null).OrderByDescending(x => x.GlobalScore).ToListAsync();
            var result = _mapper.Map<List<ItemDto>>(itemsList);
            foreach (var item in result)
            {
                if (item.PictureURL == "")
                {
                    item.PictureURL = "Resources/Images/nonAviableImage.png";
                }
            }
            return result;
        }
    }
}
