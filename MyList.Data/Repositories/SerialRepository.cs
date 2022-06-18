using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyList.Application.Common.Dto;
using MyList.Application.Common.Interfaces;
using MyList.Application.Common.Interfaces.Repositories;
using MyList.Data.Contexts;
using MyList.Domain.Common.Models.ContentModels;
using MyList.Domain.Common.Models.Tags;

namespace MyList.Data.Repositories
{
    public class SerialRepository : GenericRepository<Serial>, ISerialRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public SerialRepository(ApplicationDBContext context, IMapper mapper, ICurrentUserService currentUserService) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<List<SerialTag>> GetAllTags()
        {
            return await _context.SerialTags.ToListAsync();
        }

        public async Task<List<ItemDto>> GetAllItems()
        {
            var contextList = await _context.Serials.ToListAsync();
            var itemsList = _mapper.Map<List<ItemDto>>(contextList);
            foreach (var item in itemsList)
            {
                if (item.PictureURL == "")
                {
                    item.PictureURL = "Resources/Images/nonAviableImage.png";
                }
            }
            return itemsList;
        }
        public async Task<Serial> GetByIdAsync(string id)
        {
            var result = await _context.Serials.Include(x => x.Tags).FirstAsync(x => x.SerialID == Guid.Parse(id));

            foreach (var tag in result.Tags)
            {
                tag.Serials = new List<Serial>();
            }

            if (result.PictureURL == "")
            {
                result.PictureURL = "Resources/Images/nonAviableImage.png";
            }

            return result;
        }
        public async Task CreateASyncDto(SerialDto modelDto)
        {
            List<SerialTag> tags = new List<SerialTag>();
            var tagsList = await _context.SerialTags.ToListAsync();
            var userId = _currentUserService.UserId;
            var user = await _context.Users.FindAsync(userId);

            foreach (var tag in modelDto?.Tags)
            {
                tags.Add(tagsList?.Find(x => x.TagID == Guid.Parse(tag?.tagID)));
            }

            var item = new Serial()
            {
                SerialID = new Guid(),
                Name = modelDto.Name,
                Description = modelDto.Description,
                Tags = tags,
                PictureURL = modelDto.Picture
            };
            user.Serials.Add(item);
            await _context.Serials.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task AddToList(AddCollectionDto collectionDto)
        {
            var userId = _currentUserService.UserId;
            var user = await _context.Users.FindAsync(userId);
            var item = await _context.Serials.FindAsync(Guid.Parse(collectionDto.Id));

            if (user.Serials.Any(x => x.Name == item.Name))
            {
                item.UserStatus = collectionDto.Status;
                _context.Serials.Update(item);
                await _context.SaveChangesAsync();
                return;
            }

            Serial itemClone = new Serial()
            {
                UserStatus = collectionDto.Status,
                SerialID = new Guid(),
                Name = item.Name,
                Description = item.Description,
                Tags = item.Tags,
                CountEpisodes = item.CountEpisodes,
                RelizeDate = item.RelizeDate,
                Authors = item.Authors,
                GlobalScore = item.GlobalScore,
                GlobalStatus = item.GlobalStatus,
                PictureURL = item.PictureURL
            };
            user.Serials.Add(itemClone);
            await _context.SaveChangesAsync();
        }

        public override async Task<IEnumerable<Serial>> GetBySearch(string search)
        {
            var result = await _context.Serials
                .Where(x => EF.Functions.Like(x.Name.ToLower(), "%" + search.ToLower() + "%")).ToListAsync();
            return result;
        }

        public async override Task<IEnumerable<ItemDto>> GetTop()
        {
            var itemsList = _context.Serials.Take(12).Where(x => x.ApplicationUserId == null).OrderBy(x => x.GlobalScore).ToListAsync();
            var result = _mapper.Map<List<ItemDto>>(itemsList);
            foreach (var item in result)
            {
                if (item.PictureURL == "")
                {
                    item.PictureURL = "Resources/Images/nonAviableImage.png";
                }
            }
            return result;
        }
    }
}
