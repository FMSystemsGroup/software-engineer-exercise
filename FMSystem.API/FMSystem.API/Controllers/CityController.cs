using FMSystem.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMSystem.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CityController : ControllerBase
	{
		//private static readonly string[] cities = new[]
		//{
		//	"Phoenix, AZ", "Raleigh, NC", "Saint John, NB (Canada)", "San Diego, CA"
		//};

		private readonly ILogger<CityController> _logger;
		private readonly ICityService _cityService;

		public CityController(ICityService cityService, ILogger<CityController> logger)
		{
			_logger = logger;
			_cityService = cityService;
		}

		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				var result = _cityService.get();
				return Ok(result);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}
	}
}
