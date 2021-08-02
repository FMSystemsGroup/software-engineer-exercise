using FMSystems.WeatherForecast.Api.Controllers.Cities;
using FMSystems.WeatherForecast.Domain.Repository;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace DSI.IntelligenceOIDC.Api.Tests.Controllers
{
    public class CityControllerTest
    {
        private readonly Mock<ICityRepository> _mockCityRepository = new Mock<ICityRepository>();
        private readonly Mock<ILogger<CityController>> _mockLogger = new Mock<ILogger<CityController>>();

        private readonly CityController _controller;

        public CityControllerTest()
        {
            _controller = new CityController(_mockLogger.Object, _mockCityRepository.Object);
        }

        #region Constructor Tests

        [Fact]
        public void Constructor_WithNullLogger_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new CityController(null, _mockCityRepository.Object));
        [Fact]
        public void Constructor_WithNullCityRepository_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new CityController(_mockLogger.Object, null));

        #endregion


        [Fact]
        public async Task GetAllAsyncWithValidResult_Successful()
        {
            // Arrange
            _mockCityRepository.Reset();
            _mockLogger.Reset();

            var cities = new List<FMSystems.WeatherForecast.Domain.Entity.City>
                    {
                        new FMSystems.WeatherForecast.Domain.Entity.City() { Id=1, Name = "Raleigh", State = "NC", Country = "US", Latitude = 1, Longitude = 2 },
                        new FMSystems.WeatherForecast.Domain.Entity.City() { Id=2, Name = "Seattle", State = "WA", Country = "US", Latitude = 3, Longitude = 9 },
                        new FMSystems.WeatherForecast.Domain.Entity.City() { Id=3, Name = "London", State = null, Country = "EN", Latitude = Double.MinValue, Longitude = Double.MaxValue },
                    };

            _mockCityRepository
                .Setup(x => x.GetAllAsync())
                .ReturnsAsync(cities)
                .Verifiable();

            // Act
            var result = await _controller.GetAllAsync();

            // Assert
            Assert.Equal(result.Count, cities.Count);
            _mockCityRepository.Verify(x => x.GetAllAsync(), Times.Once);
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
        public async Task GetAllAsyncWithEmptyResult_Successful()
        {
            // Arrange
            _mockCityRepository.Reset();
            _mockLogger.Reset();

            var cities = new List<FMSystems.WeatherForecast.Domain.Entity.City> { };

            _mockCityRepository
                .Setup(x => x.GetAllAsync())
                .ReturnsAsync(cities)
                .Verifiable();

            // Act
            var result = await _controller.GetAllAsync();

            // Assert
            Assert.Equal(result.Count, cities.Count);
            _mockCityRepository.Verify(x => x.GetAllAsync(), Times.Once);
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