using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using YgoProDeck.Api.Client.Models;

namespace YgoProDeck.Api.Client.Clients
{
    public interface ICardInformationClient
    {
        Task<List<List<Card>>> GetCardInformationAsync(SearchOptions options, CancellationToken cancellationToken);
        Task<Card> GetRandomCardInformationAsync(CancellationToken cancellationToken);
    }
}