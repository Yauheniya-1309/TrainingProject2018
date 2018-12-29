using My3Business;
using My3Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My3.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private IBusinessLayer businessLayer;

        public CategoryController(IBusinessLayer businessLayer)
        {
            this.businessLayer = businessLayer;
        }


        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult DetailsCategory(int id)
        {
            Category category = this.businessLayer.GetCategoryById(id);
            return View(category);
        }

       
        public ActionResult CreateCategory()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult CreateCategory(Category newCategory)
        {
            try
            {
                this.businessLayer.AddCategory(newCategory);

                return RedirectToAction("Categories", "Admin");
            }
            catch
            {
                return View();
            }
        }

       
        public ActionResult EditCategory(int id)
        {
            return View(this.businessLayer.GetCategoryById(id));
        }

       
        [HttpPost]
        public ActionResult EditCategory(Category category1)
        {
            try
            {
                this.businessLayer.EditCategory(category1);

                return RedirectToAction("Categories", "Admin");
            }
            catch
            {
                return View();
            }
        }

       
        public ActionResult DeleteCategory(int id)
        {
            return View(this.businessLayer.GetCategoryById(id));
        }

       
        [HttpPost]
        public ActionResult DeleteCategory(Category deleteCategory)
        {
            try
            {
                this.businessLayer.DeleteCategory(deleteCategory);

                return RedirectToAction("Categories", "Admin");

            }
            catch
            {
                return View();
            }
        }
    }
}
