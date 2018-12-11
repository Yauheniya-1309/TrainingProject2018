
using My3Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My3Common.Controllers
{
    public class HomeController : Controller
    {
        private IBusinessLayer businessLayer;

        public HomeController(IBusinessLayer businessLayer)
        {
            this.businessLayer = businessLayer;
            ViewBag.Weather = this.businessLayer.Weather();
        }

        List<IEvent> events = new List<IEvent>();
        public ActionResult Index()
        {
            events.Add(new Event { ID = 1, Name = "Concert1",Date = DateTime.Now.ToString(), Description = "asdfghjk" });
            events.Add(new Event { ID = 2, Name = "Concert2", Date = DateTime.Now.ToString(), Description = "asdfghjk" });
            events.Add(new Event { ID = 3, Name = "Concert3", Date = DateTime.Now.ToString(), Description = "asdfghjk" });
           
           
            ViewBag.events = events;
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}