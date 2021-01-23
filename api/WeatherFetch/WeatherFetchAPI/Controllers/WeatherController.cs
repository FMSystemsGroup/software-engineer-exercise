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

namespace WeatherFetchAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WeatherController : ControllerBase
	{
		private readonly IOptions<AppSettings> _appSettings;

		public WeatherController(IOptions<AppSettings> settings) {
			_appSettings = settings;
		}
		// GET: api/<WeatherController>
		[HttpGet("ForCity/{cityId}")]
		public async Task<ActionResult<string>> GetWeatherForCity(int cityId)
		{
			var chosenCity = CityHelper.GetCityById(cityId, _appSettings.Value.Cities);

			if (chosenCity.id == -1)
			{
				return NotFound();
			}

			try
			{
				var helper = new WeatherHelper(_appSettings.Value.ApiKey);
				//DarkSky requires the lat/lng of the city so we need to get
				//that using the city and state from a geocoding service
				var geoData = helper.GetForwardGeocodeForCity(chosenCity.Name, chosenCity.State, _appSettings.Value.OpenCageApiKey);

				if (geoData.Results.Count() < 1) {
					return NotFound();
				}

				var firstResult = geoData.Results.First();

				var time = DateTime.Parse(_appSettings.Value.DateToCheck);
				var offsetTime = helper.GetOffset(firstResult.Annotations.Timezone.Name, time); ;
				var unixDateTime = helper.GetUnixTimeStampForDate(offsetTime);

				var body = await helper.GetWeatherForCityAtTime(firstResult.Geometry.Latitude,
					firstResult.Geometry.Longitude,
					unixDateTime);

				return body;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}
	}
}
