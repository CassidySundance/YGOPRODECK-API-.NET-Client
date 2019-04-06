using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
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

            services
                .AddHttpClient<CardImageClient>()
                .AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(3),
                    TimeSpan.FromSeconds(5) 
                }));
            
            services
                .AddHttpClient<CardInformationClient>()
                .AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(3),
                    TimeSpan.FromSeconds(5) 
                }));

            return services;
        }
    }
}