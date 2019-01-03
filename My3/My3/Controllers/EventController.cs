using My3Business;
using My3Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My3.Controllers
{
    public class EventController : Controller
    {
        private IBusinessLayer businessLayer;

        public EventController(IBusinessLayer businessLayer)
        {
            this.businessLayer = businessLayer;
        }

        
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: Event/Details/id

        [HttpGet]
        public ActionResult Details(int id)
        {
            Event event1 = this.businessLayer.GetEventById(id);
            return View(event1);
        }

        public ActionResult Create()
        {
          //  SelectList categories = new SelectList(this.businessLayer.GetCategories(), "CategoryID", "Name");
          //  ViewBag.Categories = categories;
            return View(new Event { Categories = this.businessLayer.GetCategories() });
        }


        [HttpPost]
        public ActionResult Create(Event createEvent)
        {
           
           
            try
            {
                this.businessLayer.AddEvent(createEvent);

                return RedirectToAction("Events", "Admin");
            }
            catch
            {
                return View();
            }
        }



        public IEnumerable<SelectListItem> GetCategoriesForSelectListItems()
        {
            List<Category> AllCat = this.businessLayer.GetCategories();
            List<SelectListItem> categories = AllCat
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
            event1.Categories =(List <Category>)GetCategoriesForSelectListItems();
         
            return View(event1);
        }


        [HttpPost]
        public ActionResult Edit(Event editEvent)
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


        [HttpGet]
        public ActionResult Delete(int id)
        {
            Event event1 = this.businessLayer.GetEventById(id);
           
            return View(this.businessLayer.GetEventById(id));
        }


        [HttpPost]
        public ActionResult Delete(Event DeleteEvent)
        {
            try
            {
                this.businessLayer.DeleteEvent(DeleteEvent);

                return RedirectToAction("Events", "Admin");

            }
            catch
            {
                return View();
            }

        }

        
    }
}
