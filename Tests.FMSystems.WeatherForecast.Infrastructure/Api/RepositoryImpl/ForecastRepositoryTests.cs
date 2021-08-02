using FMSystems.WeatherForecast.Domain.Repository;
using FMSystems.WeatherForecast.Infrastructure.Api.RepositoryImpl;
using FMSystems.WeatherForecast.Infrastructure.ApiClients.DarkSky;
using FMSystems.WeatherForecast.Infrastructure.Options;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Tests.FMSystems.WeatherForecast.Domain.Infrastructure
{
    public class ForecastRepositoryTest
    {
        private readonly Mock<IDarkSkyApiClient> _darkSkyApiClient = new Mock<IDarkSkyApiClient>();
        private readonly Mock<IOptions<DarkSkyOptions>> _darkSkyOptions = new Mock<IOptions<DarkSkyOptions>>();

        private readonly ForecastRepository _repository;

        public ForecastRepositoryTest()
        {
            _repository = new ForecastRepository(_darkSkyApiClient.Object, _darkSkyOptions.Object);
        }

        #region Constructor Tests

        [Fact]
        public void Constructor_WithNullDarkSkyOptions_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new ForecastRepository(null, _darkSkyOptions.Object));
        [Fact]
        public void Constructor_WithNullDarkSkyApiClient_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new ForecastRepository(_darkSkyApiClient.Object, null));

        #endregion
    }
}