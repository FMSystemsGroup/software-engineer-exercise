using FMSystems.Services.Repository.Interfaces;
using FMSystems.Shared.DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Serilog;


namespace FMSystems.Services.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly IConfiguration configuration;
        private readonly string ConnectionString;
        public CityRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<City>> GetCities()
        {
            try
            {
                //Mock data: data access goes here....
                var list = MockCityData.ToList<City>();
                return await Task.FromResult(list);
               
            }
            catch (Exception ex)
            {
                Log.Error("Exception in GetCities: " + ex.Message);
                throw ex;
            }
        }

        #region interface methods

        public async Task<City> GetByIdAsync(int id)
        {
            await Task.FromResult(true);

            throw new NotImplementedException();
        }

        public async Task<int> AddAsync(City entity)
        {
            await Task.FromResult(true);

            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(City entity)
        {
            await Task.FromResult(true);

            throw new NotImplementedException();
        }



        public async Task<int> DeleteAsync(int id)
        {
            await Task.FromResult(true);

            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<City>> GetAllAsync()
        {
            await Task.FromResult(true);

            throw new NotImplementedException();
        }




        #endregion interface methods


        #region mock data

        public static readonly City[] MockCityData = new City[]
        {
            new City{Id = 1, Latitude = 33.448376,  Longitude = -112.074036 ,Name ="Phoenix",  State ="AZ", TimeZoneId="MST (UTC -7)"},
            new City{Id = 2, Latitude = 35.779591,  Longitude = -78.638176 ,Name ="Raleigh",  State ="NC", TimeZoneId="EST (UTC -5)"},
            new City{Id = 3, Latitude = 45.272812,  Longitude = -66.063026 ,Name ="Saint John",  State ="NB (Canada)", TimeZoneId="NST (UTC -3:30)"},
            new City{Id = 4, Latitude = 32.715736,  Longitude = -117.161087 ,Name ="San Diego",  State ="CA", TimeZoneId="PST (UTC -8)"}

        };
        #endregion

    }
}
