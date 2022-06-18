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

            List<FilmTag> filmTagList = new List<FilmTag>()
            {
                new FilmTag { TagID = new Guid(), Name = "Horor" },
                new FilmTag { TagID = new Guid(), Name = "Action" },
                new FilmTag { TagID = new Guid(), Name = "Drama" },
                new FilmTag { TagID = new Guid(), Name = "Camedy" },
                new FilmTag { TagID = new Guid(), Name = "Triler" },
                new FilmTag { TagID = new Guid(), Name = "Fantasy" },
                new FilmTag { TagID = new Guid(), Name = "SkyFi" },
            };

            List<BookTag> bookTagList = new List<BookTag>()
            {
                new BookTag { TagID = new Guid(), Name = "Horor" },
                new BookTag { TagID = new Guid(), Name = "Action" },
                new BookTag { TagID = new Guid(), Name = "Drama" },
                new BookTag { TagID = new Guid(), Name = "Camedy" },
                new BookTag { TagID = new Guid(), Name = "Triler" },
                new BookTag { TagID = new Guid(), Name = "Fantasy" },
                new BookTag { TagID = new Guid(), Name = "SkyFi" },
            };

            List<SerialTag> serialTagList = new List<SerialTag>()
            {
                new SerialTag { TagID = new Guid(), Name = "Horor" },
                new SerialTag { TagID = new Guid(), Name = "Action" },
                new SerialTag { TagID = new Guid(), Name = "Drama" },
                new SerialTag { TagID = new Guid(), Name = "Camedy" },
                new SerialTag { TagID = new Guid(), Name = "Triler" },
                new SerialTag { TagID = new Guid(), Name = "Fantasy" },
                new SerialTag { TagID = new Guid(), Name = "SkyFi" },
            };

            List<AnimeTag> animeTagList = new List<AnimeTag>()
            {
                new AnimeTag { TagID = new Guid(), Name = "Horor" },
                new AnimeTag { TagID = new Guid(), Name = "Action" },
                new AnimeTag { TagID = new Guid(), Name = "Drama" },
                new AnimeTag { TagID = new Guid(), Name = "Camedy" },
                new AnimeTag { TagID = new Guid(), Name = "Triler" },
                new AnimeTag { TagID = new Guid(), Name = "Fantasy" },
                new AnimeTag { TagID = new Guid(), Name = "SkyFi" },
            };

            _context.GameTags.AddRange(gameTagList);
            _context.AnimeTags.AddRange(animeTagList);
            _context.SerialTags.AddRange(serialTagList);
            _context.BookTags.AddRange(bookTagList);
            _context.FilmTags.AddRange(filmTagList);
            await _context.SaveChangesAsync();
        }
    }
}
