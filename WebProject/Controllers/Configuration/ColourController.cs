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
    public class ColourController : BaseController
    {

        private  IAllService<ColourModel> colourService;

        public ColourController()
        {
            colourService = new ColourService();
        }

        // GET: Colour
        public ActionResult Index()
        {
            var colours = colourService.GetAllT()
                .OrderBy(x=>x.ColourName)
                .ToList();

            if (colours ==null)
            {
                return View();
            }


            return View(@"~\Views\Configuration\Colour\Index.cshtml",colours);
        }

        //[ChildActionOnly]
        public ActionResult Create() => View(@"~\Views\Configuration\Colour\Create.cshtml");

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ColourModel model)
        {
      
            if (ModelState.IsValid)
            {

                colourService.Add(model);

                TempData["Success"] = $"{model.ColourName} colour Added !!";

                return RedirectToAction("Index");

            }
                
            return View(@"~\Views\Configuration\Colour\Create.cshtml");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var colour = colourService.GetOneModel(Convert.ToInt32(id));

            if (colour == null)
            {
                return HttpNotFound();
            }

            return View(@"~\Views\Configuration\Colour\Edit.cshtml",colour);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ColourModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    colourService.Update(model);

                    TempData["Success"] = $"{model.ColourName} colour updated!!";

                    return RedirectToAction("Index");
                }

                TempData["Danger"] = $"Form error!!";
            }
            catch (Exception ex)
            {
                TempData["Danger"] = $"Something went wrong {ex.Message}";
            }
            

            return View(@"~\Views\Configuration\Colour\Index.cshtml", model);
        }

        public ActionResult Delete(int? id)
        {
            try
            {
                colourService.Delete(id);

                TempData["Success"] = "Deleted successfully";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Danger"] = $"Something went wrong {ex.Message}";
            }
            return RedirectToAction("Index");
        }
    }
}