using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YgoProDeck.Api.Client.Clients;
using YgoProDeck.Api.Client.Clients.Implementations;

namespace YgoProDeck.Api.Client.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddYgoProDeck(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddSingleton<ICardImageClient, CardImageClient>()
                .AddSingleton<ICardInformationClient, CardInformationClient>()
                .AddSingleton<IYuGiOhCardClient, YgoProDeckCardClient>();

            services.AddHttpClient<CardImageClient>();
            services.AddHttpClient<CardInformationClient>();

            return services;
        }
    }
}