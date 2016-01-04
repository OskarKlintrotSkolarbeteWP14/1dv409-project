using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Weather.Entities
{
    public class Forecast
    {
        public Forecast()
        {
            // Empty
        }
        public Forecast(XElement forecast)
        {
            Time = (DateTime)forecast.Attribute("from");
            Weather = (TypeOfWeather)(int)forecast.Element("symbol").Attribute("number");
            Temperature = (int)forecast.Element("temperature").Attribute("value");
            Period = (int)forecast.Attribute("period");
        }
        public int Id { get; set; }
        [Required]
        public DateTime Time { get; set; }
        [Required]
        public TypeOfWeather Weather { get; set; }
        [Required]
        public int Temperature { get; set; }
        [Required]
        public int Period { get; set; }
    }
}
