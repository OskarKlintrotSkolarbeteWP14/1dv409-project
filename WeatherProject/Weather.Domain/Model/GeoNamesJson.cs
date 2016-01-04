using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Domain.Model
{
    public class GeoNamesJson
    {
        public int totalResultsCount { get; set; }
        public geonames[] geonames { get; set; }
    }
}
