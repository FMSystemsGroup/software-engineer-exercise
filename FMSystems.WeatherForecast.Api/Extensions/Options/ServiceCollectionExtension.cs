using FMSystems.WeatherForecast.Domain.Repository;
using FMSystems.WeatherForecast.Infrastructure.Api.RepositoryImpl;
using FMSystems.WeatherForecast.Infrastructure.ApiClients.DarkSky;
using FMSystems.WeatherForecast.Infrastructure.Db.Context;
using FMSystems.WeatherForecast.Infrastructure.Db.RepositoryImpl;
using FMSystems.WeatherForecast.Infrastructure.DBContext;
using FMSystems.WeatherForecast.Infrastructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DSI.IntelligenceOIDC.Api.Extensions.Options
{
    /// <summary>
    /// A services collection extension to encapulate the configuration objects setups.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Sets up the configuration objects..
        /// </summary>
        /// <param name="services">The services available in the application.</param>
        /// <param name="configuration">Represents a set of key/value application configuration properties.</param>
        /// <returns>An <see cref="IServiceCollection"/> for creating and configuring the system.</returns>
        public static IServiceCollection AddWeatherForecastOptions(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            //Options
            services.Configure<DarkSkyOptions>(configuration.GetSection("DarkSkyApiSettings"));

            return services;
        }
    }
}
