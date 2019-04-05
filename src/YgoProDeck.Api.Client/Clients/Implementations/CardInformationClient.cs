using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using YgoProDeck.Api.Client.Models;

namespace YgoProDeck.Api.Client.Clients.Implementations
{
    public class CardInformationClient : ICardInformationClient
    {
        private readonly HttpClient _httpClient;

        public CardInformationClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<Card> GetCardInformationAsync(SearchOptions options, CancellationToken cancellationToken)
        {
            var queriesDictionary = ConvertToDictionary(options);
            
            var uriBuilder = new UriBuilder("https://db.ygoprodeck.com/api/v4/cardinfo.php");
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            foreach (var queryPair in queriesDictionary)
            {
                query[queryPair.Key] = queryPair.Value;
            }

            uriBuilder.Query = query.ToString();
            var url = uriBuilder.ToString();

            var response = await _httpClient.GetAsync(url, cancellationToken);
            var responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Card>(responseBody);
        }

        private IReadOnlyDictionary<string, string> ConvertToDictionary(SearchOptions options)
        {
            var dictionary = new Dictionary<string, string>();
            var properties = options.GetType().GetProperties();

            var stringProperties = properties
                .Where(propertyInfo => 
                    propertyInfo.GetType() == typeof(string) &&
                    !string.IsNullOrEmpty(propertyInfo.GetValue(options) as string));

            foreach (var stringProperty in stringProperties)
            {
                dictionary.Add(nameof(stringProperty).ToLowerInvariant(), stringProperty.GetValue(options) as string);
            }

            var intProperties = properties
                .Where(propertyInfo =>
                    propertyInfo.GetType() == typeof(int?) &&
                    (propertyInfo.GetValue(options) as int?) != null);

            foreach (var intProperty in intProperties)
            {
                dictionary.Add(nameof(intProperties).ToLowerInvariant(), ((int)intProperty.GetValue(options)).ToString());
            }

            return dictionary;
        }
    }
}