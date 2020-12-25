using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherWeb.Models;

namespace WeatherWeb.Services
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>> GetLocationsAsync();
    }
}
