using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Entities;

namespace Weather.Domain
{
    public abstract class WeatherServiceBase : IWeatherService
    {
        public abstract IEnumerable<City> GetCities(string cityName);
        public abstract WeatherReport GetWeatherForecast(City city);

        #region IDisposable Support
        protected virtual void Dispose(bool disposing)
        {
            // Empty
        }
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
