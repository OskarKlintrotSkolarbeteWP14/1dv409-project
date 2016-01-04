namespace Weather.Domain.Migrations
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Weather.Domain.DataContexts.WeatherReportsDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Weather.Domain.DataContexts.WeatherReportsDb context)
        {
            //var Forecasts = new List<Forecast>();
            //Forecasts.Add(new Forecast { Time = new DateTime(2015, 07, 26, 15, 00, 00), Weather = TypeOfWeather.Sun });
            //Forecasts.Add(new Forecast { Time = new DateTime(2015, 07, 26, 18, 00, 00), Weather = TypeOfWeather.Cloud });
            //Forecasts.Add(new Forecast { Time = new DateTime(2015, 07, 26, 21, 00, 00), Weather = TypeOfWeather.Rain });

            //context.WeatherReports.AddOrUpdate(w => w.Id,
            //    new WeatherReport { Id = 1, Location = new City(), Forecasts = Forecasts, Timestamp = DateTime.Now }
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
