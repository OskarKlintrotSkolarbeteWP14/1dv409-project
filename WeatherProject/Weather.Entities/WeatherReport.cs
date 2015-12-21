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
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Location { get; set; }
    }
}
