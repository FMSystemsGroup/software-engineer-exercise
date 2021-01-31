using FMSystems.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.Swagger;
//using Swashbuckle.AspNetCore.Annotations;
//using Swashbuckle.AspNetCore.Filters;
using Serilog;
using FMSystems.Server.Support;
using FMSystems.Services;
using FMSystems.Services.Interfaces;
using FMSystems.Shared.DTO;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text.Json;
using DarkSkyApi.Models;

namespace FMSystems.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly AppSettings appSettings;
        private readonly ICityService cityService;
        private readonly IWeatherService weatherService;


        public WeatherForecastController(IOptions<AppSettings> appSettings, ICityService cityService, IWeatherService weatherService)
        {
            this.appSettings = appSettings.Value;
            this.cityService = cityService;
            this.weatherService = weatherService;
        }



        /// <summary>
        /// Retrieve a list of cities
        /// </summary>
        /// <returns>IEnumerable City List</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(typeof(IEnumerable<City>))]
        [Route("GetCityList")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCityList()
        {
            IEnumerable<City> cities = new List<City>();
            try
            {
                cities = await cityService.GetCities();
                if ((cities == null) || (cities.Count() <= 0))
                {
                    return NotFound();
                }
                else
                {
                    return Ok(cities);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(string.Format("Exception in GetCityList: {0}", ex.Message));
            }

        }


        /// <summary>
        /// Gets a Weather Forecast for specifc hour in the day
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        /// <param name="apikey"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(typeof(WeatherForecast))]
        [Route("GetCityWeather")]
        [HttpGet]
        public async Task<ActionResult<WeatherForecast>> GetCityWeather([FromQuery]int id, [FromQuery] DateTime date, [FromQuery] string apikey = null)
        {
            if (string.IsNullOrEmpty(apikey) == true)
            {
                apikey = appSettings.DarkSkyApiKey;
            }

            if ((id <= 0) || (date == null) || (string.IsNullOrEmpty(apikey) == true))
            {
                return BadRequest("Invalid Parameters");
            }

            var cities = await cityService.GetCities();
            var city = cities.ToList<City>().Find(c => c.Id == id);


            var weather = await Task.Run(() => weatherService.GetWeather(apikey, city, date));
            if(weather!= null)
            {
                var hours = weather.Hourly.Hours;
                var hourDataPoint = await Task.Run(() => weatherService.GetForecastForHour(date.Hour, hours.ToList()));

                if (hourDataPoint != null)
                {
                    var forecast = new WeatherForecast()
                    {
                        Date = date,
                        Temperature = hourDataPoint.Temperature,
                        UVIndex = hourDataPoint.UVIndex,
                        Summary = hourDataPoint.Summary
                    };

                    return Ok(forecast);
                }
            }

            return BadRequest("The forecast could not be retireved");
        }
    }
}
