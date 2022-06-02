using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyList.Data.Models;

namespace MyList.Data.Contexts
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();

        }
    }
}
