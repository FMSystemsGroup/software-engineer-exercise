using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using WeatherFetchAPI.Models;
using System.Net.Http;

namespace WeatherFetchAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WeatherController : ControllerBase
	{
		private readonly IOptions<AppSettings> _appSettings;
		private readonly IHttpClientFactory _clientFactory;

		public WeatherController(IOptions<AppSettings> settings, IHttpClientFactory clientFactory) {
			_appSettings = settings;
			_clientFactory = clientFactory;
		}
		// GET: api/<WeatherController>
		[HttpGet("ForCity/{cityId}")]
		public async Task<ActionResult<string>> GetWeatherForCity(int cityId)
		{
			var chosenCity = GetCityById(cityId, _appSettings.Value.Cities);

			if (chosenCity.id == -1)
			{
				return NotFound();
			}

			return NotFound();
		}

		/***
		 * Selects the city record that matches the given id.
		 * Returns a City object with -1 for the id value if a matching
		 * city is not found.
		 ***/
		public City GetCityById(int cityId, List<City> cityList) {
			var chosenCity = new City()
			{
				id = -1
			};

			foreach (var city in cityList)
			{
				if (city.id == cityId)
				{
					chosenCity = city;
				}
			}

			return chosenCity;
		}
	}
}
