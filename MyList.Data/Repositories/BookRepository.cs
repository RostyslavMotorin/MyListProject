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
            var contextList = await _context.Films.ToListAsync();
            var itemsList = _mapper.Map<List<ItemDto>>(contextList);
            foreach (var item in itemsList)
            {
                if (item.Image == "")
                {
                    item.Image = "Resources/Images/nonAviableImage.png";
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

            foreach (var tag in modelDto?.Tags)
            {
                tags.Add((BookTag)tagsList?.Find(x => x.TagID == Guid.Parse(tag?.tagID)));
            }

            var item = new Book()
            {
                BookID = new Guid(),
                Name = modelDto.Name,
                Description = modelDto.Description,
                Tags = tags,
                PictureURL = modelDto.Picture
            };
            await _context.Books.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task AddToList(AddCollectionDto collectionDto)
        {
            var userId = _currentUserService.UserId;
            var item = await _context.Books.FindAsync(Guid.Parse(collectionDto.Id));
            item.UserStatus = collectionDto.Status;
            var user = await _context.Users.FindAsync(userId);
            user.Books.Add(item);
            await _context.SaveChangesAsync();
        }
    }
}
