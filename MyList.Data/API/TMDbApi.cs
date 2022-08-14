using AutoMapper;
using MyList.Domain.Common.Models.ContentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;

namespace MyList.Data.API
{
    public class TMDbApi
    {
        private const string APIKEYv3 = "64e7f722f9a673040ca71e452279f38a";

        private readonly IMapper _mapper;
        public TMDbApi(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<Film> GetFilmCollection(string search)
        {
            try
            {
                TMDbClient client = new TMDbClient(APIKEYv3);
                SearchContainer<SearchMovie> results = client.SearchMovieAsync(search).Result;

                var film = _mapper.Map<List<Film>>(results.Results);
                return film;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            

            return null;
        }

        public IEnumerable<Serial> GetSerialsCollection(string search)
        {
            try
            {
                TMDbClient client = new TMDbClient(APIKEYv3);
                SearchContainer<SearchTv> results = client.SearchTvShowAsync(search).Result;

                var serials = _mapper.Map<List<Serial>>(results.Results);
                return serials;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            return null;
        }
    }
}
