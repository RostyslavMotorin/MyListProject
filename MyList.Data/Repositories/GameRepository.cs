using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using MyList.Application.Common.Dto;
using MyList.Application.Common.Interfaces;
using MyList.Application.Common.Interfaces.Repositories;
using MyList.Data.Contexts;
using MyList.Domain.Common.Models.ContentModels;
using MyList.Domain.Common.Models.Tags;

namespace MyList.Data.Repositories
{
    internal class GameRepository : GenericRepository<Game>, IGameRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public GameRepository(ApplicationDBContext context, IMapper mapper, ICurrentUserService currentUserService) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<List<GameTag>> GetAllTags()
        {
            return await _context.GameTags.ToListAsync();
        }

        public async Task<List<ItemDto>> GetAllItems()
        {
            var contextList = await _context.Games.ToListAsync();
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
        public async Task<Game> GetByIdAsync(string id)
        {
            var result = await _context.Games.Include(x => x.Tags).FirstAsync(x => x.GameID == Guid.Parse(id));

            foreach (var tag in result.Tags)
            {
                tag.Games = new List<Game>();
            }

            if (result.PictureURL == "")
            {
                result.PictureURL = "Resources/Images/nonAviableImage.png";
            }

            return result;
        }
        public async Task CreateASyncDto(GameDto modelDto)
        {
            List<GameTag> tags = new List<GameTag>();
            var tagsList = await _context.GameTags.ToListAsync();

            foreach (var tag in modelDto.Tags)
            {
                tags.Add(tagsList.Find(x => x.TagID == Guid.Parse(tag.tagID)));
            }

            var item = new Game()
            {
                GameID = new Guid(),
                Name = modelDto.Name,
                Description = modelDto.Description,
                GameStudio = modelDto.GameStudio,
                Tags = tags,
                PictureURL = modelDto.Picture
            };
            await _context.Games.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task AddToList(AddCollectionDto collectionDto)
        {
            var userId = _currentUserService.UserId;
            var user = await _context.Users.FindAsync(userId);
            var item = await _context.Games.FindAsync(Guid.Parse(collectionDto.Id));

            if (user.Games.Any(x => x.Name == item.Name))
            {
                return;
            }

            if (item != null)
            {
                Game itemClone = new Game()
                {
                    UserStatus = collectionDto.Status,
                    GameID = new Guid(),
                    Name = item.Name,
                    Description = item.Description,
                    GameStudio = item.GameStudio,
                    Tags = item.Tags,
                    RelizeDate = item.RelizeDate,
                    GlobalScore = item.GlobalScore,
                    GlobalStatus = item.GlobalStatus,
                    PictureURL = item.PictureURL
                };

                user.Games.Add(itemClone);
                await _context.SaveChangesAsync();
            }
        }
    }
}
