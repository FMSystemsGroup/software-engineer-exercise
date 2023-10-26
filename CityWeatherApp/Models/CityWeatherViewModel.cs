using Newtonsoft.Json;

namespace CityWeatherApp.Models
{
    public class CityWeatherViewModel
    {        
        public string Description { get; set; }
        
        public string Temperature { get; set; }
        
        public string UVIndex { get; set; }
    }
}
