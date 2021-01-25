using Microsoft.Extensions.Logging;
using OpenCage.Geocode;
using System.Collections.Generic;
using WeatherFetchAPI.Models;
using System.Linq;
using TimeZoneConverter;

namespace WeatherFetchAPI.Helpers
{
	public class CityHelper
	{
		private readonly ILogger _logger;
		private readonly WeatherFetchContext _context;

		public CityHelper(ILogger logger, WeatherFetchContext context)
		{
			_logger = logger;
			_context = context;
		}

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

		/***
		 * Use the OpenCage API to get the forward geocode info for a given city/state
		 */
		public City GetForwardGeocodeForCity(City city, string openCageKey)
		{
			var geocoder = new Geocoder(openCageKey);
			var geoData = geocoder.Geocode($"{city.Name}, {city.State}");


			if (geoData.Results.Count() < 1) {
				_logger.LogError($"Geographic information not found for {city.Name}, {city.State}.");
				return null;
			}

			var firstResult = geoData.Results.First();
			city.OlsonTimeZone = firstResult.Annotations.Timezone.Name;
			city.Latitude = firstResult.Geometry.Latitude;
			city.Longitude = firstResult.Geometry.Longitude;
			_context.SaveChanges();
			return city;
		}
	}
}
