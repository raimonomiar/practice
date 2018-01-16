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
    public class ReligionController : BaseController
    {

        private readonly IAllService<ReligionModel> religionService;

        public ReligionController()
        {
            religionService = new ReligionService();
        }
        // GET: Religionoller
        public ActionResult Index()
        {
            var religions = religionService.GetAllT();

            if (religions == null)
            {
                return View();
            }

            return View(@"~\Views\Configuration\Religion\Index.cshtml",religions);
        }

        public ActionResult Create()
        {
            return View(@"~\Views\Configuration\Religion\Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReligionModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    religionService.Add(model);

                    TempData["Success"] = $"{model.ReligionName} Added !";

                    return RedirectToAction("Index");
                }

                return View(@"~\Views\Configuration\Religion\Create.cshtml",model);

            }
            catch (Exception e)
            {
                TempData["Danger"] = $"Something went wrong {e.Message} ";
                throw;
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var religion = religionService.GetOneModel(Convert.ToInt32(id));

            if (religion == null)
            {
                return HttpNotFound();
            }

            return View(@"~\Views\Configuration\Religion\Edit.cshtml",religion);


        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReligionModel model)
        {
            try
            {
                if (ModelState.IsValid )
                {
                    religionService.Update(model);

                    TempData["Success"] = $"{model.ReligionName} Updated !";

                    return RedirectToAction("Index");
                }

                return View(@"~\Views\Configuration\Religion\Edit.cshtml", model);

            }
            catch (Exception e)
            {
                TempData["Danger"] = $"Opps something went wrong {e.Message}";

                throw;
            }
        }

        public ActionResult Delete(int? id)
        {
            
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                religionService.Delete(id);

                TempData["Success"] = $"Religion Deleted Successfully";

               return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                TempData["Danger"] = $"Oppsss something {e.Message}";

                throw;
            }


        }
    }
}