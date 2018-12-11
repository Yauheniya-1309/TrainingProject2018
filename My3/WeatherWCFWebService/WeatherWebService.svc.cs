using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WeatherWCFWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WeatherWebService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WeatherWebService.svc or WeatherWebService.svc.cs at the Solution Explorer and start debugging.
    public class WeatherWebService : IWeatherWebService
    {
        public string Weather()
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=London,uk&units=metric&APPID=a50a0e5e68b6dea1414a5d5b21e10c55";
            HttpWebRequest httpwebrequest = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse httpwebresponse = (HttpWebResponse)httpwebrequest.GetResponse();

            string response;
            using (StreamReader streamReader = new StreamReader(httpwebresponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }
            Weatherresponse weatherResponse = JsonConvert.DeserializeObject<Weatherresponse>(response);

            string weather =  "Temperature in"+ weatherResponse.Name.ToString()+ weatherResponse.Main.Temp.ToString() ;
            return weather;
        }
    }
    public class Temperatureinfo
    {

        public float Temp { get; set; }

    }
    public class Weatherresponse
    {

        public Temperatureinfo Main { get; set; }

        public string Name { get; set; }
    }
}
