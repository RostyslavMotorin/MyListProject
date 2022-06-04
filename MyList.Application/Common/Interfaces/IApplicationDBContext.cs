using Microsoft.EntityFrameworkCore;
using MyList.Domain.Common.Models;
using MyList.Domain.Common.Models.ContentModels;

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
        Task<int> SaveChangesAsync();
    }
}
