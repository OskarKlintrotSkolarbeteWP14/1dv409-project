using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Domain.DAL
{
    // TODO: This is not running
    // http://stackoverflow.com/questions/19430502/dropcreatedatabaseifmodelchanges-ef6-results-in-system-invalidoperationexception
    class WeatherReportsInitializer : DropCreateDatabaseIfModelChanges<WeatherReportsContext>
    {
        protected override void Seed(WeatherReportsContext context)
        {
            base.Seed(context);
            //throw new Exception();
        }
    }
}
