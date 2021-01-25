using OpenCage.Geocode;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TimeZoneConverter;

namespace WeatherFetchAPI.Helpers
{
	public class WeatherHelper
	{
		private readonly string _darkSkyUri = "https://api.darksky.net/forecast";

		/***
		 * Use the DarkSky API to get the weather for a given latitude, longitude and unix time stamp
		 */
		public async Task<string> GetWeatherForCityAtTime(double lat, double lon, long unixTime, string apiKey)
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri($"{_darkSkyUri}/{apiKey}/{lat},{lon},{unixTime}?exclude=hourly,flags,daily")
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
		public DateTime GetUtcVersionOfDate(string locationName, DateTime time)
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
