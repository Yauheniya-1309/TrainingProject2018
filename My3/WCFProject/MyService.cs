using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFProject
{
    public class MyService: IMyService
    {
        public string MethodWeather()
        {
            string s = $"1 You entered:  = 1";
            return s;
        }

       
    }
}
