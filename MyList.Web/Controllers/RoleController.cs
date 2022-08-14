using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyList.Data.API;
using MyList.Data.Services;
using MyList.Domain.Common.Models;
using MyList.Domain.Services;
using MyList.Web.Services;

namespace MyList.Web.Controllers
{
    public class RoleController : BaseApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly TagInitializerService _tagInitializerService;
        private readonly GoogleBooksApi _Bapi;
        private readonly KitsuApi _Aapi;
        private readonly TMDbApi _Mapi;
        private readonly IGDBApi _Gapi;

        private readonly SearchService _search;
        public RoleController(SearchService search, IMapper mapper, IConfiguration configuration, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, TagInitializerService tagInitializerService)
        {
            _search = search;
            _Bapi = new GoogleBooksApi(configuration, mapper);
            _Aapi = new KitsuApi(configuration, mapper);
            _Mapi = new TMDbApi(mapper);
            _Gapi = new IGDBApi();
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

        [HttpGet("Test")]
        [AllowAnonymous]
        public async Task<ActionResult> Test()
        {
            var res = await _search.SearchSerial("Green");
            return Ok(res);
        }
    }
}
