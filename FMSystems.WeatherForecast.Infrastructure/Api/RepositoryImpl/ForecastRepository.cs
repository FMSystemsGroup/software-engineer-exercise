using FMSystems.WeatherForecast.Domain.Repository;
using FMSystems.WeatherForecast.Infrastructure.ApiClients.DarkSky;
using FMSystems.WeatherForecast.Infrastructure.Options;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMSystems.WeatherForecast.Infrastructure.Api.RepositoryImpl
{
    public class ForecastRepository : IForecastRepository
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private const int UNIX_TIME_2018_JULY_4_1200 = 1530705600;
        private const string DARKSKY_EXCLUDE_ARGS = "currently,minutely,daily,flags";
        private readonly IDarkSkyApiClient _darkSkyApiClient;
        private readonly IOptions<DarkSkyOptions> _darkSkyOptions;

        public ForecastRepository(IDarkSkyApiClient darkSkyApiClient,
            IOptions<DarkSkyOptions> darkSkyOptions)
        {
            this._darkSkyApiClient = darkSkyApiClient ?? throw new ArgumentNullException(nameof(darkSkyApiClient));
            this._darkSkyOptions = darkSkyOptions ?? throw new ArgumentNullException(nameof(darkSkyOptions));
        }

        public IEnumerable<FMSystems.WeatherForecast.Domain.Entity.Forecast> GetForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new FMSystems.WeatherForecast.Domain.Entity.Forecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        public async Task<string> GetForecastSummaryAsync(double lat, double lon, int unixTime)
        {
            var darkSkyReponse = await GetDarkSkyForecast(lat, lon, unixTime);
            var hourlyData = darkSkyReponse.Hourly.Data.SingleOrDefault(x => x.Time == unixTime);
            return hourlyData.Summary;
        }

        private async Task<DarkSkyResponse> GetDarkSkyForecast(double lat, double lon, double time)
        {
            return await _darkSkyApiClient.ForecastAsync($"{lat},{lon},{time}", DARKSKY_EXCLUDE_ARGS, null, null, null, _darkSkyOptions.Value.ApiKey);
        }
    }
}
