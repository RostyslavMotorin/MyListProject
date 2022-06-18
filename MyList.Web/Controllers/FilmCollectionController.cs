using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyList.Application.Common.Dto;
using MyList.Application.Common.Interfaces.Repositories;
using MyList.Domain.Common.Models.ContentModels;

namespace MyList.Web.Controllers
{
    public class FilmCollectionController : BaseApiController, ICollectionController<FilmDto>
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;
        public FilmCollectionController(IFilmRepository filmRepository, IMapper mapper)
        {
            _filmRepository = filmRepository;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _filmRepository.GetAllItems());
        }

        [Authorize]
        [HttpGet("GetAllTags")]
        public async Task<IActionResult> GetAllTags()
        {
            var result = _mapper.Map<List<TagDto>>(await _filmRepository.GetAllTags());
            return Ok(result);
        }

        [Authorize]
        [HttpGet("Get")]
        public async Task<IActionResult> Get(string id)
        {
            var res = await _filmRepository.GetByIdAsync(id);
            return Ok(res);
        }

        [Authorize]
        [HttpPost("AddToList")]
        public async Task<ActionResult> AddToList(AddCollectionDto collecitonDto)
        {
            await _filmRepository.AddToList(collecitonDto);
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
        public async Task<ActionResult> Create(FilmDto model)
        {
            await _filmRepository.CreateASyncDto(model);
            return Ok();
        }

        [Authorize]
        [HttpGet("GetSearch")]
        public async Task<ActionResult> GetSearch(string search)
        {
            var result = await _filmRepository.GetBySearch(search);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("Update")]
        public async Task<ActionResult> Update(Film item)
        {
            await _filmRepository.UpdateAsync(item);
            return Ok();
        }
    }
}
