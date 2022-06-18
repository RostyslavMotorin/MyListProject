using Microsoft.EntityFrameworkCore;
using MyList.Application.Common.Dto;
using MyList.Application.Common.Interfaces;
using MyList.Application.Common.Interfaces.Repositories;
using MyList.Domain.Common.Models;
using MyList.Data.Contexts;

namespace MyList.Data.Repositories
{
    public class UserRepository : GenericRepository<ApplicationUser>, IUserRepository 
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context, ICurrentUserService currentUserService) : base(context)
        {
            _currentUserService = currentUserService;
            _context = context;
        }

        public override Task<IEnumerable<ApplicationUser>> GetBySearch(string search)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<ItemDto>> GetTop()
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> GetUserAsync()
        {
            var userId = _currentUserService.UserId;
            var result = await _context.Users
                .Include(x=>x.Games)
                .Include(x=>x.Films)
                .Include(x=>x.Serials)
                .Include(x=>x.Anime)
                .Include(x=>x.Books)
                .FirstOrDefaultAsync(x=>x.Id == userId);
            return result;
        }
    }
}
