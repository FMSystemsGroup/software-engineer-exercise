using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WeatherWeb.Models;

namespace WeatherWeb.Services
{
    public class LocationService : ILocationService
    {
        public HttpClient Client { get; }
        public IConfiguration Configuration { get; }
        public LocationService(IConfiguration configuration, HttpClient client)
        {
            Configuration = configuration;
            //set Weather api base address from config file
            client.BaseAddress = new Uri(Configuration["WeatherApiBaseAddress"]);
            Client = client;
        }

        /// <summary>
        /// Call Locations Api to get locations collection
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Location>> GetLocationsAsync()
        {
            var response = await Client.GetAsync("/api/locations");

            return  await response.Content.ReadFromJsonAsync<IEnumerable<Location>>();
        }
    }
}

