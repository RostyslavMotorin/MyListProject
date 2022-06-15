using MyList.Application.Common.Dto;
using MyList.Domain.Common.Models.ContentModels;
using MyList.Domain.Common.Models.Tags;

namespace MyList.Application.Common.Interfaces.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<List<BookTag>> GetAllTags();
        Task CreateASyncDto(BookDto modelDto);
        Task<List<ItemDto>> GetAllItems();
        Task<Book> GetByIdAsync(string id);
        Task AddToList(string id);
    }
}
