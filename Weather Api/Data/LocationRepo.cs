using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Model;

namespace WeatherApi.Data
{
    public class LocationRepo : ILocationRepo
    {
        /// <summary>
        /// Return Locations collection
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Location>> GetLocationsAsync()
        {

            var locations = await Task.Run(() => new List<Location>() 
            { 
                new Location {Id=1, City="Phoenix", State="AZ", Country="USA", Latitude=33.4483 , Longitude=-112.0740, UnixTime="1530730800"},
                new Location {Id=2, City="Raleigh", State="NC", Country="USA", Latitude=35.7877, Longitude=-78.6442, UnixTime="1530720000"},
                new Location {Id=3, City="Saint John", State="NB", Country="Canda", Latitude=45.2739, Longitude=-66.0676, UnixTime="1530716400"},
                new Location {Id=4, City="San Diego", State="CA", Country="USA", Latitude=32.7157, Longitude=-117.1611, UnixTime="1530730800"}
            });

            return locations;
        }
    }
}
