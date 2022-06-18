using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyList.Application.Common.Interfaces.Repositories;
using MyList.Application.Common.Dto;
using MyList.Domain.Common.Models.ContentModels;

namespace MyList.Web.Controllers
{
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
            var result = await _gameRepository.GetAllItems();
            return Ok(result);
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
        public async Task<IActionResult> Get(string id)
        {
            var res = await _gameRepository.GetByIdAsync(id);
            return Ok(res);
        }

        [Authorize]
        [HttpPost("AddToList")]
        public async Task<ActionResult> AddToList(AddCollectionDto collecitonDto)
        {
            await _gameRepository.AddToList(collecitonDto);
            return Ok();
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
        [HttpGet("GetSearch")]
        public async Task<ActionResult> GetSearch(string search)
        {
            var result = await _gameRepository.GetBySearch(search);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("Update")]
        public async Task<ActionResult> Update(Game item)
        {
            await _gameRepository.UpdateAsync(item);
            return Ok();
        }

        [Authorize]
        [HttpGet("GetTop")]
        public async Task<ActionResult> GetTop()
        {
            var result = await _gameRepository.GetTop();
            return Ok(result);
        }
    }
}
