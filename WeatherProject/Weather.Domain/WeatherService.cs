using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Domain.WebServices;
using Weather.Entities;

namespace Weather.Domain
{
    public class WeatherService : WeatherServiceBase
    {
        private IYrService _weatherService;
        private IGeoNamesService _namesService;

        public WeatherService()
            : this(new GeoNamesService(), new YrService())
        {
            // Empty
        }
        public WeatherService(IGeoNamesService nameService, IYrService weatherService)
        {
            _namesService = nameService;
            _weatherService = weatherService;
        }
        public override IEnumerable<City> GetCities(string cityName)
        {
            try
            {
                return _namesService.getCities(cityName);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public override WeatherReport GetWeatherForecast(City city)
        {
            try
            {
                return _weatherService.getWeatherForecast(city);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
