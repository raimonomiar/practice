using ApplicationService.Implementation;
using ApplicationService.Interface;
using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebProject.Controllers.Configuration
{
    public class EducationController : BaseController
    {
        private readonly IAllService<EducationLevelModel> educationService;

        public EducationController()
        {
            educationService = new EducationLevelService();
        }

        // GET: Education
        public ActionResult Index()
        {
            var educationLevels = educationService.GetAllT();

            if (educationLevels == null)
            {
                return View();
            }

            return View(@"~\Views\Configuration\Education\Index.cshtml",educationLevels);
        }

        public ActionResult Create()
        {
            return View(@"~\Views\Configuration\Education\Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Create(EducationLevelModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    educationService.Add(model);

                    TempData["Success"] = $"{model.LevelName} Added !";

                    return RedirectToAction("Index");
                }
                return View(@"~\Views\Configuration\Education\Create.cshtml", model);

            }
            catch (Exception e)
            {
                TempData["Danger"] = $"Opps something went wrong {e.Message}";

                throw;
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var education = educationService.GetOneModel(Convert.ToInt32(id));

            if (education == null)
            {
                return HttpNotFound();
            }

            return View(@"~\Views\Configuration\Education\Edit.cshtml", education);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EducationLevelModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    educationService.Update(model);

                    TempData["Success"] = $"{model.LevelName} is updated";

                    return RedirectToAction("Index");
                }

                return View(@"~\Views\Configuration\Education\Edit.cshtml", model);
            }
            catch (Exception e)
            {
                TempData["Danger"] = $"Opps something went wrong {e.Message}";

                throw;
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                educationService.Delete(Convert.ToInt32(id));

                TempData["Success"] = "Education level deleted !";

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["Danger"] = $"Oppps something went wrong {e.Message} ";

                throw;
            }
        }

    }
}