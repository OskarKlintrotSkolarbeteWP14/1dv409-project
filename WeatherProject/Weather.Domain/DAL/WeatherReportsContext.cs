using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Weather.Entities;

namespace Weather.Domain.DAL
{
    public class WeatherReportsContext : DbContext
    {
        public WeatherReportsContext()
            //: base("name=Weather.Domain.Properties.Settings.Falken")
            : base("name=Weather.MVC.Properties.Settings.Falken")
        {
            // Empty
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("appSchema");
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<WeatherReport> WeatherReports { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Forecast> Forecasts { get; set; }
    }
}
