using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyList.Application.Common.Interfaces;
using MyList.Domain.Common.Models;
using MyList.Domain.Common.Models.ContentModels;

namespace MyList.Data.Contexts
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>, IApplicationDBContext
    {
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<ApplicationRole> Roles { get; set; }
        public DbSet<Creators> Creators { get; set; }

        //collections
        public DbSet<Anime> Anime { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Serial> Serials { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Game> Games { get; set; }
      
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();

        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
