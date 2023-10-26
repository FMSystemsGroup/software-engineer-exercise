using CityWeatherApp.Service;
using CityWeatherApp.Service.Contract;
using System.Net.Http.Headers;

namespace CityWeatherApp.Extensions
{
    /// <summary>
    /// This class contains extension methods for the IServiceCollection interface that can configure the services for the web application
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// This method adds a scoped service for the city weather service class that implements the ICityWeatherService interface 
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureCityWeatherService(this IServiceCollection services) =>
            services.AddScoped<ICityWeatherService, CityWeatherService>();

        /// <summary>
        /// This method adds two named HTTP clients for the city API and the weather visual crossing API with their base addresses and headers
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureHttpClient(this IServiceCollection services)
        {
            services.AddHttpClient(name: "CityAPI",
            configureClient: options =>
            {
                options.BaseAddress = new Uri("https://localhost:5001/");
                options.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(
                    mediaType: "application/json", quality: 1.0));
            });

            services.AddHttpClient(name: "WeatherVisualCrossingAPI",
            configureClient: options =>
            {
                options.BaseAddress = new Uri("https://weather.visualcrossing.com/");
                options.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(
                    mediaType: "application/json", quality: 1.0));
            });
        }
            
    }
}
