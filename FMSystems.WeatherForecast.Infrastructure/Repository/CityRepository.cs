using FMSystems.WeatherForecast.Domain;
using FMSystems.WeatherForecast.Infrastructure.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMSystems.WeatherForecast.Infrastructure.Repository
{
    public class CityRepository : GenericDbRepository<City>
    {
        public CityRepository(WeatherForecastDbContext context) : base(context)
        {
        }
    }
}
