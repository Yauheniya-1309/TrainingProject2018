namespace My3.Controllers
{
    #region Using
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;
    using My3.Models;
    using My3Business;
    using My3Common;
    #endregion

    public class AccountController : Controller
    {
        private IBusinessLayer businessLayer;

        public AccountController(IBusinessLayer businessLayer)
        {
            this.businessLayer = businessLayer;

            ViewBag.Weather = this.businessLayer.DoWeather();

            ViewBag.Time = DateTime.Now.ToShortDateString();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = this.businessLayer.GetUserByEmailAndPassword(model.Email, model.Password);

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("UserError", "The User with such E-Mail and password doesn't exist");
                    Log4NetHandler.Log.Warn("The User with such E-Mail and password doesn't exist" + model.Email +"_"+ model.Password);
                }
            }
            else
            {
                Log4NetHandler.Log.Error("Not Valid login model");
            }

            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = this.businessLayer.GetUserByEmail(model.Email);

                if (user == null)
                {
                    this.businessLayer.AddNewUser(new User { Name = model.Name, Password = model.Password, Login = model.Name, Email = model.Email, Role = "User", AddedDate = DateTime.Now, PhoneNumber = "+375" });

                    user = this.businessLayer.GetUserByEmail(model.Email);

                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, true);
                        Log4NetHandler.Log.Info("New User registered" + user.Email);
                        return RedirectToAction("Index", "Home");                 
                    }
                }
                else
                {
                    ModelState.AddModelError("EmailError", "User with this E-mail already registered");
                    Log4NetHandler.Log.Warn("The User with such E - Mail and password already registered" + model.Email + " " + model.Password);
                }
            }
            else
            {
                Log4NetHandler.Log.Error("Not Valid register model");
            }

            return View(model);
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            User user = this.businessLayer.GetUserById(id);
            user.ConfirmPassword = user.Password;
            return View(user);
        }

        [HttpPost]
        public ActionResult Details(User userToEdit)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.businessLayer.EditUser(userToEdit);

                    return RedirectToAction("Index", "Home");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                Log4NetHandler.Log.Error("Not Valid model + Account + Details");
                return View(userToEdit);
            }
        }

        public ActionResult Events(int id)
        {
            ViewBag.FromUser = true;
            List<Event> events = this.businessLayer.GetEventsOfUser(id).OrderBy(u => u.Date).ToList();
            return View(events);
        }

        public ActionResult Create()
        {
            ViewBag.UserID = this.businessLayer.GetUserByEmail(User.Identity.Name).ID;

            return View(new Event { Date = DateTime.Now });
        }

        [HttpPost]
        public ActionResult Create(Event newEvent)
        {
            ViewBag.UserID = this.businessLayer.GetUserByEmail(User.Identity.Name).ID;
            newEvent.UserName = this.businessLayer.GetUserByEmail(User.Identity.Name).Email;

            if (ModelState.IsValid)
            {
                try
                {
                    this.businessLayer.AddEvent(newEvent);
                    Log4NetHandler.Log.Info("New Event added" + newEvent.Name);
                    return RedirectToAction("Events", new { this.businessLayer.GetUserByEmail(User.Identity.Name).ID });
                }
                catch(Exception ex)
                {     
                    Log4NetHandler.Log.Error("New Event doesn't create" + ex.Message);
                    return View();
                }
            }
            else
            {
                Log4NetHandler.Log.Error("Not Valid model + Account + Create");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Event event1 = this.businessLayer.GetEventById(id);

            ViewBag.UserID = this.businessLayer.GetUserByEmail(User.Identity.Name).ID;

            return View(event1);
        }


        [HttpPost]
        public ActionResult Edit(Event eventToEdit)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.businessLayer.EditEvent(eventToEdit);

                    return RedirectToAction("Events", new { this.businessLayer.GetUserByEmail(User.Identity.Name).ID });
                }
                catch(Exception ex)
                {
                    Log4NetHandler.Log.Error("The Event doesn't edited" + ex.Message);

                    return View();
                }
            }
            else
            {
                Log4NetHandler.Log.Error("Not Valid model + Account + Edit");
                return View(eventToEdit);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            ViewBag.UserID = this.businessLayer.GetUserByEmail(User.Identity.Name).ID;

            return View(this.businessLayer.GetEventById(id));
        }

        [HttpPost]
        public ActionResult Delete(Event eventToDelete)
        {
            try
            {
                this.businessLayer.DeleteEvent(eventToDelete);

                return RedirectToAction("Events", new { this.businessLayer.GetUserByEmail(User.Identity.Name).ID });

            }
            catch(Exception ex)
            {
                Log4NetHandler.Log.Error("The Event doesn't deleted" + ex.Message);

                return View();
            }
        }
    }
}