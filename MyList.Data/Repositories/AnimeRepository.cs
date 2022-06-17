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
    public class AnimeRepository : GenericRepository<Anime>, IAnimeRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public AnimeRepository(ApplicationDBContext context, IMapper mapper, ICurrentUserService currentUserService) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<List<AnimeTag>> GetAllTags()
        {
            return await _context.AnimeTags.ToListAsync();
        }

        public async Task<List<ItemDto>> GetAllItems()
        {
            var contextList = await _context.Anime.ToListAsync();
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
        public async Task<Anime> GetByIdAsync(string id)
        {
            var result = await _context.Anime.Include(x => x.Tags).FirstAsync(x => x.AnimeID == Guid.Parse(id));

            foreach (var tag in result.Tags)
            {
                tag.Anime = new List<Anime>();
            }

            if (result.PictureURL == "")
            {
                result.PictureURL = "Resources/Images/nonAviableImage.png";
            }

            return result;
        }
        public async Task CreateASyncDto(AnimeDto modelDto)
        {
            List<AnimeTag> tags = new List<AnimeTag>();
            var tagsList = await _context.AnimeTags.ToListAsync();
            var userId = _currentUserService.UserId;
            var user = await _context.Users.FindAsync(userId);

            foreach (var tag in modelDto?.Tags)
            {
                tags.Add(tagsList?.Find(x => x.TagID == Guid.Parse(tag?.tagID)));
            }

            var item = new Anime()
            {
                AnimeID = new Guid(),
                Name = modelDto.Name,
                Description = modelDto.Description,
                Tags = tags,
                PictureURL = modelDto.Picture
            };

            user.Anime.Add(item);
            await _context.Anime.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task AddToList(AddCollectionDto collectionDto)
        {
            var userId = _currentUserService.UserId;
            var user = await _context.Users.FindAsync(userId);
            var item = await _context.Anime.FindAsync(Guid.Parse(collectionDto.Id));

            if (user.Anime.Any(x => x.Name == item.Name))
            {
                item.UserStatus = collectionDto.Status;
                _context.Anime.Update(item);
                await _context.SaveChangesAsync();
                return;
            }

            Anime itemClone = new Anime()
            {
                UserStatus = collectionDto.Status,
                AnimeID = new Guid(),
                Name = item.Name,
                Description = item.Description,
                Tags = item.Tags,
                CountEpisodes = item.CountEpisodes,
                RelizeDate = item.RelizeDate,
                Authors = item.Authors,
                GlobalScore = item.GlobalScore,
                GlobalStatus = item.GlobalStatus,
                PictureURL = item.PictureURL
            };
            
            user.Anime.Add(itemClone);
            await _context.SaveChangesAsync();
        }

        public override async Task<IEnumerable<Anime>> GetBySearch(string search)
        {
            var result = await _context.Anime
                .Where(x => EF.Functions.Like(x.Name.ToLower(), "%" + search.ToLower() + "%")).ToListAsync();
            return result;
        }
    }
}
