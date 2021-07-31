﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FMSystems.WeatherForecast.Domain;
using FMSystems.WeatherForecast.Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using FMSystems.WeatherForecast.Services;

namespace FMSystems.WeatherForecast.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _forecastService;
        private readonly IGenericDbRepository<City> _genericDbRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService forecastService, IGenericDbRepository<City> genericDbRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _forecastService = forecastService ?? throw new ArgumentNullException(nameof(forecastService));
            _genericDbRepository = genericDbRepository ?? throw new ArgumentNullException(nameof(genericDbRepository));
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IEnumerable<FMSystems.WeatherForecast.Domain.WeatherForecast>> Get()
        {
            return _forecastService.GetForecasts();
        }
    }
}
