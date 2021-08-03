using FMSystems.WeatherForecast.Domain.Repository;
using FMSystems.WeatherForecast.Domain.Entity;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using FMSystems.WeatherForecast.Api.Controllers.Cities.CitiesForecast;

namespace Tests.FMSystems.WeatherForecast.Api.Controllers.Cities.Forecasts
{
    public class CityForecastControllerTest
    {
        private readonly Mock<ICityRepository> _mockCityRepository = new Mock<ICityRepository>();
        private readonly Mock<IForecastRepository> _mockForecastRepository = new Mock<IForecastRepository>();
        private readonly Mock<ILogger<CityForecastController>> _mockLogger = new Mock<ILogger<CityForecastController>>();

        private readonly CityForecastController _controller;

        public CityForecastControllerTest()
        {
            _controller = new CityForecastController(_mockLogger.Object, _mockCityRepository.Object, _mockForecastRepository.Object);
        }

        #region Constructor Tests
        [Fact]
        public void Constructor_WithNullLogger_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new CityForecastController(null, _mockCityRepository.Object, _mockForecastRepository.Object));
        [Fact]
        public void Constructor_WithNullCityRepository_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new CityForecastController(_mockLogger.Object, null, _mockForecastRepository.Object));
        [Fact]
        public void Constructor_WithNullForecastRepository_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new CityForecastController(_mockLogger.Object, _mockCityRepository.Object, null));

        #endregion

        [Fact]
        public async Task GetAsyncWithValidCityResult_Successful()
        {
            // Arrange
            _mockCityRepository.Reset();
            _mockLogger.Reset();

            var mockCity = new City() { Id = 1, Name = "Raleigh", State = "NC", Country = "US", Latitude = 1, Longitude = 2 };

            var mockForecast = new Forecast() { DateTimeUTC = new DateTime(0), Icon = "blue", Offset = 5, Summary = "Sunny", TemperatureF = 50, UVIndex = 2 };

            _mockCityRepository
                .Setup(x => x.GetByIdAsync(mockCity.Id))
                .ReturnsAsync(mockCity)
                .Verifiable();

            _mockForecastRepository
                .Setup(x => x.GetForecastAsync(mockCity.Latitude, mockCity.Longitude, null))
                .ReturnsAsync(mockForecast)
                .Verifiable();

            // Act
            var response = await _controller.GetAsync(mockCity.Id, null);

            // Assert
            Assert.IsType<OkObjectResult>(response.Result);
            var responseResult = (OkObjectResult)response.Result;

            Assert.IsType<Forecast>(responseResult.Value);
            var responseResultvalue = (Forecast)responseResult.Value;

            Assert.StrictEqual(responseResultvalue.DateTimeUTC, mockForecast.DateTimeUTC);
            Assert.Equal(responseResultvalue.Icon, mockForecast.Icon);
            Assert.Equal(responseResultvalue.Offset, mockForecast.Offset);
            Assert.Equal(responseResultvalue.Summary, mockForecast.Summary);
            Assert.Equal(responseResultvalue.TemperatureF, mockForecast.TemperatureF);
            Assert.Equal(responseResultvalue.TemperatureC, mockForecast.TemperatureC);
            Assert.Equal(responseResultvalue.UVIndex, mockForecast.UVIndex);

            _mockCityRepository.Verify(x => x.GetByIdAsync(It.IsAny<int>()), Times.Once);
            _mockForecastRepository.Verify(x => x.GetForecastAsync(It.IsAny<double>(), It.IsAny<double>(), null), Times.Once);
            _mockLogger.Verify(
                x => x.Log(
                        It.IsAny<LogLevel>(),
                        It.IsAny<EventId>(),
                        It.Is<It.IsAnyType>((v, t) => true),
                        It.IsAny<Exception>(),
                        It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                Times.Once);
        }

        [Fact]
        public async Task GetAsyncWithInvalidCity_Returns404()
        {
            // Arrange
            _mockCityRepository.Reset();
            _mockLogger.Reset();

            _mockCityRepository
                .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((City)null)
                .Verifiable();

            // Act
            var response = await _controller.GetAsync(It.IsAny<int>(), null);

            // Assert
            Assert.IsType<NotFoundObjectResult>(response.Result);

            _mockCityRepository.Verify(x => x.GetByIdAsync(It.IsAny<int>()), Times.Once);
            _mockForecastRepository.Verify(x => x.GetForecastAsync(It.IsAny<double>(), It.IsAny<double>(), null), Times.Never);
            _mockLogger.Verify(
                x => x.Log(
                        It.IsAny<LogLevel>(),
                        It.IsAny<EventId>(),
                        It.Is<It.IsAnyType>((v, t) => true),
                        It.IsAny<Exception>(),
                        It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                Times.Once);
        }

        [Fact]
        public async Task GetAsyncWithInvalidForecast_Returns404()
        {
            // Arrange
            _mockCityRepository.Reset();
            _mockLogger.Reset();

            var mockCity = new City() { Id = 1, Name = "Raleigh", State = "NC", Country = "US", Latitude = 1, Longitude = 2 };

            _mockCityRepository
                .Setup(x => x.GetByIdAsync(mockCity.Id))
                .ReturnsAsync(mockCity)
                .Verifiable();

            _mockForecastRepository
                .Setup(x => x.GetForecastAsync(It.IsAny<double>(), It.IsAny<double>(), null))
                .ReturnsAsync((Forecast)null)
                .Verifiable();

            // Act
            var response = await _controller.GetAsync(It.IsAny<int>(), null);

            // Assert
            Assert.IsType<NotFoundObjectResult>(response.Result);

            _mockCityRepository.Verify(x => x.GetByIdAsync(It.IsAny<int>()), Times.Once);
            _mockForecastRepository.Verify(x => x.GetForecastAsync(It.IsAny<double>(), It.IsAny<double>(), null), Times.Never);
            _mockLogger.Verify(
                x => x.Log(
                        It.IsAny<LogLevel>(),
                        It.IsAny<EventId>(),
                        It.Is<It.IsAnyType>((v, t) => true),
                        It.IsAny<Exception>(),
                        It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                Times.Once);
        }
    }
}