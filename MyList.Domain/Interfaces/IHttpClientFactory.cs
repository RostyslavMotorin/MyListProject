namespace MyList.Domain.Interfaces
{
    public interface IHttpClientFactory
    {
        HttpClient CreateGameServiceClient();
        HttpClient CreateSerialServiceClient();
        HttpClient CreateAnimeServiceClient();
        HttpClient CreateFilmServiceClient();
        HttpClient CreateBookServiceClient();
    }
}
