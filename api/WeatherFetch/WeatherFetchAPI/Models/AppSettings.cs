using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherFetchAPI.Models
{
	public class AppSettings
	{
		public List<City> Cities { get; set; }
		public string ApiKey { get; set; }
		public string OpenCageApiKey { get; set; }
		public string DateToCheck { get; set; }
	}
}
