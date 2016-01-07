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
            return _namesService.getCities(cityName);
        }

        public override WeatherReport GetWeatherForecast(City city)
        {
            return _weatherService.getWeatherForecast(city);
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
