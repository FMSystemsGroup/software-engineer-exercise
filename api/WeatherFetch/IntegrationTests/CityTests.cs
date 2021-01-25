using System;
using Xunit;
using WeatherFetchAPI;
using WeatherFetchAPI.Models;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace IntegrationTests
{
	public class CityTests
	{
		private readonly HttpClient _client;

		public CityTests()
		{
			var server = new TestServer(new WebHostBuilder()
				.UseEnvironment("Development")
				.UseStartup<Startup>());
			_client = server.CreateClient();
		}

		[Theory]
		[InlineData("GET", 4)]
		public async Task CityListCount(string method, int? resultCount = null)
		{
			//Arrange
			var request = new HttpRequestMessage(new HttpMethod(method), $"api/City");

			//Act
			var response = await _client.SendAsync(request);

			//Assert
			response.EnsureSuccessStatusCode();
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);
			var responseString = response.Content.ReadAsStringAsync().Result;

			var refList = JsonConvert.DeserializeObject<List<City>>(responseString);
			Assert.Equal(resultCount, refList.Count);
		}

	}
}
