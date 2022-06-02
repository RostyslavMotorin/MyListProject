using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyList.Data.Models;
using MyList.Data.Contexts;
using MyList.Domain.Interfaces;


namespace MyList.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseApiController
    {
        private readonly ApplicationContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ITokenService tokenService;

        public AccountController(ApplicationContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITokenService tokenService)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<UserToken>> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user == null)
                {
                    return Unauthorized();
                }

                var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                if (result.Succeeded)
                {
                    return new UserToken
                    {
                        Email = model.Email,
                        Token = tokenService.CreateToken(user),
                    };
                }
            }
            return Unauthorized(ModelState);
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ActionResult<UserToken>> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser { Email = model.Email, UserName = model.UserName, FirstName = model.FirstName};
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    ApplicationUser currentUSer = await context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                    await userManager.AddToRoleAsync(user, "user");
                    return new UserToken
                    {
                        Email = model.Email,
                        Token = tokenService.CreateToken(user),
                    };
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return BadRequest(ModelState);
        }
    }
}
