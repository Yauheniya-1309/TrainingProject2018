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

    public class CategoryController : Controller
    {   
        private IBusinessLayer businessLayer;

        public CategoryController(IBusinessLayer businessLayer)
        {
            this.businessLayer = businessLayer;
            ViewBag.Weather = this.businessLayer.DoWeather();
            ViewBag.Time = DateTime.Now.ToShortDateString();
        }

        public ActionResult DetailsCategory(int id)
        {
            Category category = this.businessLayer.GetCategoryById(id);

            return View(category);
        }

        //public ActionResult CreateCategory()
        //{
        //    return View();
        //}


        //[HttpPost]
        //public ActionResult CreateCategory(Category newCategory)
        //{
        //    try
        //    {
        //        this.businessLayer.AddCategory(newCategory);

        //        return RedirectToAction("Categories", "Admin");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        public ActionResult EditCategory(int id)
        {
            return View(this.businessLayer.GetCategoryById(id));
        }

        [HttpPost]
        public ActionResult EditCategory(Category categoryToEdit)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.businessLayer.EditCategory(categoryToEdit);

                    return RedirectToAction("Categories", "Admin");
                }
                catch(Exception ex)
                {
                    Log4NetHandler.Log.Error("The Category doesn't edited" + ex.Message);
                    return View();
                }
            }
            return View();
        }

        //public ActionResult DeleteCategory(int id)
        //{
        //    return View(this.businessLayer.GetCategoryById(id));
        //}


        //[HttpPost]
        //public ActionResult DeleteCategory(Category deleteCategory)
        //{
        //    try
        //    {
        //        this.businessLayer.DeleteCategory(deleteCategory);

        //        return RedirectToAction("Categories", "Admin");

        //    }
        //    catch(Exeption ex)
        //    {
        //        Log4NetHandler.Log.Error("The Category doesn't deleted" + ex.Message);
        //        return View();
        //    }
        //}
    }
}
