using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyList.Data.Services;
using MyList.Domain.Common.Models;
using MyList.Domain.Services;

namespace MyList.Web.Controllers
{
    public class RoleController : BaseApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly TagInitializerService _tagInitializerService;
        public RoleController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, TagInitializerService tagInitializerService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _tagInitializerService = tagInitializerService;
        }

        //[HttpGet("RoleInit")]
        //[AllowAnonymous]
        //public async Task<ActionResult> RoleInit()
        //{
        //    try
        //    {
        //        await RoleInitializerService.InitializeAsync(_userManager,_roleManager);
        //        return Ok("Complete successful");
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e);
        //    }
        //}

        //[HttpGet("TagInit")]
        //[AllowAnonymous]
        //public async Task<ActionResult> TagInit()
        //{
        //    try
        //    {
        //        await _tagInitializerService.InitTags();
        //        return Ok("Complete successful");
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e);
        //    }
        //}

    }
}
