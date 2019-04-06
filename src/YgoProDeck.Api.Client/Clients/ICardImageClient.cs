using System.Threading;
using System.Threading.Tasks;

namespace YgoProDeck.Api.Client.Clients
{
    public interface ICardImageClient
    {
        Task<byte[]> GetImageByUrlAsync(string url, CancellationToken cancellationToken);
        
        Task<byte[]> GetImageAsync(string id, CancellationToken cancellationToken);

        Task<byte[]> GetSmallImageAsync(string id, CancellationToken cancellationToken);
    }
}