using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherWeb.Models;
using WeatherWeb.Services;

namespace WeatherWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILocationService _locationService;
        private readonly IDarkSkyService _darkSkyService;

        public IEnumerable<Location> Locations { get; private set; }

        public IndexModel( ILocationService locationService, IDarkSkyService darkSkyService)
        {
            _locationService = locationService;
            _darkSkyService = darkSkyService;
        }

        /// <summary>
        /// Call LocationService to load cities collection to Locations property
        /// </summary>
        /// <returns></returns>
        public async Task OnGetAsync()
        {
            try
            {
               Locations = await _locationService.GetLocationsAsync();
            }
            catch(HttpRequestException)
            {
                Locations = Array.Empty<Location>();
            }
        }

        /// <summary>
        /// Call DarkSkyService to retreive weather data
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<ActionResult>OnGetWeatherData(string param)
        {
            try
            {
                var weather = await _darkSkyService.GetWeatherAsync(param);

                return new JsonResult(weather);
;            } 
            catch(HttpRequestException)
            {
                return NotFound();
            }
        }
    }
}
