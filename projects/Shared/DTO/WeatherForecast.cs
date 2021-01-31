using System;
using System.Collections.Generic;
using System.Text;

namespace FMSystems.Shared.DTO
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public float Temperature { get; set; }
        public string Summary { get; set; }
        public float UVIndex { get; set; }
        public string Display
        {
            get 
            {
                return string.Format("On {0} the forecast is {1} : Temperature: {2}, UV index: {3}", Date.ToLongDateString(), Summary, Temperature, UVIndex);            
            }
        }

  
    }
}
