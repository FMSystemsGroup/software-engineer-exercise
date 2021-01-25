namespace WeatherFetchAPI.Models
{
	public class City
	{
		public int id { get; set; }
		public string Name { get; set; }
		public string State { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public string OlsonTimeZone { get; set; }
	}
}
