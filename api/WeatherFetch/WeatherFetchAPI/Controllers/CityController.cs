using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WeatherFetchAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeatherFetchAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CityController : ControllerBase
	{
		private readonly IOptions<AppSettings> _appSettings;
		private readonly ILogger _logger;
		private readonly WeatherFetchContext _context;

		public CityController(IOptions<AppSettings> settings, ILogger<CityController> logger, WeatherFetchContext context) {
			_context = context;
			_appSettings = settings;
			_logger = logger;
		}

		// GET: api/<CityController>
		[HttpGet]
		public IEnumerable<City> Get()
		{
			var cityList =  _context.Cities.ToList();

			//if there are no cities in the database, populate it with the app settings
			if (cityList.Count < 1)
			{
				_logger.LogInformation("Populating cities from app settings.");
				foreach (var city in _appSettings.Value.Cities)
				{
					_context.Cities.Add(city);
					_context.SaveChanges();
					cityList.Add(city);
				}

			}

			return cityList;
		}
	}
}
