using System;
using Xunit;
using WeatherFetchAPI.Models;
using WeatherFetchAPI.Controllers;
using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace UnitTests
{
	public class WeatherTests
	{
		private readonly WeatherController _weatherController;
		private readonly List<City> _cityList;

		public WeatherTests()
		{
			var settings = new AppSettings()
			{
				Cities = new List<City>()
			};

			settings.Cities.Add(
				new City()
					{
						id=0,
						Name="TestCity"
					}
			);
			_cityList = settings.Cities;


			var options = Options.Create<AppSettings>(settings);


			_weatherController = new WeatherController(options, null);
		}

		[Fact]
		public void InvalidIdReturnsEmptyCity()
		{
			//Arrange
			var cityId = 2;
			var cities = _cityList;

			//Act
			var city = _weatherController.GetCityById(cityId, cities);

			//Assert
			Equals(-1, city.id);

		}

		[Fact]
		public void ValidIdReturnsPopulatedCity()
		{
			//Arrange
			var cityId = 0;
			var cities = _cityList;

			//Act
			var city = _weatherController.GetCityById(cityId, cities);

			//Assert
			Equals("TestCity", city.Name);

		}
	}
}
