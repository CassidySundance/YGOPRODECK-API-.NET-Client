# YGOPRODECK-API-.NET-Client
.NET Client for the YGOPRODECK API

# NuGet Package
You can download the NuGet package to include it in your project

```
Install-Package YgoProDeck.Api.Client -Version 1.0.0
```

# Using the YgoProDeck client in your project
First, add the card client to the service container.

```cs
private readonly IConfiguration _configuration;

public Startup(IConfiguration configuration)
{
    _configuration = configuration;
}
        
public void ConfigureServices(IServiceCollection services)
{
    services.AddYgoProDeck(_configuration);
}
```

Then use DI to get the ```IYuGiOhCardClient``` in your class. Given below are the calls you can make. The client has Polly policies implemented.

```cs
using System.Threading;
using YgoProDeck.Api.Client.Clients;
using YgoProDeck.Api.Client.Models;

namespace YgoProDeckTest
{
    public class Foo
    {
        private readonly IYuGiOhCardClient _cardClient;

        public Foo(IYuGiOhCardClient cardClient)
        {
            _cardClient = cardClient;
        }

        public async void Bar(CancellationToken cancellationToken)
        {
            // Getting card information
            var options = new SearchOptions
            {
                Atk = 2000,
                Def = 1500,
                Level = 4
            };

            // Call to API returns a List<List<Card>> object as of now
            var cards = await _cardClient.GetCardInformationAsync(options, cancellationToken);
            
            // Getting a random card, returns a Card object
            var randomCard = await _cardClient.GetRandomCardInformationAsync(cancellationToken);
            
            // Getting card image by id, returns a byte array
            var image = await _cardClient.GetImageAsync("12345678", cancellationToken);
            var smallImage = await _cardClient.GetSmallImageAsync(randomCard.Id, cancellationToken);
            
            // Getting card image by URL, returns a byte array
            var imageByUrl = await _cardClient.GetImageByUrlAsync(randomCard.Image_Url, cancellationToken); // for regularly sized images
            var smallImageByUrl = await _cardClient.GetImageByUrlAsync(randomCard.Image_Url_Small, cancellationToken); // for small sized images
        }
    }
}
```

The ```SearchOptions``` object has the following fields that can be used for filtering.

```cs
namespace YgoProDeck.Api.Client.Models
{
    public class SearchOptions
    {
        /// <summary>
        /// The exact name of the card. You can also pass a card ID to this.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// A fuzzy search using a string.
        /// </summary>
        public string FName { get; set; }
        
        /// <summary>
        /// The type of card you want to filter by.
        /// </summary>
        public string Type { get; set; }
        
        /// <summary>
        /// Filter by ATK value.
        /// </summary>
        public int? Atk { get; set; }
        
        /// <summary>
        /// Filter by DEF value.
        /// </summary>
        public int? Def { get; set; }
        
        /// <summary>
        /// Filter by card level/RANK.
        /// </summary>
        public int? Level { get; set; }
        
        /// <summary>
        /// Filter by the card race, which is officially called type. This is also used for Spell/Trap cards.
        /// </summary>
        public string Race { get; set; }
        
        /// <summary>
        /// Filter by the card attribute.
        /// </summary>
        public string Attribute { get; set; }
        
        /// <summary>
        /// Filter the cards by Link value.
        /// </summary>
        public string Link { get; set; }
        
        /// <summary>
        /// Filter the cards by Link Marker value.
        /// </summary>
        public string LinkMarker { get; set; }
        
        /// <summary>
        /// Filter the cards by Pendulum Scale value.
        /// </summary>
        public string Scale { get; set; }
        
        /// <summary>
        /// Filter the cards by card set.
        /// </summary>
        public string Set { get; set; }
        
        /// <summary>
        /// Filter the cards by archetype.
        /// </summary>
        public string ArcheType { get; set; }
        
        /// <summary>
        /// Filter the cards by ban list.
        /// </summary>
        public string BanList { get; set; }
        
        /// <summary>
        /// Sort the order of the cards.
        /// </summary>
        public string Sort { get; set; }
        
        /// <summary>
        /// Filter the cards by Language.
        /// </summary>
        public string La { get; set; }
    }
}
```
