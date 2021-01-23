using System;
using Xunit;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using OpenCage.Geocode;
using WeatherFetchAPI.Models;
using WeatherFetchAPI.Helpers;

namespace UnitTests
{
	public class CityTests
	{
		private readonly List<City> _cityList;

		public CityTests()
		{
			var Cities = new List<City>();
			Cities.Add(
				new City()
					{
						id=0,
						Name="TestCity"
					}
			);

			_cityList = Cities;
		}

		[Fact]
		public void InvalidIdReturnsEmptyCity()
		{
			//Arrange
			var cityId = 2;
			var cities = _cityList;

			//Act
			var city = CityHelper.GetCityById(cityId, cities);

			//Assert
			Assert.Equal(-1, city.id);

		}

		[Fact]
		public void ValidIdReturnsPopulatedCity()
		{
			//Arrange
			var cityId = 0;
			var cities = _cityList;

			//Act
			var city = CityHelper.GetCityById(cityId, cities);

			//Assert
			Assert.Equal("TestCity", city.Name);

		}
	}
}
