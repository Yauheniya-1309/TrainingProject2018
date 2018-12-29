using My3.ServiceReference1;

using My3Business;
using My3Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace My3Common.Controllers
{
    public class HomeController : Controller
    {
        private IBusinessLayer businessLayer;

        List<Event> events = new List<Event>();

        public HomeController(IBusinessLayer businessLayer)
        {
            this.businessLayer = businessLayer;
        }

        public ActionResult Index()
        {
            events = this.businessLayer.GetEvents();
            ViewBag.events = events;
            ViewBag.Weather=this.businessLayer.DoWeather();
            return View();
        }
               
    }
}