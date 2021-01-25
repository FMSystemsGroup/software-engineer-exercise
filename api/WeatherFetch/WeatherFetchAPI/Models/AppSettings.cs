using System.Collections.Generic;

namespace WeatherFetchAPI.Models
{
	public class AppSettings
	{
		public List<City> Cities { get; set; }
		public string ApiKey { get; set; }
		public string OpenCageApiKey { get; set; }
		public string DateToCheck { get; set; }
		public string DatabaseFileName { get; set; }
	}
}
