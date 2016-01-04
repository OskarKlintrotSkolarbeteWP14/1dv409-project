using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Weather.Entities;

namespace Weather.Domain.DataContexts
{
    public class WeatherReportsDb : DbContext
    {
        public WeatherReportsDb()
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
    }
}
