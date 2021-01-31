using DarkSkyApi.Models;
using FMSystems.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FMSystems.Services.Interfaces
{
    public interface IWeatherService
    {
        Task<Forecast> GetWeather(string key, City city, DateTime date);
        Task<HourDataPoint> GetForecastForHour(int desiredHour, List<HourDataPoint> dataPoints);
    }
}
