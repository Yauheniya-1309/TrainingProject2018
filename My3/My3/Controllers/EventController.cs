namespace My3.Controllers
{
    #region Using
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using My3Business;
    using My3Common;
    #endregion

    public class EventController : Controller
    {
        private IBusinessLayer businessLayer;

        public EventController(IBusinessLayer businessLayer)
        {
            this.businessLayer = businessLayer;
            ViewBag.Weather = this.businessLayer.DoWeather();
            ViewBag.Time = DateTime.Now.ToShortDateString();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Event event1 = this.businessLayer.GetEventById(id);

            return View(event1);
        }

        //public ActionResult Create()
        //{
        //    return View(new Event { Categories = this.businessLayer.GetCategories() });
        //}


        //[HttpPost]
        //public ActionResult Create(Event createEvent)
        //{

        //    createEvent.UserName = User.Identity.Name;
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            this.businessLayer.AddEvent(createEvent);

        //            return RedirectToAction("Events", "Admin");
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }
        //    return View();
        //}

        public IEnumerable<SelectListItem> GetCategoriesForSelectListItems()
        {
            List<Category> allCategory = this.businessLayer.GetCategories();
            List<SelectListItem> categories = allCategory
             .OrderBy(c => c.Name)
             .Select(
              c =>
               new SelectListItem
               {
                   Value = c.CategoryID.ToString(),
                   Text = c.Name
               }).ToList();

            var helper = new SelectListItem()
            {
                Value = null,
                Text = "---select category---"
            };

            categories.Insert(0, helper);
            return new SelectList(categories, "Value", "Text");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Event event1 = this.businessLayer.GetEventById(id);

            return View(event1);
        }

        [HttpPost]
        public ActionResult Edit(Event editEvent)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.businessLayer.EditEvent(editEvent);

                    return RedirectToAction("Events", "Admin");
                }
                catch 
                {
                    return View();
                }
            }
            return View(editEvent);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Event event1 = this.businessLayer.GetEventById(id);

            return View(this.businessLayer.GetEventById(id));
        }

        [HttpPost]
        public ActionResult Delete(Event eventToDelete)
        {
            try
            {
                this.businessLayer.DeleteEvent(eventToDelete);

                return RedirectToAction("Events", "Admin");
            }
            catch (Exception ex)
            {
                Log4NetHandler.Log.Error("The Event doesn't deleted" + ex.Message);

                return View();
            }
        }

        public ActionResult SearchFromAdmin(string searchEvent)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Result = User.Identity.Name;

                ViewBag.UserId = this.businessLayer.GetUserByEmail(User.Identity.Name).ID;

                ViewBag.IsValidUser = this.businessLayer.GetUserByEmail(User.Identity.Name).Role;
            }

            List<Event> events = this.businessLayer.GetEvents();
            List<Event> result = events.Where(u => u.Name.ToUpper().Contains(searchEvent.ToUpper()))
                .Union(events.Where(u => u.Description.ToUpper().Contains(searchEvent.ToUpper()))).ToList();

            if (result.Count == 0)
            {
                result.Add(new Event { });

                return View();
            }

            result = result.OrderBy(u => u.Date).ToList();
            @ViewBag.events = result;
            return View(result);
        }

        public ActionResult Search(string searchEvent, string searchCategory, string searchstatus)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Result = User.Identity.Name;

                ViewBag.UserId = this.businessLayer.GetUserByEmail(User.Identity.Name).ID;

                ViewBag.IsValidUser = this.businessLayer.GetUserByEmail(User.Identity.Name).Role;
            }

            List<Event> events = this.businessLayer.GetEvents();
            List<Event> result = new List<Event>();

            foreach (Event temp in events)
            {
                if (((temp.Name.ToUpper().Contains(searchEvent.ToUpper())) || (temp.Description.ToUpper().Contains(searchEvent.ToUpper())))
                    &&
                    (temp.Category.Contains(searchCategory))
                    &&
                    (temp.Status.Contains(searchstatus)))
                {
                    result.Add(temp);
                }

            }
            if (result.Count == 0)
            {
                ViewBag.noEvents = "Unfortunately, no EVENTS found...";
            }

            result = result.OrderBy(u => u.Date).ToList();
            @ViewBag.events = result;
            return View();
        }
    }
}
