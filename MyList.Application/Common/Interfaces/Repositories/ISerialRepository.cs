using MyList.Application.Common.Dto;
using MyList.Domain.Common.Models.ContentModels;
using MyList.Domain.Common.Models.Tags;

namespace MyList.Application.Common.Interfaces.Repositories
{
    public interface ISerialRepository : IRepository<Serial>
    {
        Task<List<SerialTag>> GetAllTags();
        Task CreateASyncDto(SerialDto modelDto);
        Task<List<ItemDto>> GetAllItems();
        Task<Serial> GetByIdAsync(string id);
        Task AddToList(string id);
    }
}
