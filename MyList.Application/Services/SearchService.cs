using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyList.Application.Common.Interfaces.Repositories;

namespace MyList.Application.Services
{
    public class SearchService<T> where T: class
    {
        private readonly IRepository<T> _repository;
        public SearchService(IRepository<T> repository)
        {
            
        }

        public List<T> SearchOption(string searcg)
        {

            return null;
        }
    }
}
