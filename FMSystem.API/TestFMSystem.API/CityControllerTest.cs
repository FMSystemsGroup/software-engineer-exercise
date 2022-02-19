using System;
using Xunit;
using FMSystem.API.Controllers;
using FMSystem.API.Services;
using Microsoft.Extensions.Logging;
using RestSharp;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using FMSystem.API.Models;
using NSubstitute;
using Microsoft.AspNetCore.Mvc;

namespace TestFMSystem.API
{

	public class CityControllerTest
	{
		private readonly CityController _cityController;
		private readonly ICityService _cityService;
		private readonly ILogger<CityController> _logger;

		public CityControllerTest()
		{
            _cityService = Substitute.For<ICityService>();
            _logger = Substitute.For<ILogger<CityController>>();

            _cityController = new CityController(_cityService, _logger);

		}
		[Fact]
        public void Get_Returns_City_Collection_On_Success()
        {
            //var cities = new[] { "Phoenix, AZ", "Raleigh, NC", "Saint John, NB (Canada)", "San Diego, CA" };
            var cities = new List<CityModel>() { new CityModel(){
                City = "Kathmandu"
                }
            };
			_cityService.get().Returns<IEnumerable<CityModel>>(cities);
            var okResult  = _cityController.Get();           
            Assert.IsType<OkObjectResult>(okResult as ObjectResult);
            var result = okResult as OkObjectResult;
            Assert.Equal(cities, result.Value);
		}

        [Fact]
        public void Get_Returns_500_On_Service_Exception()
        {
            var cities = new List<CityModel>() { new CityModel(){
                City = "Kathmandu"
                }
            };
            _cityService.get().Returns(x => { throw new Exception(); });

            var response = _cityController.Get();
            var result = response as StatusCodeResult;
            Assert.Equal(500, result.StatusCode);
        }
    }
}
