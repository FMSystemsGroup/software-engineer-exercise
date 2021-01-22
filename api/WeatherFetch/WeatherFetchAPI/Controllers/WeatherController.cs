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
			var cityList = _appSettings.Value.Cities;
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

			if (chosenCity.id == -1)
			{
				return NotFound();
			}

			return "";
		}
	}
}
