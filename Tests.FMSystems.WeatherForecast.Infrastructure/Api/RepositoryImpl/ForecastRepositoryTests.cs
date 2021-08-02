using FMSystems.WeatherForecast.Domain.Repository;
using FMSystems.WeatherForecast.Infrastructure.Api.RepositoryImpl;
using FMSystems.WeatherForecast.Infrastructure.ApiClients.DarkSky;
using FMSystems.WeatherForecast.Infrastructure.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Tests.FMSystems.WeatherForecast.Infrastructure
{
    public class ForecastRepositoryTest
    {
        private readonly Mock<IOptions<DarkSkyOptions>> _darkSkyOptions = new Mock<IOptions<DarkSkyOptions>>();
        private readonly Mock<IDarkSkyApiClient> _darkSkyApiClient = new Mock<IDarkSkyApiClient>();
        private readonly Mock<ILogger<ForecastRepository>> _mockLogger = new Mock<ILogger<ForecastRepository>>();

        private readonly ForecastRepository _repository;

        public ForecastRepositoryTest()
        {
            _repository = new ForecastRepository(_mockLogger.Object, _darkSkyApiClient.Object, _darkSkyOptions.Object);
        }

        #region mocks
        private readonly DarkSkyOptions _goodOptions = new DarkSkyOptions
        {
            ApiKey = "Any_Api_Key"
        };

        private static long _validTime = 1530687600;
        private static string _validLat = "34.444";
        private static string _validLon = "3.333";
        private static string _validIcon = "falling stars";
        private static int _validOffset = 5;
        private static int _validTemperature = 104;
        private static int _validUvIndex = 4;

        private static HourlyData _expectedHourlyData = new HourlyData() { Icon = _validIcon, Temperature = _validTemperature, Time = _validTime, Summary = "Thunderstorm", UvIndex = _validUvIndex };

        private readonly DarkSkyResponse _goodDarkSkyResponse = new DarkSkyResponse
        {
            Offset = _validOffset,
            Latitude = _validLat,
            Longitude = _validLon,
            Hourly = new Hourly()
            {
                Icon = "sunny icon text",
                Summary = "sun, sun everywhere",
                Data = new List<HourlyData>()
                {
                    new HourlyData() { Icon = "rain icon", Temperature = 101, Time = 1530676800, Summary = "Thunderstorm", UvIndex = 1 },
                    new HourlyData() { Icon = "rain icon", Temperature = 102, Time = 1530680400, Summary = "Thunderstorm", UvIndex = 2 },
                    new HourlyData() { Icon = "rain icon", Temperature = 103, Time = 1530684000, Summary = "Thunderstorm", UvIndex = 3 },
                    _expectedHourlyData,
                    new HourlyData() { Icon = "rain icon", Temperature = 105, Time = 1530691200, Summary = "Thunderstorm", UvIndex = 5 },
                    new HourlyData() { Icon = "rain icon", Temperature = 106, Time = 1530694800, Summary = "Thunderstorm", UvIndex = 6 },
                    new HourlyData() { Icon = "rain icon", Temperature = 107, Time = 1530698400, Summary = "Thunderstorm", UvIndex = 7 },
                    new HourlyData() { Icon = "rain icon", Temperature = 108, Time = 1530702000, Summary = "Thunderstorm", UvIndex = 8 },
                    new HourlyData() { Icon = "rain icon", Temperature = 109, Time = 1530705600, Summary = "Thunderstorm", UvIndex = 9 },
                    new HourlyData() { Icon = "rain icon", Temperature = 112, Time = 1530709200, Summary = "Thunderstorm", UvIndex = 10 },
                    new HourlyData() { Icon = "rain icon", Temperature = 120, Time = 1530712800, Summary = "Thunderstorm", UvIndex = 11 },
                    new HourlyData() { Icon = "rain icon", Temperature = 130, Time = 1530716400, Summary = "Thunderstorm", UvIndex = 12 },
                    new HourlyData() { Icon = "rain icon", Temperature = 140, Time = 1530720000, Summary = "Thunderstorm", UvIndex = 1 },
                    new HourlyData() { Icon = "rain icon", Temperature = 150, Time = 1530723600, Summary = "Thunderstorm", UvIndex = 2 },
                    new HourlyData() { Icon = "rain icon", Temperature = 160, Time = 1530727200, Summary = "Thunderstorm", UvIndex = 3 },
                    new HourlyData() { Icon = "rain icon", Temperature = 170, Time = 1530730800, Summary = "Thunderstorm", UvIndex = 4 },
                    new HourlyData() { Icon = "rain icon", Temperature = 180, Time = 1530734400, Summary = "Thunderstorm", UvIndex = 5 },
                    new HourlyData() { Icon = "rain icon", Temperature = 190, Time = 1530738000, Summary = "Thunderstorm", UvIndex = 6 },
                    new HourlyData() { Icon = "rain icon", Temperature = 10, Time = 1530741600, Summary = "Thunderstorm", UvIndex = 7 },
                    new HourlyData() { Icon = "rain icon", Temperature = 20, Time = 1530745200, Summary = "Thunderstorm", UvIndex = 8 },
                    new HourlyData() { Icon = "rain icon", Temperature = 30, Time = 1530748800, Summary = "Thunderstorm", UvIndex = 9 },
                    new HourlyData() { Icon = "rain icon", Temperature = 40, Time = 1530752400, Summary = "Thunderstorm", UvIndex = 10 },
                    new HourlyData() { Icon = "rain icon", Temperature = 50, Time = 1530756000, Summary = "Thunderstorm", UvIndex = 11 },
                    new HourlyData() { Icon = "rain icon", Temperature = 60, Time = 1530759600, Summary = "Thunderstorm", UvIndex = 12 }

                }
            }
        };
        private readonly DarkSkyResponse _badDarkSkyResponse = new DarkSkyResponse
        {
            Offset = 5,
            Latitude = "34.444",
            Longitude = "3.333",
            Hourly = null
        };
        #endregion

        #region Constructor Tests

        [Fact]
        public void Constructor_WithNullLogger_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new ForecastRepository(null, _darkSkyApiClient.Object, _darkSkyOptions.Object));
        [Fact]
        public void Constructor_WithNullDarkSkyOptions_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new ForecastRepository(_mockLogger.Object, null, _darkSkyOptions.Object));
        [Fact]
        public void Constructor_WithNullDarkSkyApiClient_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new ForecastRepository(_mockLogger.Object, _darkSkyApiClient.Object, null));

        #endregion

        #region GetForecastAsync
        [Fact]
        public async Task GetForecastAsync_Successful()
        {
            // Arrange
            _darkSkyOptions.Reset();
            _darkSkyApiClient.Reset();

            _darkSkyOptions
                .Setup(config => config.Value)
                .Returns(_goodOptions);

            _darkSkyApiClient
                .Setup(x => x.ForecastAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .ReturnsAsync(_goodDarkSkyResponse);

            // Act
            var result = await _repository.GetForecastAsync(1, 2, null);

            // Assert
            Assert.Equal(_validIcon, result.Icon);
            Assert.Equal(_validOffset, result.Offset);
            Assert.Equal(_expectedHourlyData.Summary, result.Summary);
            Assert.Equal(_expectedHourlyData.Temperature, result.TemperatureF);

            Assert.Equal(DateTimeOffset.FromUnixTimeSeconds(_validTime).ToUniversalTime(), result.DateTimeUTC.ToUniversalTime());
            Assert.Equal(DateTimeOffset.FromUnixTimeSeconds(_validTime).ToUniversalTime(), result.DateTimeLocal.ToUniversalTime());
            Assert.Equal(result.DateTimeUTC.ToUniversalTime(), result.DateTimeLocal.ToUniversalTime());

            Assert.Equal(_validOffset, result.Offset);
            Assert.Equal(_validUvIndex, result.UVIndex);
            Assert.Equal(_validTemperature, result.TemperatureF);
        }
        [Fact]
        public async Task GetForecastAsync_SuccessfulButWithNoForecasts()
        {
            // Arrange
            _darkSkyOptions.Reset();
            _darkSkyApiClient.Reset();

            _darkSkyOptions
                .Setup(config => config.Value)
                .Returns(_goodOptions);

            _darkSkyApiClient
                .Setup(x => x.ForecastAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .ReturnsAsync(_badDarkSkyResponse);

            // Act
            var result = await _repository.GetForecastAsync(1, 2, null);

            // Assert
            Assert.Equal(_validOffset, result.Offset);

            Assert.Equal(DateTimeOffset.FromUnixTimeSeconds(_validTime).ToUniversalTime(), result.DateTimeUTC.ToUniversalTime());
            Assert.Equal(DateTimeOffset.FromUnixTimeSeconds(_validTime).ToUniversalTime(), result.DateTimeLocal.ToUniversalTime());
            Assert.Equal(result.DateTimeUTC.ToUniversalTime(), result.DateTimeLocal.ToUniversalTime());
        }
        [Fact]
        public async Task GetForecastAsync_WithInvalidDateThrows()
        {
            // Arrange
            _darkSkyOptions.Reset();
            _darkSkyApiClient.Reset();

            _darkSkyOptions
                .Setup(config => config.Value)
                .Returns(_goodOptions);

            _darkSkyApiClient
                .Setup(x => x.ForecastAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .ThrowsAsync(new Exception());

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _repository.GetForecastAsync(1, 2, DateTimeOffset.FromUnixTimeSeconds(-62135596800).DateTime));
        }
        #endregion
    }
}