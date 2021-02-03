using Microsoft.Extensions.Logging;
using OpenCage.Geocode;
using System.Collections.Generic;
using WeatherFetchAPI.Models;
using System.Linq;

namespace WeatherFetchAPI.Dependencies
{
	public interface ICityHelper
	{
		public City GetForwardGeocodeForCity(City city, string openCageKey, ILogger logger);
	}

	public class CityHelper : ICityHelper
	{
		private readonly WeatherFetchContext _context;

		public CityHelper(WeatherFetchContext context)
		{
			_context = context;
		}

		/***
		 * Use the OpenCage API to get the forward geocode info for a given city/state
		 */
		public City GetForwardGeocodeForCity(City city, string openCageKey, ILogger logger)
		{
			var geocoder = new Geocoder(openCageKey);
			var geoData = geocoder.Geocode($"{city.Name}, {city.State}");


			if (geoData.Results.Count() < 1) {
				logger.LogError($"Geographic information not found for {city.Name}, {city.State}.");
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
