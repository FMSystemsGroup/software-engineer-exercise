using Xunit;
using WeatherFetchAPI;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;

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
			var responseText = await response.Content.ReadAsStringAsync();
			Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
			Assert.Equal("City not found.", responseText);
		}

		[Theory]
		[InlineData("GET", 1)]
		public async Task ValidCityWithBadDataReturnsNotFound(string method, int? cityId = null)
		{
			//Arrange
			var request = new HttpRequestMessage(new HttpMethod(method), $"api/Weather/ForCity/{cityId}");

			//Act
			var response = await _client.SendAsync(request);

			//Assert
			var responseText = await response.Content.ReadAsStringAsync();
			Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
			Assert.Equal("Geographic information for city not found.", responseText);
		}

		[Theory]
		[InlineData("GET", 0)]
		public async Task ValidCityGetsWeatherResult(string method, int? cityId = null)
		{
			//Arrange
			var request = new HttpRequestMessage(new HttpMethod(method), $"api/Weather/ForCity/{cityId}");

			//Act
			var response = await _client.SendAsync(request);

			//Assert
			response.EnsureSuccessStatusCode();
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		}

	}
}
