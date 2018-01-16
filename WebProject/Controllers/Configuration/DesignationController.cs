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
    public class DesignationController : BaseController
    {
        private readonly IAllService<DesignationModel> designService;

        public DesignationController()
        {
            designService = new DesignationService();
        }

        // GET: Designation
        public ActionResult Index()
        {
            var designations = designService.GetAllT();

            if (designations == null)
            {
                return View();
            }

            return View(@"~\Views\Configuration\Designation\Index.cshtml",designations);
        }

        public ActionResult Create()
        {
            return View(@"~\Views\Configuration\Designation\Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DesignationModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedDate = DateTime.Now;

                    designService.Add(model);

                    TempData["Success"] = $"{model.DesgName} Added !!";

                    return RedirectToAction("Index");
                }

                TempData["Danger"] = "Form Error";
            }
            catch (Exception e)
            {
                TempData["Danger"] = $"Opppps something went wrong {e.Message}";
            }

            return View(@"~\Views\Configuration\Designation\Create.cshtml");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            var designation = designService.GetOneModel(Convert.ToInt32(id));

            if (designation == null)
            {
                return View();
            }

            return View(@"~\Views\Configuration\Designation\Edit.cshtml",designation); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DesignationModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.UpdatedDate = DateTime.Now;

                    designService.Update(model);

                    TempData["Success"] = $"{model.DesgName} is Updated !!";

                    return RedirectToAction("Index");

                }

                TempData["Danger"] = "Form Error";
            }
            catch (Exception e)
            {
                TempData["Danger"] = $"Oppss something went wrong {e.Message}";
 
            }

            return View(@"~\Views\Configuration\Designation\Edit.cshtml", model.Id);
        }

        public ActionResult Delete(int? id)
        {
            try
            {

                designService.Delete(Convert.ToInt32(id));
                TempData["Success"] = "Deleted Designation !!";

                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                TempData["Danger"] = $"Opppsss Something went wrong {e.Message} !";
            }

            return RedirectToAction("Index");
 }
    }
}