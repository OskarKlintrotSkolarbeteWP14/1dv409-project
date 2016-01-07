using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Weather.Domain;
using Weather.Domain.WebServices;
using Weather.Entities;
using Weather.MVC.ViewModels;

namespace Weather.MVC.Controllers
{
    
    public class HomeController : Controller
    {
        private IWeatherService _weatherService;
        private string _success = "Success";
        private string _error = "Error";
        private string _errorMessage = "Något gick fel, försök igen senare.";
        public HomeController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Index(HomeIndexViewModel model, string name = null, string region = null, string country = null)
        {
            if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(region) && !String.IsNullOrEmpty(country))
            {
                try
                {
                    model.CityToGetWeatherFor.Name = name;
                    model.CityToGetWeatherFor.Region = region;
                    model.CityToGetWeatherFor.Country = country;
                    model.WeatherReport = _weatherService.GetWeatherForecast(model.CityToGetWeatherFor);
                    model.CityToFind = name;
                    return View(model);
                }
                catch (Exception)
                {
                    //TempData[_error] = _errorMessage;
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "CityToFind")]HomeIndexViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (model.Cities == null && !String.IsNullOrEmpty(model.CityToFind))
                    {
                        model.Cities = _weatherService.GetCities(model.CityToFind);
                        TempData[_error] = model.Cities.Count() == 0 ? "Orten kunde inte hittas." : null;
                    }
                    else
                    {
                        model.WeatherReport = _weatherService.GetWeatherForecast(model.CityToGetWeatherFor);
                    }
                }
                catch (Exception)
                {
                    //TempData[_error] = _errorMessage;
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            return View(model);
        }
    }
}