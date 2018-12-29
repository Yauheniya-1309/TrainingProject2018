using My3Business;
using My3Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My3.Controllers
{
    public class RoleController : Controller
    {
        private IBusinessLayer businessLayer;

        public RoleController(IBusinessLayer businessLayer)
        {
            this.businessLayer = businessLayer;
        }


        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: Role/Details/5

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
            try
            {
                this.businessLayer.AddNewRole(newRole);

                return RedirectToAction("Roles", "Admin");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(this.businessLayer.GetRoleById(id));
        }

       
        [HttpPost]
        public ActionResult Edit(Role editeRole)
        {
            try
            {
                this.businessLayer.EditRole(editeRole);

                return RedirectToAction("Roles", "Admin");
            }
            catch
            {
                return View();
            }
        }

       
        public ActionResult Delete(int id)
        {
            return View(this.businessLayer.GetRoleById(id));
        }

        
        [HttpPost]
        public ActionResult Delete(Role deleteRole)
        {
            try
            {
                this.businessLayer.DeleteRole(deleteRole);

                return RedirectToAction("Roles", "Admin");

            }
            catch
            {
                return View();
            }
        }
    }
}
