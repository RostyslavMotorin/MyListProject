using Microsoft.EntityFrameworkCore;
using MyList.Domain.Common.Models;
using MyList.Domain.Common.Models.ContentModels;
using MyList.Domain.Common.Models.Tags;

namespace MyList.Application.Common.Interfaces
{
    public interface IApplicationDBContext 
    {
        DbSet<ApplicationUser> Users { get; set; }
        DbSet<ApplicationRole> Roles { get; set; }
        DbSet<Creators> Creators { get; set; }

        //collections
        DbSet<Anime> Anime { get; set; }
        DbSet<Film> Films { get; set; }
        DbSet<Serial> Serials { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<Game> Games { get; set; }

        //tags
        public DbSet<GameTag> GameTags { get; set; }
        public DbSet<AnimeTag> AnimeTags { get; set; }
        public DbSet<FilmTag> FilmTags { get; set; }
        public DbSet<SerialTag> SerialTags { get; set; }
        public DbSet<BookTag> BookTags { get; set; }
        Task<int> SaveChangesAsync();
    }
}
