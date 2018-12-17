using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherWCFService
{
    public class Weatherresponse
    {
        public Temperatureinfo Main { get; set; }

        public string Name { get; set; }

    }
}