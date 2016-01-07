using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Weather.Domain.Model;
using Weather.Entities;

namespace Weather.Domain.WebServices
{
    public class GeoNamesService : IGeoNamesService
    {
        public IEnumerable<City> getCities(string cityName)
        {
            try
            {
                var uri = string.Format("http://api.geonames.org/searchJSON?name={0}&maxRows=50&username=oklib08", cityName);

                var request = (HttpWebRequest)WebRequest.Create(uri);

                string jsonString;
                using (var response = request.GetResponse())
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    jsonString = reader.ReadToEnd();
                }

                var jsonObject = JObject.Parse(jsonString);
                IList<JToken> names = jsonObject["geonames"].Children().ToList();
                return names.Select(city => new City(city));
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
