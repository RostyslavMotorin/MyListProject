using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyList.Application.Common.Dto;
using MyList.Application.Common.Interfaces.Repositories;

namespace MyList.Web.Controllers
{
    public class BookCollectionController : BaseApiController, ICollectionController<BookDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookCollectionController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _bookRepository.GetAllItems());
        }

        [Authorize]
        [HttpGet("GetAllTags")]
        public async Task<IActionResult> GetAllTags()
        {
            var result = _mapper.Map<List<TagDto>>(await _bookRepository.GetAllTags());
            return Ok(result);
        }

        [Authorize]
        [HttpGet("Get")]
        public async Task<IActionResult> Get(string id)
        {
            var res = await _bookRepository.GetByIdAsync(id);
            return Ok(res);
        }

        [Authorize]
        [HttpPost("AddToList")]
        public async Task<ActionResult> AddToList(AddCollectionDto collecitonDto)
        {
            await _bookRepository.AddToList(collecitonDto);
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
        public async Task<ActionResult> Create(BookDto model)
        {
            await _bookRepository.CreateASyncDto(model);
            return Ok();
        }
    }
}
