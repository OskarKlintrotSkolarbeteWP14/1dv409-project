using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Entities
{
    public class Forecast
    {
        public int Id { get; set; }
        [Required]
        public DateTime Time { get; set; }

        [Required]
        public TypeOfWeather Weather { get; set; }
    }
}
