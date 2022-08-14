using Microsoft.Extensions.Configuration;
using MyList.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoMapper;
using MyList.Domain.Common.Models.ContentModels;

namespace MyList.Data.API
{
    public class GoogleBooksApi
    {
        private readonly IMapper _mapper;
        private HttpClient _httpClient;
        private const string baseurl = "https://www.googleapis.com/books/v1/volumes";
        public GoogleBooksApi(IConfiguration configuration, IMapper mapper)
        {
            _mapper = mapper;
            var httpClientFactory = new HttpClientFactory();
            _httpClient = httpClientFactory.CreateHttpClient(ApiServiceType.Book, configuration);
        }

        public async Task<List<Book>> GetBooksCollection(string search)
        {
            try
            {
                //var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
                var response = await _httpClient.GetAsync("?q=" + search);
                var contents = await response.Content.ReadAsStringAsync();
                GoogleBookResponse items = JsonSerializer.Deserialize<GoogleBookResponse>(contents);

                var books = _mapper.Map<List<Book>>(items.items.Select(x=>x.volumeInfo));
                return books;
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }

            return null;
        }
    }

    public class GoogleBookResponse
    {
        public string kind { get; set; }
        public int totalItems { get; set; }
        public IEnumerable<item> items { get; set; } = new List<item>();
    }
    public class item
    {
        public string kind { get; set; }
        public string id { get; set; }
        public volumeInfo volumeInfo { get; set; }
    }
    public class volumeInfo
    {
        public string title { get; set; }
        public string subtitle { get; set; }
        public IEnumerable<string> authors { get; set; }
        public string publishedDate { get; set; }
        public string description { get; set; }
        public int pageCount { get; set; }
        public List<string> categories { get; set; }
        public string language { get; set; }
        public imageLinks imageLinks { get; set; }

    }
    public class imageLinks
    {
        public string thumbnail { get; set; }
        public string smallThumbnail { get; set; }
    }
}
