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
    public class FilmRepository :  GenericRepository<Film>, IFilmRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public FilmRepository(ApplicationDBContext context, IMapper mapper, ICurrentUserService currentUserService) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<List<FilmTag>> GetAllTags()
        {
            return await _context.FilmTags.ToListAsync();
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
        public async Task<Film> GetByIdAsync(string id)
        {
            var result = await _context.Films.Include(x => x.Tags).FirstAsync(x => x.FilmID == Guid.Parse(id));

            foreach (var tag in result.Tags)
            {
                tag.Films = new List<Film>();
            }

            if (result.PictureURL == "")
            {
                result.PictureURL = "Resources/Images/nonAviableImage.png";
            }

            return result;
        }
        public async Task CreateASyncDto(FilmDto modelDto)
        {
            List<FilmTag> tags = new List<FilmTag>();
            var tagsList = await _context.FilmTags.ToListAsync();

            foreach (var tag in modelDto?.Tags)
            {
                tags.Add(tagsList?.Find(x => x.TagID == Guid.Parse(tag?.tagID)));
            }

            var item = new Film()
            {
                FilmID = new Guid(),
                Name = modelDto.Name,
                Description = modelDto.Description,
                Tags = tags,
                PictureURL = modelDto.Picture
            };
            await _context.Films.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task AddToList(AddCollectionDto collectionDto)
        {
            var userId = _currentUserService.UserId;
            var item = await _context.Films.FindAsync(Guid.Parse(collectionDto.Id));
            item.UserStatus = collectionDto.Status;
            var user = await _context.Users.FindAsync(userId);
            user.Films.Add(item);
            await _context.SaveChangesAsync();
        }
    }
}
