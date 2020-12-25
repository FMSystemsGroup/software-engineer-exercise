using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WeatherWeb.Models;

namespace WeatherWeb.Services
{
    public class DarkSkyService : IDarkSkyService
    {
        public HttpClient Client { get; }
        public IConfiguration Configuration { get; }

        public DarkSkyService(IConfiguration configuration,HttpClient client)
        {
            Configuration = configuration;
            //set DarkSky api base address from config file
            client.BaseAddress = new Uri(Configuration["DarkSkyApi:BaseAddress"]);
            Client = client;
        }

        /// <summary>
        /// Call DarkSkyApi service to retreive weather data
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<Weather>GetWeatherAsync(string parameter)
        {
            //Retreive and set DarkSky Api configuration settings
            string param = "/forecast/" + Configuration["DarkSkyApi:ApiKey"] + "/" + parameter;
            var response = await Client.GetAsync(param);

            return await response.Content.ReadFromJsonAsync<Weather>();
        }

    }
}
