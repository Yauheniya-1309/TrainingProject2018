namespace My3.Controllers
{
    #region Using
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using My3Common;
    using My3Business;
    #endregion

    public class UserController : Controller
    {
        private IBusinessLayer businessLayer;

        public UserController(IBusinessLayer businessLayer)
        {
            this.businessLayer = businessLayer;
            ViewBag.Weather = this.businessLayer.DoWeather();
            ViewBag.Time = DateTime.Now.ToShortDateString();
        }

        public ActionResult Events(int id)
        {
            ViewBag.UserName = this.businessLayer.GetUserById(id).Name;
            ViewBag.UserId = id;
            List<Event> events = this.businessLayer.GetEventsOfUser(id).OrderBy(u => u.Date).ToList();

            return View(events);
        }

        [HttpGet]
        public ActionResult UserEditEvent(int id)
        {
            Event event1 = this.businessLayer.GetEventById(id);

            ViewBag.UserID = this.businessLayer.GetUserByEmail(User.Identity.Name).ID;
            ViewBag.EventsOfUser = this.businessLayer.GetUserByEmail(event1.UserName).ID;
            return View(event1);
        }


        [HttpPost]
        public ActionResult UserEditEvent(Event eventToEdit)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.businessLayer.EditEvent(eventToEdit);

                    return RedirectToAction("Events","User", new {this.businessLayer.GetUserByEmail(eventToEdit.UserName).ID });
                }
                catch (Exception ex)
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
        public ActionResult Details(int id)
        {
            return View(this.businessLayer.GetUserById(id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new User { AddedDate=DateTime.Now, Role="User"});
        }

        [HttpPost]
        public ActionResult Create(User newUser)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.businessLayer.AddNewUser(newUser);
                    Log4NetHandler.Log.Info("New User create" + newUser.Email);
                    return RedirectToAction("Users", "Admin");
                }
                catch (Exception ex)
                {
                    Log4NetHandler.Log.Error("New User doesn't create" + ex.Message);

                    return View();
                }
            }
            else
            {
                return View(newUser);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(this.businessLayer.GetUserById(id));
        }

        [HttpPost]
        public ActionResult Edit(User userToEdit)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.businessLayer.EditUser(userToEdit);

                    return RedirectToAction("Users", "Admin");
                }
                catch(Exception ex)
                {
                    Log4NetHandler.Log.Error("The User doesn't edited" + ex.Message);

                    return View();
                }
            }
            else
            {
                Log4NetHandler.Log.Error("The model is not valid" + "User Edit");
                return View(userToEdit);
            }
            
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(this.businessLayer.GetUserById(id));
        }

        [HttpPost]
        public ActionResult Delete(User userToDelete)
        {
            try
            {
                this.businessLayer.DeleteUser(userToDelete);

                return RedirectToAction("Users", "Admin");

            }
            catch(Exception ex)
            {
                Log4NetHandler.Log.Error("The User doesn't deleted" + ex.Message);

                return View();
            }
        }

        public ActionResult Search(string searchUser)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Result = User.Identity.Name;

                ViewBag.UserId = this.businessLayer.GetUserByEmail(User.Identity.Name).ID;

                ViewBag.IsValidUser = this.businessLayer.GetUserByEmail(User.Identity.Name).Role;
            }

            List<User> users =  this.businessLayer.GetUsers();
            List<User> result = new List<User>();

            result = users.Where(u => u.Email.ToUpper().Contains(searchUser.ToUpper())).Union(users.Where(u => u.Name.ToUpper().Contains(searchUser.ToUpper()))).ToList();

            if (result.Count == 0)
            {
                result.Add(new User{ });
                return View();
            }

            result = result.OrderBy(u => u.ID).ToList();
            @ViewBag.users = result;
            RedirectToAction("SearchUsers", "Admin",result);
            return View(result);
        }

        [HttpGet]
        public ActionResult DeleteUserDeleteEvent(int id)
        {
            Event event1 = this.businessLayer.GetEventById(id);

            ViewBag.EventsOfUser = this.businessLayer.GetUserByEmail(event1.UserName).ID;

            return View(this.businessLayer.GetEventById(id));
        }

        [HttpPost]
        public ActionResult DeleteUserDeleteEvent(Event eventToDelete)
        {
            try
            {
                this.businessLayer.DeleteEvent(eventToDelete);

                return RedirectToAction("Events", "User", new { this.businessLayer.GetUserByEmail(eventToDelete.UserName).ID });
            }
            catch (Exception ex)
            {
                Log4NetHandler.Log.Error("The Event doesn't deleted" + ex.Message);

                return View();
            }
        }
    }
}
