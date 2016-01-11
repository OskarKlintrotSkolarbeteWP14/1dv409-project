using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Weather.Domain;
using Weather.Entities;
using Weather.MVC.ViewModels;

namespace Weather.MVC.Controllers
{
    
    public class HomeController : Controller
    {
        private IWeatherService _service;
        private string _success = "Success";
        private string _error = "Error";
        private string _errorMessage = "Något gick fel, försök igen senare.";
        public HomeController(IWeatherService weatherService)
        {
            _service = weatherService;
        }

        public ActionResult Index(HomeIndexViewModel model, int? geonameid, string name = null, string region = null, string country = null)
        {
            if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(region) && !String.IsNullOrEmpty(country) && geonameid != null)
            {
                try
                {
                    model.CityToGetWeatherFor.Name = name;
                    model.CityToGetWeatherFor.Region = region;
                    model.CityToGetWeatherFor.Country = country;
                    model.CityToGetWeatherFor.GeonameId = (int)geonameid;
                    model.WeatherReport = _service.GetWeatherReport(model.CityToGetWeatherFor);
                    model.CityToFind = name;
                    return View(model);
                }
                catch (InvalidOperationException e) // This exception is thrown when something fails with the EF and that causes a 500
                {
                    return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
                }
                catch (Exception e)
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
                        model.Cities = _service.GetCities(model.CityToFind);
                        TempData[_error] = model.Cities.Count() == 0 ? "Orten kunde inte hittas." : null;
                    }
                    else
                    {
                        model.WeatherReport = _service.GetWeatherReport(model.CityToGetWeatherFor);
                    }
                }
                catch (InvalidOperationException e) // This exception is thrown when something fails with the EF and that causes a 500
                {
                    return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
                }
                catch (Exception e)
                {
                    //TempData[_error] = _errorMessage;
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            return View(model);
        }

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
            base.Dispose(disposing);
        }

        #endregion
    }
}