using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Weather.Entities;

namespace Weather.Domain.WebServices
{
    public class YrService : IYrService
    {
        public WeatherReport getWeatherForecast(City city)
        {
            try
            {
                var uri = string.Format("http://www.yr.no/place/{0}/{1}/{2}/forecast.xml", city.Country, city.Region, city.Name);
                var xml = XElement.Load(uri);
                var xmlForecasts = xml.Element("forecast").Element("tabular").Elements("time");
                var nextUpdate = DateTime.Parse(xml.Element("meta").Element("nextupdate").Value);
                var listForecasts = new List<Forecast>();

                foreach (var item in xmlForecasts)
                {
                    listForecasts.Add(new Forecast(item));
                }

                return new WeatherReport(city, nextUpdate, listForecasts);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
