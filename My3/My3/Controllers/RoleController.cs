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

    public class RoleController : Controller
    {
        private IBusinessLayer businessLayer;

        public RoleController(IBusinessLayer businessLayer)
        {
            this.businessLayer = businessLayer;
            ViewBag.Weather = this.businessLayer.DoWeather();
            ViewBag.Time = DateTime.Now.ToShortDateString();
        }

        public ActionResult Details(int id)
        {
            Role role1 = this.businessLayer.GetRoleById(id);

            return View(role1);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Role newRole)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.businessLayer.AddNewRole(newRole);

                    return RedirectToAction("Roles", "Admin");
                }
                catch(Exception ex)
                {
                    Log4NetHandler.Log.Error("The Role doesn't craete" + ex.Message);

                    return View();
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(this.businessLayer.GetRoleById(id));
        }

        [HttpPost]
        public ActionResult Edit(Role roleToEdit)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.businessLayer.EditRole(roleToEdit);

                    return RedirectToAction("Roles", "Admin");
                }
                catch(Exception ex)
                {
                    Log4NetHandler.Log.Error("The Role doesn't edited" + ex.Message);

                    return View();
                }
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            return View(this.businessLayer.GetRoleById(id));
        }

        [HttpPost]
        public ActionResult Delete(Role roleToDelete)
        {
            try
            {
                this.businessLayer.DeleteRole(roleToDelete);

                return RedirectToAction("Roles", "Admin");
            }
            catch(Exception ex)
            {
                Log4NetHandler.Log.Error("The Role doesn't deleted" + ex.Message);

                return View();
            }
        }
    }
}
