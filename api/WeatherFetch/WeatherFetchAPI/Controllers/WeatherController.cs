using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using WeatherFetchAPI.Models;
using System.Net.Http;
using System;

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

			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri($"https://api.darksky.net/forecast/{_appSettings.Value.ApiKey}/42.3601,-71.0589"),
			};

			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				return body;
			}
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
