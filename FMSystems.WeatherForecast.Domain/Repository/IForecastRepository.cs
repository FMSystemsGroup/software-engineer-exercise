using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMSystems.WeatherForecast.Domain.Repository
{
    public interface IForecastRepository
    {
        Task<Entity.Forecast> GetForecastAsync(double lat, double lon, DateTime? dateTime = null);
    }
}
