using Microsoft.Extensions.Configuration;
using MyList.Domain.Common.Enums;
using MyList.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList.Data.API
{
    public class HttpClientFactory //: Domain.Interfaces.IHttpClientFactory
    {
        private const string confKey = "WebApiURLs:";
        public HttpClient CreateHttpClient(ApiServiceType serviceType, IConfiguration configuration)
        {
            switch (serviceType)
            {
                case ApiServiceType.Game:
                    return CreateGameServiceClient(configuration);
                case ApiServiceType.Film:
                    return CreateFilmServiceClient(configuration);
                case ApiServiceType.Anime:
                    return CreateAnimeServiceClient(configuration);
                case ApiServiceType.Book:
                    return CreateBookServiceClient(configuration);
                case ApiServiceType.Serial:
                    return CreateSerialServiceClient(configuration);
                default:
                    throw new ArgumentException($"The ApiServiceType.{serviceType} is not implemented.");
            }
        }

        private HttpClient CreateBookServiceClient(IConfiguration configuration)
        {
            return new HttpClient
            {
                BaseAddress = new Uri(configuration[confKey + "GoogleBookApi"])
            };
        }


        private HttpClient CreateGameServiceClient(IConfiguration configuration)
        {
            return new HttpClient
            {
                //BaseAddress = new Uri(_appSettings["LocalizationServiceUrl"])
            };
        }

        private HttpClient CreateSerialServiceClient(IConfiguration configuration)
        {
            return new HttpClient
            {
                //BaseAddress = new Uri(_appSettings["LocalizationServiceUrl"])
            };
        }

        private HttpClient CreateAnimeServiceClient(IConfiguration configuration)
        {
            return new HttpClient
            {
                //BaseAddress = new Uri(_appSettings["LocalizationServiceUrl"])
            };
        }

        private HttpClient CreateFilmServiceClient(IConfiguration configuration)
        {
            return new HttpClient
            {
                //BaseAddress = new Uri(_appSettings["LocalizationServiceUrl"])
            };
        }

       


        //public async Task<bool> CreateStudyAsync(CreateeCOAStudyRequest request)
        //{
        //    try
        //    {
        //        string content = JsonConvert.SerializeObject(request, new JsonSerializerSettings());
        //        var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
        //        var result = await _httpClient.PostAsync(StudiesEndpoint, httpContent).ConfigureAwait(false);
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var resultBody = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
        //            var resultGUID = JsonConvert.DeserializeObject<CreateeCOAStudyResponse>(resultBody);
        //            return string.IsNullOrWhiteSpace(resultGUID.studyGuid) ? false : true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }

        //    return false;
        //}
    }
}
