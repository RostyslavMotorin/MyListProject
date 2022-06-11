using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyList.Application.Common.Dto;
using MyList.Application.Common.Interfaces;
using MyList.Domain.Common.Models;


namespace MyList.Web.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IAuthorizeService _authorizeService;
        public AccountController(IAuthorizeService authorizeService)
        {
            _authorizeService = authorizeService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<IdentityLoginDto>> Login(LoginModel model)
        {
            var response = await _authorizeService.LogInUser(model);

            if (response.Errors == null)
            {
                return response;
            }
            else
            {
                return StatusCode((int)HttpStatusCode.Unauthorized, new IdentityLoginDto { Errors = response.Errors });
            }
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ActionResult<IdentityLoginDto>> Register(RegisterModel model)
        {
            var response = await _authorizeService.RegisterUser(model);

            if (response.Errors == null)
            {
                return response;
            }
            else
            {
                return StatusCode((int)HttpStatusCode.NotAcceptable, new IdentityLoginDto { Errors = response.Errors });
            }
        }
    }
}
