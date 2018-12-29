
using My3Common;
using My3Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace My3.Controllers
{
    public class UserController : Controller
    {
        private IBusinessLayer businessLayer;
        
        public UserController(IBusinessLayer businessLayer)
        {
            this.businessLayer = businessLayer;

        }

        [HttpGet]
        public ActionResult Register()
        {
            var newUser = new User();
            return View(newUser);
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            return View(user);
        }


        [HttpGet]
        public ActionResult Entrance()
        {
            return View();
        }


        // GET: User
        //public ActionResult Index()
        //{
            
        //    return View();
        //}

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(this.businessLayer.GetUserById(id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User newUser)
        {
            newUser.AddedDate = DateTime.Now;
            newUser.Role = "User";
            try
            {
                this.businessLayer.AddNewUser(newUser);

                return RedirectToAction("Users", "Admin");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(this.businessLayer.GetUserById(id));
        }

    
        [HttpPost]
        public ActionResult Edit(User editUser)
        {
            try
            {
                this.businessLayer.EditUser(editUser);

                return RedirectToAction("Users", "Admin");
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(this.businessLayer.GetUserById(id));
        }

        
        [HttpPost]
        public ActionResult Delete(User DeleteUser)
        {
            try
            {
                this.businessLayer.DeleteUser(DeleteUser);

                return RedirectToAction("Users", "Admin");

            }
            catch
            {
                return View();
            }
        }
    }
}
