using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyList.Domain.Common.Models;
using MyList.Domain.Services;

namespace MyList.Web.Controllers
{
    public class RoleController : BaseApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public RoleController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet("RoleInit")]
        [AllowAnonymous]
        public async Task<ActionResult> RoleInit()
        {
            try
            {
                await RoleInitializerService.InitializeAsync(_userManager,_roleManager);
                return Ok("Complete successful");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}
