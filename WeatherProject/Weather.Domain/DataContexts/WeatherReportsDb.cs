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
            : base("Data Source = 172.16.214.1; Initial Catalog = 1dv409_oklib08_Weather;Persist Security Info=True;User ID = appUser; Password=1Br@Lösen=rd?")
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
