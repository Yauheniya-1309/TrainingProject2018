namespace My3Common.Controllers
{
    #region Using
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using My3.ServiceReference1;
    using My3Business;
    using My3Common;
    using Newtonsoft.Json;
    #endregion

    public class HomeController : Controller
    {
        private IBusinessLayer businessLayer;

        List<Event> events = new List<Event>();

        public HomeController(IBusinessLayer businessLayer)
        {
            this.businessLayer = businessLayer;

            ViewBag.Weather = this.businessLayer.DoWeather();

            ViewBag.Time = DateTime.Now.ToShortDateString();
        }

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Result = User.Identity.Name;

                ViewBag.UserId = this.businessLayer.GetUserByEmail(User.Identity.Name).ID;

                ViewBag.IsValidUser = this.businessLayer.GetUserByEmail(User.Identity.Name).Role;
            }

            events = this.businessLayer.GetEvents().Where(u => u.Status != "Completed").ToList();

            events=events.OrderBy(u => u.Date).ToList();

            ViewBag.events = events;

            return View("Index");
        }

        public ActionResult Film()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Result = User.Identity.Name;

                ViewBag.UserId = this.businessLayer.GetUserByEmail(User.Identity.Name).ID;

                ViewBag.IsValidUser = this.businessLayer.GetUserByEmail(User.Identity.Name).Role;
            }

            events = this.businessLayer.GetEvents()
                .Where(u => u.Status != "Completed")
                .Where(u => u.Category == "Film")
                .OrderBy(u => u.Date).ToList();

            ViewBag.events = events;
      
            return View("Index", events);
        }

        public ActionResult Music()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Result = User.Identity.Name;

                ViewBag.UserId = this.businessLayer.GetUserByEmail(User.Identity.Name).ID;

                ViewBag.IsValidUser = this.businessLayer.GetUserByEmail(User.Identity.Name).Role;
            }

            events = this.businessLayer.GetEvents()
               .Where(u => u.Status != "Completed")
               .Where(u => u.Category == "Music")
               .OrderBy(u => u.Date).ToList();

            ViewBag.events = events;

            return View("Index", events);
        }

        public ActionResult Sports()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Result = User.Identity.Name;

                ViewBag.UserId = this.businessLayer.GetUserByEmail(User.Identity.Name).ID;

                ViewBag.IsValidUser = this.businessLayer.GetUserByEmail(User.Identity.Name).Role;
            }
            events = this.businessLayer.GetEvents();

            events = events
               .Where(u => u.Status != "Completed")
               .Where(u => u.Category == "Sports")
               .OrderBy(u => u.Date).ToList();

            ViewBag.events = events;       

            return View("Index", events);
        }

        public ActionResult Exhibition()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Result = User.Identity.Name;

                ViewBag.UserId = this.businessLayer.GetUserByEmail(User.Identity.Name).ID;

                ViewBag.IsValidUser = this.businessLayer.GetUserByEmail(User.Identity.Name).Role;
            }
            events = this.businessLayer.GetEvents()
                .Where(u => u.Status != "Completed")
                .Where(u => u.Category == "Exhibition")
                .OrderBy(u => u.Date).ToList();

            ViewBag.events = events;
        
            return View("Index", events);
        }

        public ActionResult Family()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Result = User.Identity.Name;

                ViewBag.UserId = this.businessLayer.GetUserByEmail(User.Identity.Name).ID;

                ViewBag.IsValidUser = this.businessLayer.GetUserByEmail(User.Identity.Name).Role;
            }
            events = this.businessLayer.GetEvents()
                .Where(u => u.Status != "Completed")
                .Where(u => u.Category == "Family")
                .OrderBy(u => u.Date).ToList();

            ViewBag.events = events;

            return View("Index", events);
        }

        public ActionResult Party()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Result = User.Identity.Name;

                ViewBag.UserId = this.businessLayer.GetUserByEmail(User.Identity.Name).ID;

                ViewBag.IsValidUser = this.businessLayer.GetUserByEmail(User.Identity.Name).Role;
            }

            events = this.businessLayer.GetEvents()
                .Where(u => u.Status != "Completed")
                .Where(u => u.Category == "Party")
                .OrderBy(u => u.Date).ToList();

            ViewBag.events = events;

            return View("Index", events);
        }

        public ActionResult Theatre()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Result = User.Identity.Name;

                ViewBag.UserId = this.businessLayer.GetUserByEmail(User.Identity.Name).ID;

                ViewBag.IsValidUser = this.businessLayer.GetUserByEmail(User.Identity.Name).Role;
            }
            events = this.businessLayer.GetEvents()
               .Where(u => u.Status != "Completed")
               .Where(u => u.Category == "Theatre")
               .OrderBy(u => u.Date).ToList();

            ViewBag.events = events;

            return View("Index", events);
        }
    }
}