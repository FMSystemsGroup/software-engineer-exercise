using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using FMSystems.WeatherForecast.Domain.Repository;
using FMSystems.WeatherForecast.Domain.Entity;

namespace FMSystems.WeatherForecast.Api.Controllers.Cities
{
    /// <summary>
    /// A controller that is responsible for cities endpoints.
    /// </summary>
    [ApiController]
    [Route("cities")]
    [ResponseCache(Duration = 60)]
    public class CityController: ControllerBase
    {
        private readonly ILogger<CityController> _logger;
        private readonly ICityRepository _cityRepository;

        /// <summary>
        /// The Cities Controller constructor.
        /// </summary>
        /// <param name="logger">the logger object.</param>
        /// <param name="cityRepository">the city repository.</param>
        public CityController(ILogger<CityController> logger, ICityRepository cityRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _cityRepository = cityRepository ?? throw new ArgumentNullException(nameof(cityRepository));
        }

        /// <summary>
        /// Returns all existing cities.
        /// </summary>
        /// <returns>A list of cities or empty if none exists.<see cref="City"/></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(Name = nameof(GetAllAsync))]
        public async Task<ICollection<Domain.Entity.City>> GetAllAsync()
        {
            _logger.LogDebug($"{nameof(GetAllAsync)} starting...");
            var cities = await _cityRepository.GetAllAsync();
            
            return cities;
        }
    }
}
