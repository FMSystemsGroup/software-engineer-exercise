using OpenCage.Geocode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TimeZoneConverter;

namespace WeatherFetchAPI.Helpers
{
	public class WeatherHelper
	{
		private readonly Uri _darkSkyUri;

		public WeatherHelper(string apiKey)
		{
			_darkSkyUri = new Uri($"https://api.darksky.net/forecast/{apiKey}/");
		}

		/***
		 * Use the OpenCage API to get the forward geocode info for a given city/state
		 */
		public GeocoderResponse GetForwardGeocodeForCity(string cityName, string cityStateCode, string openCageKey)
		{
			var geocoder = new Geocoder(openCageKey);
			return geocoder.Geocode($"{cityName}, {cityStateCode}");
		}

		/***
		 * Use the DarkSky API to get the weather for a given latitude, longitude and unix time stamp
		 */
		public async Task<string> GetWeatherForCityAtTime(double lat, double lon, long unixTime)
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri($"{_darkSkyUri}{lat},{lon},{unixTime}?exclude=hourly,flags,daily")
			};

			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				return body;
			}
		}

		/***
		 * Get a DateTime object in UTC with the hour set to match a given location's hour
		 * plus the offset difference
		 */
		public DateTime GetOffset(string locationName, DateTime time)
		{
			var tzInfo = TZConvert.GetTimeZoneInfo(locationName);
			var offset = tzInfo.GetUtcOffset(time);
			var positiveHours = -1 * offset.Hours;

			return new DateTime(time.Year,
				time.Month,
				time.Day,
				time.Hour + positiveHours,
				time.Minute,
				time.Second, DateTimeKind.Utc);
		}

		/***
		 * Converts a DateTime object into a unix time stamp
		 */
		public long GetUnixTimeStampForDate(DateTime dateToConvert)
		{
			var offset = new DateTimeOffset(dateToConvert);
			return offset.ToUnixTimeSeconds();
		}
	}
}
