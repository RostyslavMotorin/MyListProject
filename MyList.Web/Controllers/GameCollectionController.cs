using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyList.Application.Common.Interfaces.Repositories;

namespace MyList.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameCollectionController : BaseApiController
    {
        private readonly IGameRepository _gameRepository;
        public GameCollectionController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        [Authorize]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _gameRepository.GetAllAsync());
        }

        [Authorize]
        [HttpGet("Get")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _gameRepository.GetByIdAsync(id));
        }

    }
}
