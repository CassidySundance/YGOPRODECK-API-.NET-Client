using System;
using System.Net.Http;
using System.Threading;
using Xunit;
using YgoProDeck.Api.Client.Clients;
using YgoProDeck.Api.Client.Clients.Implementations;

namespace YgoProDeck.Api.Client.Tests
{
    public class CardImageClientTests
    {
        private readonly ICardImageClient _imageClient;
        
        public CardImageClientTests()
        {
            _imageClient = new CardImageClient(new HttpClient());
        }
        
        [Fact]
        public async void GetImageAsync1()
        {
            var image = await _imageClient.GetImageAsync("27511", CancellationToken.None);
            
            Assert.NotNull(image);
        }
        
        [Fact]
        public async void GetSmallImageAsync1()
        {
            var image = await _imageClient.GetSmallImageAsync("27511", CancellationToken.None);
            
            Assert.NotNull(image);
        }
    }
}