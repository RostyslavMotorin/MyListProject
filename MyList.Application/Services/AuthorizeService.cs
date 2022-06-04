using Microsoft.AspNetCore.Identity;
using MyList.Application.Common.Interfaces;
using MyList.Domain.Common.Models;
using MyList.Domain.Interfaces;

namespace MyList.Application.Services
{
    public class AuthorizeService : IAuthorizeService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AuthorizeService(UserManager<ApplicationUser> userManager,
            ITokenService tokenService,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }

        public async Task<UserToken> RegisterUser(RegisterModel model)
        {
            if (await _userManager.FindByNameAsync(model.UserName) != null
                || await _userManager.FindByEmailAsync(model.Email) != null)
            {
                return null;
            }

            ApplicationUser user = new ApplicationUser { Email = model.Email, UserName = model.UserName, FirstName = model.FirstName, PhotoURL = "", Gender = "" };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "user");

                return new UserToken
                {
                    Email = model.Email,
                    Token = _tokenService.CreateToken(user),
                };
            }
            //else
            //{
            //    foreach (var error in result.Errors)
            //    {
            //        ModelState.AddModelError(string.Empty, error.Description);
            //    }

            //    return result;
            //}
            return null;
        }

        public async Task<UserToken> LogInUser(LoginModel model)
        {

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return null;
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (result.Succeeded)
            {
                return new UserToken
                {
                    Email = model.Email,
                    Token = _tokenService.CreateToken(user),
                };
            }

            return null;
        }
    }
}
