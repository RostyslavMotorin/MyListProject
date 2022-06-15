using MyList.Application.Common.Dto;
using MyList.Domain.Common.Models.ContentModels;
using MyList.Domain.Common.Models.Tags;

namespace MyList.Application.Common.Interfaces.Repositories
{
    public interface IFilmRepository  : IRepository<Film>
    {
        Task<List<FilmTag>> GetAllTags();
        Task CreateASyncDto(FilmDto modelDto);
        Task<List<ItemDto>> GetAllItems();
        Task<Film> GetByIdAsync(string id);
        Task AddToList(string id);
    }
}
