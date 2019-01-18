namespace My3.Controllers
{
    #region Using
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using My3Business;
    using My3Common;
    #endregion

    [Authorize]
    public class AdminController : Controller
    {
        private IBusinessLayer businessLayer;

    
        public AdminController(IBusinessLayer businessLayer)
        {
            this.businessLayer = businessLayer;

            ViewBag.Weather = this.businessLayer.DoWeather();

            ViewBag.Time = DateTime.Now.ToShortDateString();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            ViewBag.FromAdmin = true;
            List<User> users = this.businessLayer.GetUsers();
            ViewBag.users = users;
            return View();
        }

        public ActionResult SearchUsers(List<User> search)
        {
            ViewBag.FromAdmin = true;
            ViewBag.users = search;
            return View();
        }

        public ActionResult Categories()
        {
            ViewBag.FromAdmin = true;
            List<Category> categories = this.businessLayer.GetCategories();
            ViewBag.categories = categories;
            return View();
        }

        public ActionResult Events()
        {
            ViewBag.FromAdmin = true;
            List<Event> events = this.businessLayer.GetEvents();
            events.OrderBy(u => u.Date);
            ViewBag.events = events;
            return View();
        }

        public ActionResult Roles()
        {
            ViewBag.FromAdmin = true;
            List<Role> roles = this.businessLayer.GetRoles();
            ViewBag.roles = roles;
            return View();
        }
    }
}
