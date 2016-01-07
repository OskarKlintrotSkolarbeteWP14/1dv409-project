using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Entities
{
    public class City
    {
        public City()
        {
            // Empty
        }
        public City(JToken city)
        {
            Name = city.Value<string>("name");
            Region= city.Value<string>("adminName1");
            Country = city.Value<string>("countryName");
            GeonameId = int.Parse(city.Value<string>("geonameId"));
        }
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Region { get; set; }
        [Required]
        [StringLength(255)]
        public string Country { get; set; }
        [Required]
        public int GeonameId { get; set; }
    }
}
