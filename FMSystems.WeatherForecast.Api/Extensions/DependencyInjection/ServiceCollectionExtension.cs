using FMSystems.WeatherForecast.Services;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Sets up the dependency injection configuration.
        /// </summary>
        /// <param name="services">The services available in the application.</param>
        /// <returns>An <see cref="IServiceCollection"/> for creating and configuring the system.</returns>
        public static IServiceCollection AddWeatherForecastApplication(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddTransient<IWeatherForecastService, WeatherForecastService>();

            return services;
        }
    }
}
