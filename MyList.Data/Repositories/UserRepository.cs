using MyList.Application.Common.Interfaces.Repositories;
using MyList.Domain.Common.Models;
using MyList.Data.Contexts;

namespace MyList.Data.Repositories
{
    public class UserRepository : GenericRepository<ApplicationUser>, IUserRepository 
    {
        public UserRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
