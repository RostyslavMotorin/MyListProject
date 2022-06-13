using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyList.Application.Common.Interfaces.Repositories;
using MyList.Application.Common.Dto;

namespace MyList.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameCollectionController : BaseApiController, ICollectionController<GameDto>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;
        public GameCollectionController(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _gameRepository.GetAllItems());
        }

        [Authorize]
        [HttpGet("GetAllTags")]
        public async Task<IActionResult> GetAllTags()
        {
            var result = _mapper.Map<List<TagDto>>(await _gameRepository.GetAllTags());
            return Ok(result);
        }

        [Authorize]
        [HttpGet("Get")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _gameRepository.GetByIdAsync(id));
        }

        [Authorize]
        [HttpPost("AddToList")]
        public async Task<ActionResult> AddToList(GameDto game)
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
        public async Task<ActionResult> Create(GameDto model)
        {
            await _gameRepository.CreateASyncDto(model);
            return Ok();
        }

        [Authorize]
        [HttpPost("test")]
        public async Task<ActionResult> Test(IFormFile model)
        {
            return Ok();
        }
    }
}
