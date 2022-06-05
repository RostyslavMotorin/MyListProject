using Microsoft.AspNetCore.Identity;
using MyList.Application.Common.Dto;
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

        public async Task<IdentityLoginDto> RegisterUser(RegisterModel model)
        {
            ApplicationUser user = new ApplicationUser { Email = model.Email, UserName = model.UserName, FirstName = model.FirstName, PhotoURL = "", Gender = "" };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "user");
                return new IdentityLoginDto
                {
                    Token = _tokenService.CreateToken(user),
                };
            }

            return new IdentityLoginDto() { Errors = result.Errors.Select(x => x.Description).ToArray() };
        }

        public async Task<IdentityLoginDto> LogInUser(LoginModel model)
        {

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return new IdentityLoginDto() { Errors = new[] { "User with such credentials don't exist" } };
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (result.Succeeded)
            {
                return new IdentityLoginDto
                {
                    Token = _tokenService.CreateToken(user),
                };
            }
            
            return new IdentityLoginDto() { Errors = new []{ "Login is Failed" } };
        }
    }
}
