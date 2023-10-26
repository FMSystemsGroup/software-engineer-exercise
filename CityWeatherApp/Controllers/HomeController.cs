using CityWeatherApp.Models;
using CityWeatherApp.Service.Contract;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Text;

namespace CityWeatherApp.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICityWeatherService _cityWeatherService;       

        public HomeController(ILogger<HomeController> logger, ICityWeatherService cityWeatherService)
        {
            _logger = logger;
            _cityWeatherService = cityWeatherService;               
        }

        /// <summary>
        /// This action returns the index view of the home page with a list of city names
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Begin GetCityNames");            

            CityViewModel cityViewModel = await _cityWeatherService.GetCityNames();
            _logger.LogInformation("End GetCityNames");

            return View(cityViewModel);
        }

        /// <summary>
        /// This action returns a JSON result with the weather data for a selected city
        /// </summary>
        /// <param name="selectedCity">a selected city</param>
        /// <returns>a JSON result</returns>
        public async Task<JsonResult> GetWeatherByCity(string selectedCity)
        {
            _logger.LogInformation("Begin GetWeatherByCity");
            CityWeatherViewModel model = await _cityWeatherService.GetWeatherByCity(selectedCity);
            _logger.LogInformation("End GetWeatherByCity");
            return Json(model);
        }        
    }
}