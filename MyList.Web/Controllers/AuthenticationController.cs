using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyList.Application.Common.Interfaces;
using MyList.Domain.Common.Models;
using MyList.Data.Contexts;
using MyList.Domain.Interfaces;


namespace MyList.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseApiController
    {
        private readonly IAuthorizeService _authorizeService;

        public AccountController(IAuthorizeService authorizeService)
        {
            _authorizeService = authorizeService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<UserToken>> Login(LoginModel model)
        {
            var response = await _authorizeService.LogInUser(model);

            if (response != null)
            {
                return response;
            }
            else
            {
                return StatusCode((int)HttpStatusCode.NotAcceptable);
            }
            //if (ModelState.IsValid)
            //{
            //    var user = await _userManager.FindByEmailAsync(model.Email);

            //    if (user == null)
            //    {
            //        return Unauthorized();
            //    }

            //    var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            //    if (result.Succeeded)
            //    {
            //        return new UserToken
            //        {
            //            Email = model.Email,
            //            Token = _tokenService.CreateToken(user),
            //        };
            //    }
            //}
            //return Unauthorized(ModelState);
        }

        //[AllowAnonymous]
        //[HttpGet("Test")]
        //public async Task<string> Test()
        //{
        //    await RoleInitializerService.InitializeAsync(userManager, roleManager);
        //    return "ok";
        //}

        //[AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ActionResult<UserToken>> Register(RegisterModel model)
        {
            var response = await _authorizeService.RegisterUser(model);

            if (response != null)
            {
                return response;
            }
            else
            {
                return StatusCode((int)HttpStatusCode.NotAcceptable);
            }
            //if (ModelState.IsValid)
            //{
            //if (await Check(model))
            //{
            //    return StatusCode((int)HttpStatusCode.NotAcceptable);
            //}

            //    ApplicationUser user = new ApplicationUser { Email = model.Email, UserName = model.UserName, FirstName = model.FirstName, PhotoURL = "", Gender = ""};
            //    var result = await _userManager.CreateAsync(user, model.Password);
            //    if (result.Succeeded)
            //    {
            //        ApplicationUser currentUSer = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
            //        await _userManager.AddToRoleAsync(user, "user");

            //        return new UserToken
            //        {
            //            Email = model.Email,
            //            Token = _tokenService.CreateToken(user),
            //        };
            //    }
            //    else
            //    {
            //        foreach (var error in result.Errors)
            //        {
            //            ModelState.AddModelError(string.Empty, error.Description);
            //        }
            //    }
            //}
            //return BadRequest(ModelState);
        }
       
    }
}
