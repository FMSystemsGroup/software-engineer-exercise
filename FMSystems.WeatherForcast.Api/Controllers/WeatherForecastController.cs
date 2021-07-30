using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FMSystems.WeatherForcast.Domain;
using FMSystems.WeatherForecast.Application;

namespace FMSystems.WeatherForcast.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _forecastService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService forecastService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _forecastService = forecastService ?? throw new ArgumentNullException(nameof(forecastService));
        }

        [HttpGet]
        public IEnumerable<FMSystems.WeatherForcast.Domain.WeatherForecast> Get()
        {
            return _forecastService.GetForecasts();
        }
    }
}
