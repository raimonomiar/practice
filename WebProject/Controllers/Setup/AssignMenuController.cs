using ApplicationRepository;
using ApplicationRepository.UnitOfWork;
using ApplicationService.Implementation;
using ApplicationService.Interface;
using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace WebProject.Controllers.Setup
{
    public class AssignMenuController : BaseController
    {

        private readonly ISetupService setupService;

        private readonly practiceEntities DB;

        public AssignMenuController()
        {
            setupService = new SetupService();

            DB = new practiceEntities();    
        }


        // GET: AssignMenu
        public ActionResult Index()
        {
            var roles = setupService.GetAllRoles();

            return View(@"~\Views\Setup\AssignMenu\Index.cshtml",roles);
        }

        public ActionResult RoleMenuAccess(int id)
        {
            var roleAcessList = setupService.GetRoleAccess(id);

            var role = DB.Roles.Find(id);

            if (role !=null)
            {
                ViewBag.RoleName = role.Name;
            }

            return View(@"~\Views\Setup\AssignMenu\AssignMenuAccess.cshtml",roleAcessList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleMenuAccess(AssignMenuModel model)
        {
            try
            {
                setupService.AddRoleAccess(model);

                TempData["Success"] = $"Access Updated!!";
            }
            catch (Exception ex)
            {
                TempData["Danger"] = $"Something went wrong {ex.Message}";

                return RedirectToAction("Index");

            }

            int id = model.Id;

            var roleAcessList = setupService.GetRoleAccess(id);

            var role = DB.Roles.Find(id);
            if (role != null)
            {
                ViewBag.RoleName = role.Name;
            }
            return View(@"~\Views\Setup\AssignMenu\AssignMenuAccess.cshtml", roleAcessList);

        }



    }
}