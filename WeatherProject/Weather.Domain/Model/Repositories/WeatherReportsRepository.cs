using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Domain.DAL;
using Weather.Entities;

namespace Weather.Domain.Model.Repositories
{
    public class WeatherReportsRepository : IWeatherReportsRepository
    {
        private WeatherReportsContext _context = new WeatherReportsContext();

        public void AddOrUpdateWeatherReport(WeatherReport weatherReport)
        {
            if (weatherReport.Id == 0)
            {
                _context.WeatherReports.Add(weatherReport);
            }
            else
            {
                var entity = _context.WeatherReports.Find(weatherReport.Id);
                entity.Forecasts = weatherReport.Forecasts;
                entity.Stale = weatherReport.Stale;
                entity.Location = entity.Location; // Entity isn't valid without this
                entity.Timestamp = weatherReport.Timestamp;
            }
        }

        public WeatherReport GetWeatherReport(WeatherReport weatherReport)
        {
            try
            {
                return _context.WeatherReports.Where(w => w.Location.GeonameId == weatherReport.Location.GeonameId).First();
            }
            catch (Exception)
            {
                return new WeatherReport();
            }
        }

        public WeatherReport GetWeatherReport(City city)
        {
            try
            {
                return _context.WeatherReports.Where(w => w.Location.GeonameId == city.GeonameId).First();
            }
            catch (Exception)
            {
                return new WeatherReport();
            }
        }

        public void RemoveWeatherReport()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
