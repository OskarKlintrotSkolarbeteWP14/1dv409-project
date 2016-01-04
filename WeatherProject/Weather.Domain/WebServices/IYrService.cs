using Weather.Entities;

namespace Weather.Domain.WebServices
{
    public interface IYrService
    {
        WeatherReport getWeatherForecast(City city);
    }
}