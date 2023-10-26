using CityWeatherApp.Models;
using CityWeatherApp.Service.Contract;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;

namespace CityWeatherApp.Service
{
    /// <summary>
    /// This class implements the ICityWeatherService interface, which defines the 
    /// methods for getting city names and weather information from external APIs. 
    /// It uses dependency injection to receive an IConfiguration and an 
    /// IHttpClientFactory instance in the constructor. It then uses these instances 
    /// to create HTTP requests and read the configuration values.
    /// </summary>
    public class CityWeatherService : ICityWeatherService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// The constructor that receives the IConfiguration and IHttpClientFactory instances as parameters
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="clientFactory"></param>
        public CityWeatherService(IConfiguration configuration, IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory; 
            _configuration = configuration; 
        }

        /// <summary>
        /// This method returns a CityViewModel object that contains a list of cities from the CityAPI
        /// </summary>
        /// <returns></returns>
        public async Task<CityViewModel> GetCityNames()
        {
            string uri = "api/cities";
            HttpClient client = _clientFactory.CreateClient(name: "CityAPI");
            HttpRequestMessage request = new(method: HttpMethod.Get, requestUri: uri);
            HttpResponseMessage response = await client.SendAsync(request);
            IEnumerable<City>? model = await response.Content.ReadFromJsonAsync<IEnumerable<City>>();


            CityViewModel cityViewModel = new CityViewModel();
            cityViewModel.Cities = model.Select(c => new SelectListItem
            {

                Value = c.ToString(),
                Text = c.ToString()
            });

            return cityViewModel;
        }

        /// <summary>
        /// This method returns a CityWeatherViewModel object that contains the weather information for a 
        /// given city from the WeatherVisualCrossingAPI
        /// </summary>
        /// <param name="selectedCity"></param>
        /// <returns></returns>
        public async Task<CityWeatherViewModel> GetWeatherByCity(string selectedCity)
        {            
            // Read the value of the api key
            string apiKey = _configuration["API_KEY"];

            DateTime dt = new DateTime(2008, 7, 4, 12, 0, 0);

            string stringDt = dt.ToString("s");

            //The URI of the WeatherVisualCrossingAPI endpoint with the selected city, date, and API key as
            //parameters
            string uri = $"VisualCrossingWebServices/rest/services/timeline/{selectedCity}/{stringDt}?key={apiKey}&unitGroup=us";
            HttpClient client = _clientFactory.CreateClient(name: "WeatherVisualCrossingAPI");
            HttpRequestMessage request = new(method: HttpMethod.Get, requestUri: uri);
            HttpResponseMessage response = await client.SendAsync(request);

            var tmp = await response.Content.ReadAsStringAsync();

            // Deserialize the content into a JObject
            JObject result = JObject.Parse(tmp);
            CityWeatherViewModel model = new CityWeatherViewModel
            {
                Description = (string)result.SelectToken("days[0].description"),
                Temperature = (string)result.SelectToken("days[0].hours[12].temp"),
                UVIndex = (string)result.SelectToken("days[0].hours[12].uvindex") ?? string.Empty
            };

            return model;
            
        }
    }
}
