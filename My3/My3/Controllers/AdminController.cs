using My3Business;
using My3Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My3.Controllers
{
    public class AdminController : Controller
    {
        private IBusinessLayer businessLayer;

        public AdminController(IBusinessLayer businessLayer)
        {
            this.businessLayer = businessLayer;
        }

        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult Users()
        {
            List<User> users = new List<User>();
            users = this.businessLayer.GetUsers();
            ViewBag.users = users;
            return View();
        }

       
        public ActionResult Categories()
        {
            List<Category> categories = new List<Category>();
            categories = this.businessLayer.GetCategories();
            ViewBag.categories = categories;
            return View();
        }

      
        public ActionResult Events()
        {
            List<Event> events = new List<Event>();
            events = this.businessLayer.GetEvents();
            ViewBag.events = events;
            return View();
        }

        public ActionResult Roles()
        {
            List<Role> roles = new List<Role>();
            roles = this.businessLayer.GetRoles();
            ViewBag.roles = roles;
            return View();
        }

       
     }
    
}
