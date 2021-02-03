using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WeatherFetchAPI.Models;
using WeatherFetchAPI.Dependencies;
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
		private readonly ICityHelper _cityHelper;
		private readonly IWeatherHelper _weatherHelper;

		public WeatherController(IOptions<AppSettings> settings, ILogger<WeatherController> logger, WeatherFetchContext context, ICityHelper cityHelper, IWeatherHelper weatherHelper) {
			_appSettings = settings;
			_logger = logger;
			_context = context;
			_cityHelper = cityHelper;
			_weatherHelper = weatherHelper;
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
				//DarkSky requires the lat/lng of the city so we need to get
				//that using the city and state from a geocoding service
				if (String.IsNullOrEmpty(chosenCity.OlsonTimeZone))
				{
					chosenCity = _cityHelper.GetForwardGeocodeForCity(chosenCity, _appSettings.Value.OpenCageApiKey, _logger);
				}

				var dateToCheck = DateTime.Parse(_appSettings.Value.DateToCheck);
				var dateToCheckInUtc = _weatherHelper.GetUtcVersionOfDate(chosenCity.OlsonTimeZone, dateToCheck); ;
				var unixDateTime = _weatherHelper.GetUnixTimeStampForDate(dateToCheckInUtc);

				var body = await _weatherHelper.GetWeatherForCityAtTime(chosenCity.Latitude,
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
