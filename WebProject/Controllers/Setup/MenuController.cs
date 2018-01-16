using ApplicationService.Implementation;
using ApplicationService.Interface;
using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebProject.Controllers.Setup
{
    public class MenuController : BaseController
    {

        private readonly ISetupService setupService;

        public MenuController()
        {
            setupService = new SetupService();
        }

        // GET: Menu
        public ActionResult Index()
        {
            var menus = setupService.GetAllMenus();

            return View(@"~\Views\Setup\Menu\Index.cshtml", menus);
        }


        public ActionResult Create()
        {
            var menuModel = new MenuModel
            {
                ParentMenu = setupService.GetParenMenus()
            };

            return View(@"~\Views\Setup\Menu\Add.cshtml",menuModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MenuModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    setupService.AddMenu(model);

                    TempData["Success"] = $"{model.Name} Menu Added !!";

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["Danger"] = $"Something went wrong {ex.Message}";
            }

            model.ParentMenu = setupService.GetParenMenus();

            return View(@"~\Views\Setup\Menu\Add.cshtml",model);
        }


        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var menu = setupService.GetOneMenu(Id);

            if (menu == null)
            {
                return HttpNotFound();
            }

            menu.ParentMenu = setupService.GetParenMenus();

            return View(@"~\Views\Setup\Menu\Edit.cshtml", menu);




        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MenuModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    setupService.UpdateMenu(model);

                    TempData["Success"] = $"{model.Name} Menu Updated!!";

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["Danger"] = $"Oppss something went wrong {ex.Message} ";
            }

            model.ParentMenu = setupService.GetParenMenus();

            return View(@"~\Views\Setup\Menu\Edit.cshtml", model);

        }


    }
}