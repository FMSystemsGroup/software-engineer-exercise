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

        private readonly IDarkSkyApiClient _darkSkyApiClient;
        private readonly IOptions<DarkSkyOptions> _darkSkyOptions;

        public ForecastRepository(IDarkSkyApiClient darkSkyApiClient, IOptions<DarkSkyOptions> darkSkyOptions)
        {
            this._darkSkyApiClient = darkSkyApiClient;
            this._darkSkyOptions = darkSkyOptions;
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

        public async Task<string> GetForecastSummaryAsync(double lat, double lon, long? unixTime)
        {
            var time = unixTime ?? _darkSkyOptions.Value.DefaultDateTimeUnix;
            var darkSkyReponse = await GetDarkSkyForecast(lat, lon, time);
            var hourlyData = darkSkyReponse.Hourly.Data.SingleOrDefault(x => x.Time == time);
            return hourlyData.Summary;
        }

        private async Task<DarkSkyResponse> GetDarkSkyForecast(double lat, double lon, long time)
        {
            return await _darkSkyApiClient.ForecastAsync(
                $"{lat},{lon},{time}", 
                _darkSkyOptions.Value.ExcludeArgs, 
                null, 
                null, 
                null,
                _darkSkyOptions.Value.ApiKey);
        }
    }
}
