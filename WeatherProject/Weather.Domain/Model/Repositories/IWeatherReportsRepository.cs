using Weather.Entities;

namespace Weather.Domain.Model.Repositories
{
    public interface IWeatherReportsRepository
    {
        void AddOrUpdateWeatherReport(WeatherReport weatherReport);
        void Dispose();
        WeatherReport GetWeatherReport(WeatherReport weatherReport);
        WeatherReport GetWeatherReport(City city);
        void RemoveWeatherReport();
        void Save();
    }
}