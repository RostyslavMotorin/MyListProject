using MyList.Data.Contexts;
using MyList.Domain.Common.Models.Tags;

namespace MyList.Data.Services
{
    public class TagInitializerService
    {
        private readonly ApplicationDBContext _context;
        public TagInitializerService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task InitTags()
        {
            List<GameTag> gameTagList = new List<GameTag>()
            {
                new GameTag { TagID = new Guid(), Name = "PC" },
                new GameTag { TagID = new Guid(), Name = "Console" },
                new GameTag { TagID = new Guid(), Name = "Mobile" },
                new GameTag { TagID = new Guid(), Name = "Nintendo Switch" },
                new GameTag { TagID = new Guid(), Name = "Race" },
                new GameTag { TagID = new Guid(), Name = "Fighter" },
                new GameTag { TagID = new Guid(), Name = "RPG" },
                new GameTag { TagID = new Guid(), Name = "Arcade" },
                new GameTag { TagID = new Guid(), Name = "Shooter" },
            };

            _context.GameTags.AddRange(gameTagList);
            await _context.SaveChangesAsync();
        }
    }
}
