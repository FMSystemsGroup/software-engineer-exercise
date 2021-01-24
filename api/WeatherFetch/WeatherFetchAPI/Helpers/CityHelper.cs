using System.Collections.Generic;
using WeatherFetchAPI.Models;

namespace WeatherFetchAPI.Helpers
{
	public static class CityHelper
	{
		/***
		 * Selects the city record that matches the given id.
		 * Returns a City object with -1 for the id value if a matching
		 * city is not found.
		 ***/
		public static City GetCityById(int cityId, List<City> cityList) {
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
