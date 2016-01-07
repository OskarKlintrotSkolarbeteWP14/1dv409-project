using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Weather.Entities;

namespace Weather.MVC.ViewModels
{
    public class HomeIndexViewModel
    {
        public HomeIndexViewModel()
        {
            CityToGetWeatherFor = new City();
        }
        public IEnumerable<City> Cities { get; set; }
        public City CityToGetWeatherFor { get; set; }
        public WeatherReport WeatherReport { get; set; }

        [DisplayName("Ort: ")]
        [Required(ErrorMessage = "En ort måste anges.")]
        public string CityToFind { get; set; }
    }
}