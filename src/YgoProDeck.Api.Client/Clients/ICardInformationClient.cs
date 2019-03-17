using System.Threading;
using System.Threading.Tasks;
using YgoProDeck.Api.Core.Models;

namespace YgoProDeck.Api.Client.Clients
{
    public interface ICardInformationClient
    {
        Task<Card> GetCardInformationAsync(SearchOptions options, CancellationToken cancellationToken);
    }
}