using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using YgoProDeck.Api.Client.Models;

namespace YgoProDeck.Api.Client.Clients.Implementations
{
    public class YgoProDeckCardClient : IYuGiOhCardClient
    {
        private readonly ICardInformationClient _informationClient;
        private readonly ICardImageClient _imageClient;

        public YgoProDeckCardClient(ICardInformationClient informationClient, ICardImageClient imageClient)
        {
            _informationClient = informationClient;
            _imageClient = imageClient;
        }
        
        public async Task<List<List<Card>>> GetCardInformationAsync(SearchOptions options, CancellationToken cancellationToken)
        {
            return await _informationClient.GetCardInformationAsync(options, cancellationToken);
        }

        public async Task<Card> GetRandomCardInformationAsync(CancellationToken cancellationToken)
        {
            return await _informationClient.GetRandomCardInformationAsync(cancellationToken);
        }

        public async Task<byte[]> GetImageByUrlAsync(string url, CancellationToken cancellationToken)
        {
            return await _imageClient.GetImageByUrlAsync(url, cancellationToken);
        }

        public async Task<byte[]> GetImageAsync(string id, CancellationToken cancellationToken)
        {
            return await _imageClient.GetImageAsync(id, cancellationToken);
        }

        public async Task<byte[]> GetSmallImageAsync(string id, CancellationToken cancellationToken)
        {
            return await _imageClient.GetSmallImageAsync(id, cancellationToken);
        }
    }
}