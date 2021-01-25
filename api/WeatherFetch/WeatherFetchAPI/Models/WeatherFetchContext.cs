using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace WeatherFetchAPI.Models
{
	public partial class WeatherFetchContext : DbContext
	{
		private readonly string _databaseFileName;

		/*
		public WeatherFetchContext(string dbName) : base()
		{
			_databaseFileName = dbName;
		}
		*/

		public WeatherFetchContext(IOptions<AppSettings> settings) : base() {
			_databaseFileName = settings.Value.DatabaseFileName;
			Database.EnsureCreated();
		}

		public DbSet<City> Cities { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
			=> options.UseSqlite($"Data Source={_databaseFileName}");
	}
}
