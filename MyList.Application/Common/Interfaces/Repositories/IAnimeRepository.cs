using MyList.Application.Common.Dto;
using MyList.Domain.Common.Models.ContentModels;
using MyList.Domain.Common.Models.Tags;

namespace MyList.Application.Common.Interfaces.Repositories
{
    public interface IAnimeRepository : IRepository<Anime>
    {
        Task<List<AnimeTag>> GetAllTags();
        Task CreateASyncDto(AnimeDto modelDto);
        Task<List<ItemDto>> GetAllItems();
        Task<Anime> GetByIdAsync(string id);
        Task AddToList(AddCollectionDto id);
    }
}
