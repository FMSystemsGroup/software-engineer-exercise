using CityWeatherApp.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace CityWeatherApp.Service.Contract
{
    /// <summary>
    /// This interface defines the contract for the city weather service, which provides methods for getting city 
    /// names and weather information from external APIs
    /// </summary>
    public interface ICityWeatherService
    {
        /// <summary>
        /// This method returns a task that represents the asynchronous operation of getting a 
        /// CityViewModel object that contains a list of cities from the CityAPI
        /// </summary>
        /// <returns></returns>
        Task<CityViewModel> GetCityNames();

        /// <summary>
        /// This method returns a task that represents the asynchronous operation of getting a CityWeatherViewModel object that contains the weather 
        /// information for a given city from the WeatherVisualCrossingAPI
        /// </summary>
        /// <param name="selectedCity"></param>
        /// <returns></returns>
        Task<CityWeatherViewModel> GetWeatherByCity(string selectedCity);
    }
}
