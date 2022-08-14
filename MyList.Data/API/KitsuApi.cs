using AutoMapper;
using Microsoft.Extensions.Configuration;
using MyList.Domain.Common.Enums;
using MyList.Domain.Common.Models.ContentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace MyList.Data.API
{
    public class KitsuApi
    {
        private readonly IMapper _mapper;
        private HttpClient _httpClient;
        private const string baseurl = "https://kitsu.io/api/edge";
        public KitsuApi(IConfiguration configuration, IMapper mapper)
        {
            _mapper = mapper;
            var httpClientFactory = new HttpClientFactory();
            _httpClient = httpClientFactory.CreateHttpClient(ApiServiceType.Anime, configuration);
        }

        public async Task<List<Anime>> GetAnimeCollection(string search)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["filter[text]"] = search;
            string queryString = query.ToString();

            var response = await _httpClient.GetAsync("https://kitsu.io/api/edge/anime?" + queryString);
            var contents = await response.Content.ReadAsStringAsync();
            var res = JsonSerializer.Deserialize<KitsuResponse>(contents);

            var anime = _mapper.Map<List<Anime>>(res.data.Select(x => x.attributes));
            return anime;
        }
    }
    class KitsuResponse
    {
        public IEnumerable<Data> data { get; set; }

    }

    public class Data
    {
        public string id { get; set; }
        public string type { get; set; }
        public AnimeAttribute attributes { get; set; }
    }
    public class AnimeAttribute
    {
        public string createdAt { get; set; }
        public string slug { get; set; }
        public string synopsis { get; set; }
        public int coverImageTopOffset { get; set; }
        public Title titles { get; set; }
        public string canonicalTitle { get; set; }
        public string averageRating { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public CoverImage coverImage { get; set; }
        public int episodeCount { get; set; }

    }
    public class Title
    {
        public string en { get; set; }
        public string en_jp { get; set; }
        public string ja_jp { get; set; }
    }

    public  class CoverImage
    {
        public string small { get; set; }
        public string large { get; set; }
        public string original { get; set; }
    }
}
