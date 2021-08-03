using FMSystems.WeatherForecast.Domain.Entity;
using FMSystems.WeatherForecast.Domain.Repository;
using FMSystems.WeatherForecast.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FMSystems.WeatherForecast.Infrastructure.Db.RepositoryImpl
{
    /// <inheritdoc/>
    public class CityRepository : ICityRepository
    {
        internal WeatherForecastDbContext context;

        /// <summary>
        /// Constructor for the City Repository.
        /// </summary>
        /// <param name="context">The DB Context.</param>
        public CityRepository(WeatherForecastDbContext context)
        {
            this.context = context;
            this.context.Database.EnsureCreated();
        }

        /// <inheritdoc/>
        public async virtual Task<ICollection<City>> GetAllAsync() => await context.Cities.ToListAsync();

        /// <inheritdoc/>
        public async virtual Task<City> GetByIdAsync(int cityId) => await context.Cities.FirstOrDefaultAsync(x => x.Id == cityId);
    }
}
