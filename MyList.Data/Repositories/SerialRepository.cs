using MyList.Application.Common.Interfaces.Repositories;
using MyList.Data.Contexts;
using MyList.Domain.Common.Models.ContentModels;

namespace MyList.Data.Repositories
{
    public class SerialRepository : GenericRepository<Serial>, ISerialRepository
    {
        public SerialRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
