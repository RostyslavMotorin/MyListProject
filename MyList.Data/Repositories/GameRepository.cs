using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using MyList.Application.Common.Dto;
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
        public GameRepository(ApplicationDBContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GameTag>> GetAllTags()
        {
            return await _context.GameTags.ToListAsync();
        }

        public async Task<List<ItemDto>> GetAllItems()
        {
            var gameList = await _context.Games.ToListAsync();
            var itemsList = _mapper.Map<List<ItemDto>>(gameList);
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

            var game = new Game()
            {
                GameID = new Guid(),
                Name = modelDto.Name,
                Description = modelDto.Description,
                GameStudio = modelDto.GameStudio,
                Tags = tags,
                PictureURL = modelDto.Picture
            };
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
        }
    }
}
