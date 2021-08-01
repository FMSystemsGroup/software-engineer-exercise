using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMSystems.WeatherForecast.Domain.Repository
{
    public interface IForecastRepository
    {
        IEnumerable<WeatherForecast.Domain.Entity.Forecast> GetForecasts();
        Task<string> GetForecastSummaryAsync(double lat, double lon, long? unixTime = null);
    }
}
