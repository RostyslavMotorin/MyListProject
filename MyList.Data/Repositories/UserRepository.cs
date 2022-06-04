using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyList.Application.Common.Interfaces;
using MyList.Application.Common.Interfaces.Repositories;
using MyList.Domain.Common.Models;
using MyList.Data.Contexts;
using MyList.Domain.Interfaces;

namespace MyList.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        //public async Task<ApplicationUser> GetForEmail(string email)
        //{
        //    return await _userManager.FindByEmailAsync(email);
        //}

        //public async Task<ApplicationUser> GetForUserName(string userName)
        //{
        //    return await _userManager.FindByNameAsync(userName);
        //}
    }
}
