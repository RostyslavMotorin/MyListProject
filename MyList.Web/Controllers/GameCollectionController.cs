using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyList.Application.Common.Interfaces.Repositories;
using MyList.Domain.Common.Models.ContentModels;
using MyList.Application.Common.Dto;

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

        [Authorize]
        [HttpPost("AddToList")]
        public async Task<ActionResult> AddToList(Game game)
        {
            // add item to user list
            return null;
        }

        [Authorize]
        [HttpGet("AddToListForId")]
        public async Task<ActionResult> AddToList(Guid id)
        {
            // add item to user list
            return null;
        }

        [Authorize]
        [HttpGet("Find")]
        public async Task<ActionResult> Find(string name)
        {
            // find some items
            return null;
        }

        [Authorize]
        [HttpPost("Create")]
        public async Task<ActionResult> Create(GameDto name)
        {
            // find some items
            return null;
        }
    }
}
