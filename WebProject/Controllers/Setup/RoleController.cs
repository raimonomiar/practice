using ApplicationService.Implementation;
using ApplicationService.Interface;
using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProject.Controllers
{
    public class RoleController : BaseController
    {
        private ISetupService _setupService;

        public RoleController()
        {
            _setupService = new SetupService();
        }
        // GET: Role
        public ActionResult Index()
        {
            var roleLists = _setupService.GetAllRoles();

            return View(@"~\Views\Setup\Role\Index.cshtml", roleLists);
        }

        public ActionResult Create() => View(@"~\Views\Setup\Role\Create.cshtml", new RolesModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RolesModel model)
        {
            if (model == null)
            {
                return View(model);

            }
            try
            {
                if (ModelState.IsValid)
                {
                    _setupService.AddRole(model);

                    TempData["Success"] = "Role Created Successfully";

                    return RedirectToAction("Index", "Role");
                }

                TempData["Danger"] = "Form Error";
            }
            catch (Exception e)
            {
                TempData["Danger"] = e.Message; 
                
            }
        
            return View(@"~\Views\Setup\Role\Index.cshtml",model);
        }

        public ActionResult Update(int id)
        {
            if (id == 0)
            {
                return View();

            }

            var getRole = _setupService.GetOneRole(id);

            return View(@"~\Views\Setup\Role\Update.cshtml",getRole);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(RolesModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Danger"] = "Form Error";

                    return View(model);
                }

                _setupService.UpdateRole(model);

                TempData["Success"] = "Role Updated Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                TempData["Danger"] = e.Message;
            }

            return View(@"~\Views\Setup\Role\Update.cshtml", model);
        }


        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                TempData["Danger"] = "Passed Number not valid";
                return View();
            }
            try
            {
                _setupService.DeleteRole(id);

                TempData["Success"] = "Deleted Successfully !!";

            }
            catch (Exception e)
            {

                TempData["Danger"] = e.Message;
            }

            return RedirectToAction("Index");
        }
    }
}