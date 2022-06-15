﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyList.Application.Common.Dto;
using MyList.Application.Common.Interfaces;
using MyList.Application.Common.Interfaces.Repositories;
using MyList.Data.Contexts;
using MyList.Domain.Common.Models.ContentModels;
using MyList.Domain.Common.Models.Tags;

namespace MyList.Data.Repositories
{
    public class AnimeRepository : GenericRepository<Anime>, IAnimeRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public AnimeRepository(ApplicationDBContext context, IMapper mapper, ICurrentUserService currentUserService) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<List<AnimeTag>> GetAllTags()
        {
            return await _context.AnimeTags.ToListAsync();
        }

        public async Task<List<ItemDto>> GetAllItems()
        {
            var contextList = await _context.Anime.ToListAsync();
            var itemsList = _mapper.Map<List<ItemDto>>(contextList);
            foreach (var item in itemsList)
            {
                if (item.Image == "")
                {
                    item.Image = "Resources/Images/nonAviableImage.png";
                }
            }
            return itemsList;
        }
        public async Task<Anime> GetByIdAsync(string id)
        {
            var result = await _context.Anime.Include(x => x.Tags).FirstAsync(x => x.AnimeID == Guid.Parse(id));

            foreach (var tag in result.Tags)
            {
                tag.Anime = new List<Anime>();
            }

            if (result.PictureURL == "")
            {
                result.PictureURL = "Resources/Images/nonAviableImage.png";
            }

            return result;
        }
        public async Task CreateASyncDto(AnimeDto modelDto)
        {
            List<AnimeTag> tags = new List<AnimeTag>();
            var tagsList = await _context.AnimeTags.ToListAsync();

            foreach (var tag in modelDto?.Tags)
            {
                tags.Add(tagsList?.Find(x => x.TagID == Guid.Parse(tag?.tagID)));
            }

            var item = new Anime()
            {
                AnimeID = new Guid(),
                Name = modelDto.Name,
                Description = modelDto.Description,
                Tags = tags,
                PictureURL = modelDto.Picture
            };
            await _context.Anime.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task AddToList(string id)
        {
            var userId = _currentUserService.UserId;
            var item = await _context.Anime.FindAsync(Guid.Parse(id));
            var user = await _context.Users.FindAsync(Guid.Parse(userId.ToString()));
            user.Anime.Add(item);
            await _context.SaveChangesAsync();
        }
    }
}
