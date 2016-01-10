using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Domain.Model.Repositories;
using Weather.Domain.WebServices;
using Weather.Entities;

namespace Weather.Domain
{
    public class WeatherService : IWeatherService
    {
        private IWeatherReportsRepository _repository;
        private IYrService _weatherService;
        private IGeoNamesService _namesService;

        public WeatherService()
            : this(new GeoNamesService(), new YrService(), new WeatherReportsRepository())
        {
            // Empty
        }
        public WeatherService(IGeoNamesService nameService, IYrService weatherService, IWeatherReportsRepository weatherReportsRepository)
        {
            _namesService = nameService;
            _weatherService = weatherService;
            _repository = weatherReportsRepository;
        }
        public IEnumerable<City> GetCities(string cityName)
        {
            return _namesService.getCities(cityName);
        }

        public WeatherReport GetWeatherReport(City city)
        {
            var currentWeatherReport = _repository.GetWeatherReport(city);
            if (!currentWeatherReport.isStale())
            {
                return currentWeatherReport;
            }
            var weatherReport = _weatherService.getWeatherForecast(city);
            SaveWeatherReport(weatherReport);
            return weatherReport;
        }
        public void SaveWeatherReport(WeatherReport weatherReport)
        {
            var currentWeatherReport = _repository.GetWeatherReport(weatherReport);
            if (currentWeatherReport.isEmpty() || currentWeatherReport.isStale())
            {
                weatherReport.Id = currentWeatherReport.Id;
                _repository.AddOrUpdateWeatherReport(weatherReport);
                _repository.Save();
            }
        }
        #region IDisposable Support
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _repository.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
