using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using FMSystems.WeatherForecast.Domain.Repository;

namespace FMSystems.WeatherForecast.Api.Controllers
{
    /// <summary>
    /// A controller that is responsible for forecast endpoints.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IForecastRepository _forecastRepository;

        /// <summary>
        /// The forecast controller.
        /// </summary>
        /// <param name="logger">the logger object.</param>
        /// <param name="forecastRepository">the forecast repository.</param>
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IForecastRepository forecastRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _forecastRepository = forecastRepository ?? throw new ArgumentNullException(nameof(forecastRepository));
        }

        /// <summary>
        /// Returns the forecast for the known cities.
        /// </summary>
        /// <returns>A list for weather forecasts. <see cref="Domain.Entity.WeatherForecast"/></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(Name = nameof(GetAll))]
        public IEnumerable<Domain.Entity.WeatherForecast> GetAll()
        {
            return _forecastRepository.GetForecasts();
        }
    }
}
