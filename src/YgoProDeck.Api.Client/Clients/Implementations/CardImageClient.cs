using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace YgoProDeck.Api.Client.Clients.Implementations
{
    public class CardImageClient : ICardImageClient
    {
        private readonly HttpClient _httpClient;

        public CardImageClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<byte[]> GetImageByUrlAsync(string url, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync(url, cancellationToken);
            return await response.Content.ReadAsByteArrayAsync();
        }

        public async Task<byte[]> GetImageAsync(string id, CancellationToken cancellationToken)
        {
            return await GetImageByUrlAsync($"https://storage.googleapis.com/ygoprodeck.com/pics/{id}.jpg",
                cancellationToken);
        }

        public async Task<byte[]> GetSmallImageAsync(string id, CancellationToken cancellationToken)
        {
            return await GetImageByUrlAsync($"https://storage.googleapis.com/ygoprodeck.com/pics_small/{id}.jpg",
                cancellationToken);
        }
    }
}