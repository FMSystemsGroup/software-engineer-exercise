using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherWeb.Models
{
    public class Weather
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Timezone { get; set; }
        public Currently Currently { get; set; }
    }

    public class Currently
    {
        public int Time { get; set; }
        public string Summary { get; set; }
        public float Temperature { get; set; }
        public int UvIndex { get; set; }
    }
}
