using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using WeatherFetchAPI.Models;
using WeatherFetchAPI.Helpers;
using System.Net.Http;
using System;
using Microsoft.AspNetCore.Http;
using TimeZoneConverter;
using Microsoft.Extensions.Logging;

namespace WeatherFetchAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WeatherController : ControllerBase
	{
		private readonly IOptions<AppSettings> _appSettings;
		private readonly ILogger _logger;

		public WeatherController(IOptions<AppSettings> settings, ILogger<WeatherController> logger) {
			_appSettings = settings;
			_logger = logger;
		}

		// This could be a POST as well. In a way, it is creating an object from the
		// data given.
		// GET: api/<WeatherController>/ForCity/{cityId}
		[HttpGet("ForCity/{cityId}")]
		public async Task<ActionResult<string>> GetWeatherForCity(int cityId)
		{
			_logger.LogInformation($"Get weather for city with id {cityId} called.");
			//Find the city the user requested by its id
			var chosenCity = CityHelper.GetCityById(cityId, _appSettings.Value.Cities);
			if (chosenCity.id == -1)
			{
				_logger.LogError($"City not found for id {cityId}.");
				return NotFound("City not found.");
			}

			try
			{
				var helper = new WeatherHelper(_appSettings.Value.ApiKey);
				//DarkSky requires the lat/lng of the city so we need to get
				//that using the city and state from a geocoding service
				var geoData = helper.GetForwardGeocodeForCity(chosenCity.Name, chosenCity.State, _appSettings.Value.OpenCageApiKey);
				if (geoData.Results.Count() < 1) {
					_logger.LogError($"Geographic information not found for {chosenCity.Name}, {chosenCity.State}.");
					return NotFound("Geographic information for city not found.");
				}

				var firstResult = geoData.Results.First();
				var dateToCheck = DateTime.Parse(_appSettings.Value.DateToCheck);
				var dateToCheckInUtc = helper.GetUtcVersionOfDate(firstResult.Annotations.Timezone.Name, dateToCheck); ;
				var unixDateTime = helper.GetUnixTimeStampForDate(dateToCheckInUtc);

				var body = await helper.GetWeatherForCityAtTime(firstResult.Geometry.Latitude,
					firstResult.Geometry.Longitude,
					unixDateTime);
				return body;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}
	}
}
