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

namespace IntegrationTests
{
	public class WeatherTests
	{
		private readonly HttpClient _client;

		public WeatherTests()
		{
			var server = new TestServer(new WebHostBuilder()
				.UseEnvironment("Integration")
				.UseStartup<Startup>());
			_client = server.CreateClient();
		}

		[Theory]
		[InlineData("GET", 2)]
		public async Task ErrorReturnedForBadCityId(string method, int? cityId = null)
		{
			//Arrange
			var request = new HttpRequestMessage(new HttpMethod(method), $"api/Weather/ForCity/{cityId}");

			//Act
			var response = await _client.SendAsync(request);

			//Assert
			Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
		}

	}
}
