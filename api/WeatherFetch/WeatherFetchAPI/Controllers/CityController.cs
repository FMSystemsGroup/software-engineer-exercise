using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WeatherFetchAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeatherFetchAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CityController : ControllerBase
	{
		private readonly IOptions<AppSettings> _appSettings;

		public CityController(IConfiguration configuration, IOptions<AppSettings> settings) {
			_appSettings = settings;
		}

		// GET: api/<CityController>
		[HttpGet]
		public IEnumerable<City> Get()
		{
			var cities = _appSettings.Value.Cities;
			return cities;
		}
	}
}
