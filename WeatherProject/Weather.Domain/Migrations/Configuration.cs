namespace Weather.Domain.Migrations
{
    using DAL;
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WeatherReportsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(WeatherReportsContext context)
        {
            //var Forecasts = new List<Forecast>();
            //Forecasts.Add(new Forecast { TimeFrom = new DateTime(2015, 07, 26, 15, 00, 00), Weather = TypeOfWeather.Sun });
            //Forecasts.Add(new Forecast { TimeFrom = new DateTime(2015, 07, 26, 18, 00, 00), Weather = TypeOfWeather.Cloud });
            //Forecasts.Add(new Forecast { TimeFrom = new DateTime(2015, 07, 26, 21, 00, 00), Weather = TypeOfWeather.Rain });

            //var City = new City();
            //City.Id = 0;

            ////context.Cities.AddOrUpdate(w => w.Id, City);

            //context.WeatherReports.AddOrUpdate(w => w.Id,
            //    new WeatherReport { Id = 0, Location = City, Forecasts = Forecasts, Timestamp = DateTime.Now }
            //    );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
