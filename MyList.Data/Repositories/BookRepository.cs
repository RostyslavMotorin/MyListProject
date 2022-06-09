using Microsoft.EntityFrameworkCore;
using MyList.Application.Common.Interfaces.Repositories;
using MyList.Data.Contexts;
using MyList.Domain.Common.Models.ContentModels;

namespace MyList.Data.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly ApplicationDBContext _context;
        public BookRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetTopBook(int count)
        {
            return await _context.Books.Take(count).OrderBy(x => x.GlobalScore).ToListAsync();
        }
    }
}
