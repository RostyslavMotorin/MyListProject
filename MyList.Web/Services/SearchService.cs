using AutoMapper;
using IGDB.Models;
using MyList.Application.Common.Interfaces.Repositories;
using MyList.Data.API;
using MyList.Domain.Common.Models.ContentModels;

namespace MyList.Web.Services
{
    public class SearchService
    {
        private readonly IGameRepository _gameRepository;
        private readonly ISerialRepository _serialRepository;
        private readonly IAnimeRepository _animeRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IFilmRepository _filmRepository;

        private readonly GoogleBooksApi _bookApi;
        private readonly KitsuApi _animeApi;
        private readonly TMDbApi _TMDbApi;

        public SearchService(IConfiguration configuration,
            IGameRepository gameRepository,
            ISerialRepository serialRepository,
            IAnimeRepository animeRepository,
            IBookRepository bookRepository,
            IFilmRepository filmRepository,
            IMapper mapper)
        {
            _gameRepository = gameRepository;
            _serialRepository = serialRepository;
            _animeRepository = animeRepository;
            _bookRepository = bookRepository;
            _filmRepository = filmRepository;

            _bookApi = new GoogleBooksApi(configuration, mapper);
            _animeApi = new KitsuApi(configuration, mapper);
            _TMDbApi = new TMDbApi(mapper);
        }

        //public async Task<IEnumerable<Game>> SearchGame(string search)
        //{
        //    var result = await _gameRepository.GetBySearch(search);
        //    //if(result == null || result.Count() < 5)
        //    //{

        //    //}

        //    return null;
        //}

        public async Task<IEnumerable<Book>> SearchBooks(string search)
        {
            var result = (await _bookRepository.GetBySearch(search)).ToList();
            if (result == null || result.Count() < 5)
            {
                var items = await _bookApi.GetBooksCollection(search);

                foreach (var item in items)
                {
                    await _bookRepository.CreateAsync(item);
                }

                result.AddRange(items);
            }

            return result;
        }

        public async Task<IEnumerable<Anime>> SearchAnime(string search)
        {
            var result = (await _animeRepository.GetBySearch(search)).ToList();
            if (result == null || result.Count() < 5)
            {
                var items = await _animeApi.GetAnimeCollection(search);

                foreach (var item in items)
                {
                    await _animeRepository.CreateAsync(item);
                }

                result.AddRange(items);
            }

            return result;
        }

        public async Task<IEnumerable<Film>> SearchFilm(string search)
        {
            var result = (await _filmRepository.GetBySearch(search)).ToList();
            if (result == null || result.Count() < 5)
            {
                var items = _TMDbApi.GetFilmCollection(search);

                foreach (var item in items)
                {
                    await _filmRepository.CreateAsync(item);
                }

                result.AddRange(items);
            }

            return result;
        }

        public async Task<IEnumerable<Serial>> SearchSerial(string search)
        {
            var result = (await _serialRepository.GetBySearch(search)).ToList();
            if (result == null || result.Count() < 5)
            {
                var items = _TMDbApi.GetSerialsCollection(search);

                foreach (var item in items)
                {
                    await _serialRepository.CreateAsync(item);
                }

                result.AddRange(items);
            }

            return result;
        }
    }
}
