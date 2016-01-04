using System.Collections.Generic;
using Weather.Entities;

namespace Weather.Domain.WebServices
{
    public interface IGeoNamesService
    {
        IEnumerable<City> getCities(string cityName);
    }
}