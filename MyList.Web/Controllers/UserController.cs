using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyList.Application.Common.Interfaces.Repositories;

namespace MyList.Web.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("Get")]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var result = await _userRepository.GetUserAsync();
            return Ok(result);
        }
    }
}
