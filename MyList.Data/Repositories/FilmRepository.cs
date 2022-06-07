using MyList.Application.Common.Interfaces.Repositories;
using MyList.Data.Contexts;
using MyList.Domain.Common.Models.ContentModels;

namespace MyList.Data.Repositories
{
    public class FilmRepository :  GenericRepository<Film>, IFilmRepository
    {
        public FilmRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
