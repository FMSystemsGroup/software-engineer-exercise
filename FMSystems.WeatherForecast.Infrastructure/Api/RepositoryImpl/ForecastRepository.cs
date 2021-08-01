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
        private readonly IDarkSkyApiClient _darkSkyApiClient;
        private readonly IOptions<DarkSkyOptions> _darkSkyOptions;

        public ForecastRepository(IDarkSkyApiClient darkSkyApiClient, IOptions<DarkSkyOptions> darkSkyOptions)
        {
            this._darkSkyApiClient = darkSkyApiClient;
            this._darkSkyOptions = darkSkyOptions;
        }

        public async Task<Domain.Entity.Forecast> GetForecastAsync(double lat, double lon, DateTime? dateTime)
        {
            var time = dateTime == null ? _darkSkyOptions.Value.DefaultUnixTime : ((DateTimeOffset)dateTime.Value).ToUnixTimeSeconds();

            var darkSkyReponse = await GetDarkSkyForecast(lat, lon, time);

            var localTime = ApplyOffset(time, darkSkyReponse.Offset.Value);

            var hourlyData = darkSkyReponse.Hourly.Data.SingleOrDefault(x => x.Time == localTime);

            return new Domain.Entity.Forecast()
            {
                DateTimeUTC = DateTimeOffset.FromUnixTimeSeconds(localTime).DateTime,
                Offset = darkSkyReponse.Offset.Value,
                Icon = hourlyData.Icon,
                Summary = hourlyData.Summary,
                TemperatureF = hourlyData.Temperature,
                UVIndex = hourlyData.UvIndex
            };
        }

        private static long ApplyOffset(long unixGMTtime, double offset)
        {
            return unixGMTtime + (60 * 60 * ((long)offset) * -1);
        }

        private async Task<DarkSkyResponse> GetDarkSkyForecast(double lat, double lon, long time)
        {
            return await _darkSkyApiClient.ForecastAsync(
                $"{lat},{lon},{time}", 
                _darkSkyOptions.Value.ExcludeArgs, 
                null,
                _darkSkyOptions.Value.LangArgs,
                _darkSkyOptions.Value.UnitArgs,
                _darkSkyOptions.Value.ApiKey);
        }
    }
}
