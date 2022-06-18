using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyList.Application.Common.Dto;
using MyList.Application.Common.Interfaces.Repositories;
using MyList.Domain.Common.Models.ContentModels;

namespace MyList.Web.Controllers
{
    public class SerialCollectionController : BaseApiController, ICollectionController<SerialDto>
    {
        private readonly ISerialRepository _serialRepository;
        private readonly IMapper _mapper;
        public SerialCollectionController(ISerialRepository serialRepository, IMapper mapper)
        {
            _serialRepository = serialRepository;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("GetAll")] 
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _serialRepository.GetAllItems());
        }

        [Authorize]
        [HttpGet("GetAllTags")]
        public async Task<IActionResult> GetAllTags()
        {
            var result = _mapper.Map<List<TagDto>>(await _serialRepository.GetAllTags());
            return Ok(result);
        }

        [Authorize]
        [HttpGet("Get")]
        public async Task<IActionResult> Get(string id)
        {
            var res = await _serialRepository.GetByIdAsync(id);
            return Ok(res);
        }

        [Authorize]
        [HttpPost("AddToList")]
        public async Task<ActionResult> AddToList(AddCollectionDto collecitonDto)
        {
            await _serialRepository.AddToList(collecitonDto);
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
        public async Task<ActionResult> Create(SerialDto model)
        {
            await _serialRepository.CreateASyncDto(model);
            return Ok();
        }

        [Authorize]
        [HttpGet("GetSearch")]
        public async Task<ActionResult> GetSearch(string search)
        {
            var result = await _serialRepository.GetBySearch(search);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("Update")]
        public async Task<ActionResult> Update(Serial item)
        {
            await _serialRepository.UpdateAsync(item);
            return Ok();
        }

        [Authorize]
        [HttpGet("GetTop")]
        public async Task<ActionResult> GetTop()
        {
            var result = await _serialRepository.GetTop();
            return Ok(result);
        }
    }
}
