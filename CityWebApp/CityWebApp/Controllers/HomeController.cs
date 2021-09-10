using CityWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CityWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<CityModel> cities = new List<CityModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44340/api/CitiesCollection"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cities = JsonConvert.DeserializeObject<List<CityModel>>(apiResponse);
                }
            }
             return View(cities);
        }

        [HttpPost]
        public async Task<JsonResult> GetWeather(string city_name)
        {
            using (var httpClient = new HttpClient())
            {
                string lat="";
                string log="";
                switch (city_name)
                {
                    case "Phoenix, AZ":
                        lat = "33.4483771";
                        log = "-112.0740373";
                        break;
                    case "Raleigh, NC":
                        lat = "35.7795897";
                        log = "-78.6381787";
                        break;
                    case "Saint John, NB (Canada)":
                        lat = "45.273918";
                        log = "-66.067657";
                        break;
                    case "San Diego, CA":
                        lat = "32.715736";
                        log = "-117.161087";
                        break;

                }
                // using (var response = await httpClient.GetAsync("https://api.darksky.net/forecast/8185d7b75cac7ed56f583943e0519491/"+lat+","+log+",2018-07-04T12:00:00"))
               // Note: Please change the API key  below
                using (var response = await httpClient.GetAsync("https://api.darksky.net/forecast/111111111111111111111/"+lat+","+log+",2018-07-04T12:00:00"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return Json(apiResponse);
                }
            }
            //return Json("test success");
        }
    }
}
