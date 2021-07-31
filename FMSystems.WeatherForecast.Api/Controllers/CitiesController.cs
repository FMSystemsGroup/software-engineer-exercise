using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using FMSystems.WeatherForecast.Domain.Repository;
using FMSystems.WeatherForecast.Domain.Entity;

namespace FMSystems.WeatherForecast.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CitiesController: ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ICityRepository _cityRepository;

        public CitiesController(ILogger<WeatherForecastController> logger, ICityRepository cityRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _cityRepository = cityRepository ?? throw new ArgumentNullException(nameof(cityRepository));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IEnumerable<City>> Get()
        {
            return await _cityRepository.GetAllAsync();
        }
    }
}
