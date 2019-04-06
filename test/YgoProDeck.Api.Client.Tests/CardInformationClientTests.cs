using System.Net.Http;
using System.Threading;
using Xunit;
using YgoProDeck.Api.Client.Clients;
using YgoProDeck.Api.Client.Clients.Implementations;
using YgoProDeck.Api.Client.Models;

namespace YgoProDeck.Api.Client.Tests
{
    public class CardInformationClientTests
    {
        private readonly ICardInformationClient _informationClient;

        public CardInformationClientTests()
        {
            _informationClient = new CardInformationClient(new HttpClient());
        }
        
        [Fact]
        public async void GetCardInformationAsync1()
        {
            var options = new SearchOptions
            {
                Name = "Blue-Eyes White Dragon"
            };

            var cards = await _informationClient.GetCardInformationAsync(options, CancellationToken.None);
            
            Assert.Equal(cards[0][0].Name, options.Name);
        }

        [Fact]
        public async void GetRandomCardInformationAsync1()
        {
            var card = await _informationClient.GetRandomCardInformationAsync(CancellationToken.None);
            
            Assert.Equal(typeof(Card), card.GetType());
        }
    }
}