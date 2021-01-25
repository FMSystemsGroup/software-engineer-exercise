using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WeatherFetchAPI.Models;
using WeatherFetchAPI.Helpers;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace WeatherFetchAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WeatherController : ControllerBase
	{
		private readonly IOptions<AppSettings> _appSettings;
		private readonly ILogger _logger;
		private readonly WeatherFetchContext _context;

		public WeatherController(IOptions<AppSettings> settings, ILogger<WeatherController> logger, WeatherFetchContext context) {
			_appSettings = settings;
			_logger = logger;
			_context = context;
		}

		// This could be a POST as well. In a way, it is creating an object from the
		// data given.
		// GET: api/<WeatherController>/ForCity/{cityId}
		[HttpGet("ForCity/{cityId}")]
		public async Task<ActionResult<string>> GetWeatherForCity(int cityId)
		{
			_logger.LogInformation($"Get weather for city with id {cityId} called.");
			//Find the city the user requested by its id
			var chosenCity = _context.Cities.FirstOrDefault(c => c.id == cityId);
			if (chosenCity == null)
			{
				_logger.LogError($"City not found for id {cityId}.");
				return NotFound("City not found.");
			}

			try
			{
				var helper = new WeatherHelper();
				//DarkSky requires the lat/lng of the city so we need to get
				//that using the city and state from a geocoding service
				if (String.IsNullOrEmpty(chosenCity.OlsonTimeZone))
				{
					var cityHelper = new CityHelper(_logger, _context);
					chosenCity = cityHelper.GetForwardGeocodeForCity(chosenCity, _appSettings.Value.OpenCageApiKey);
				}

				var dateToCheck = DateTime.Parse(_appSettings.Value.DateToCheck);
				var dateToCheckInUtc = helper.GetUtcVersionOfDate(chosenCity.OlsonTimeZone, dateToCheck); ;
				var unixDateTime = helper.GetUnixTimeStampForDate(dateToCheckInUtc);

				var body = await helper.GetWeatherForCityAtTime(chosenCity.Latitude,
					chosenCity.Longitude,
					unixDateTime,
					_appSettings.Value.ApiKey);
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
