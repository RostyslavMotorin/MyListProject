using MyList.Application.Common.Interfaces.Repositories;
using MyList.Data.Contexts;
using MyList.Domain.Common.Models.ContentModels;

namespace MyList.Data.Repositories
{
    internal class GameRepository : GenericRepository<Game> , IGameRepository
    {
        public GameRepository(ApplicationDBContext context) : base( context )
        {
        }
    }
}
