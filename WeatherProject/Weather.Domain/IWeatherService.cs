﻿using System;
using System.Collections.Generic;
using Weather.Entities;

namespace Weather.Domain
{
    public interface IWeatherService : IDisposable
    {
        IEnumerable<City> GetCities(string cityName);
        WeatherReport GetWeatherReport(City city);
        void SaveWeatherReport(WeatherReport weatherReport);
    }
}