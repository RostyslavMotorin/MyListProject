﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyList.Application.Common.Interfaces.Repositories;
using MyList.Application.Common.Dto;

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
        public async Task<IActionResult> Get(string id)
        {
            var res = await _gameRepository.GetByIdAsync(id);
            return Ok(res);
        }

        [Authorize]
        [HttpGet("AddToList")]
        public async Task<ActionResult> AddToList(string id)
        {
            await _gameRepository.AddToList(id);
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
    }
}
