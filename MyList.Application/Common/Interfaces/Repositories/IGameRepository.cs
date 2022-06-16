using MyList.Application.Common.Dto;
using MyList.Domain.Common.Models.ContentModels;
using MyList.Domain.Common.Models.Tags;

namespace MyList.Application.Common.Interfaces.Repositories
{
    public interface IGameRepository : IRepository<Game>
    {
        Task<List<GameTag>> GetAllTags();
        Task CreateASyncDto(GameDto modelDto);
        Task<List<ItemDto>> GetAllItems();
        Task<Game> GetByIdAsync(string id);
        Task AddToList(AddCollectionDto id);
    }
}
