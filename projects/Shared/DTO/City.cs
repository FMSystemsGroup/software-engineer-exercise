using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMSystems.Shared.DTO
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string TimeZoneId { get; set; }
        public string Display
        {
            get { return string.Format("{0} {1}", Name, State); }
        }


    }
}
