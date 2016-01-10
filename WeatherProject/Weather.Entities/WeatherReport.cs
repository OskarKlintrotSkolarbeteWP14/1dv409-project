using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Entities
{
    public class WeatherReport
    {
        public WeatherReport()
        {
                // Empty
        }
        public WeatherReport(City Location, DateTime Stale, ICollection<Forecast> Forecasts)
        {
            this.Location = Location;
            Timestamp = DateTime.Now;
            this.Stale = Stale;
            this.Forecasts = Forecasts.OrderBy(d => d.TimeFrom).ToList();
        }
        public bool isEmpty()
        {
            return Forecasts == null || Forecasts.Count <= 0;
        }
        public bool isStale()
        {
            return !(Stale > DateTime.Now);
        }
        public int Id { get; set; }
        [Required]
        public virtual City Location { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        [Required]
        public DateTime Stale { get; set; }
        [Required]
        public virtual ICollection<Forecast> Forecasts { get; set; }
    }
}
