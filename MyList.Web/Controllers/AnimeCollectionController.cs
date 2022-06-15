using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyList.Application.Common.Dto;
using MyList.Application.Common.Interfaces.Repositories;

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
        [HttpGet("AddToList")]
        public async Task<ActionResult> AddToList(string id)
        {
            await _animeRepository.AddToList(id);
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
    }
}
