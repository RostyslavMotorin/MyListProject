using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyList.Application.Common.Dto;
using MyList.Application.Common.Interfaces.Repositories;
using MyList.Domain.Common.Models.ContentModels;

namespace MyList.Web.Controllers
{
    public class AnimeCollectionController : BaseApiController, ICollectionController<AnimeDto>
    {
        private readonly IAnimeRepository _animeRepository;
        private readonly IMapper _mapper;
        public AnimeCollectionController(IAnimeRepository animeRepository, IMapper mapper)
        {
            _animeRepository = animeRepository;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _animeRepository.GetAllItems());
        }

        [Authorize]
        [HttpGet("GetAllTags")]
        public async Task<IActionResult> GetAllTags()
        {
            var result = _mapper.Map<List<TagDto>>(await _animeRepository.GetAllTags());
            return Ok(result);
        }

        [Authorize]
        [HttpGet("Get")]
        public async Task<IActionResult> Get(string id)
        {
            var res = await _animeRepository.GetByIdAsync(id);
            return Ok(res);
        }

        [Authorize]
        [HttpPost("AddToList")]
        public async Task<ActionResult> AddToList(AddCollectionDto collecitonDto)
        {
            await _animeRepository.AddToList(collecitonDto);
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
        public async Task<ActionResult> Create(AnimeDto model)
        {
            await _animeRepository.CreateASyncDto(model);
            return Ok();
        }

        [Authorize]
        [HttpGet("GetSearch")]
        public async Task<ActionResult> GetSearch(string search)
        {
            var result = await _animeRepository.GetBySearch(search);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("Update")]
        public async Task<ActionResult> Update(Anime item)
        {
            await _animeRepository.UpdateAsync(item);
            return Ok();
        }

        [Authorize]
        [HttpGet("GetTop")]
        public async Task<ActionResult> GetTop()
        {
            var result = await _animeRepository.GetTop();
            return Ok(result);
        }
    }
}
