using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using FMSystems.WeatherForecast.Infrastructure.ApiClients.DarkSky;

namespace FMSystems.WeatherForecast.Api.Extensions.ApiClients
{
    /// <summary>
    /// Extends <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers DarkSky api.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configurations.</param>
        public static IServiceCollection AddDarkSkyApiClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IDarkSkyApiClient, DarkSkyApiClient>();

            return services;
        }
    }
}