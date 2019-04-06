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
        
        public async Task<List<List<Card>>> GetCardInformationAsync(SearchOptions options, CancellationToken cancellationToken)
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

            return JsonConvert.DeserializeObject<List<List<Card>>>(responseBody);
        }

        public async Task<Card> GetRandomCardInformationAsync(CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync("https://db.ygoprodeck.com/api/v4/randomcard.php", cancellationToken);
            var responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Card>(responseBody);
        }

        private IReadOnlyDictionary<string, string> ConvertToDictionary(SearchOptions options)
        {
            var dictionary = new Dictionary<string, string>();
            var properties = options.GetType().GetProperties();
            
            var stringProperties = properties
                .Where(propertyInfo => 
                    propertyInfo.PropertyType == typeof(string) &&
                    !string.IsNullOrEmpty(propertyInfo.GetValue(options) as string))
                .ToList();

            foreach (var stringProperty in stringProperties)
            {
                dictionary.Add(stringProperty.Name.ToLowerInvariant(), stringProperty.GetValue(options) as string);
            }

            var intProperties = properties
                .Where(propertyInfo =>
                    propertyInfo.PropertyType == typeof(int?) &&
                    (propertyInfo.GetValue(options) as int?) != null)
                .ToList();

            foreach (var intProperty in intProperties)
            {
                dictionary.Add(intProperty.Name.ToLowerInvariant(), ((int)intProperty.GetValue(options)).ToString());
            }

            return dictionary;
        }
    }
}