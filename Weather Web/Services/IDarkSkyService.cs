using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherWeb.Models;

namespace WeatherWeb.Services
{
    public interface IDarkSkyService
    {
        Task<Weather> GetWeatherAsync(string parameter);
    }
}
