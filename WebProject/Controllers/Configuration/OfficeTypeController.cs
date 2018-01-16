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
    public class OfficeTypeController : BaseController
    {
        private readonly IAllService<OfficeTypeModel> officeTypeService;

        public OfficeTypeController()
        {
            officeTypeService = new OfficeTypeService();
        }

        // GET: OfficeType
        public ActionResult Index()
        {
            var offficeType = officeTypeService.GetAllT();

            if (offficeType == null)
            {
                return View();
            }

            return View(@"~\Views\Configuration\OfficeType\Index.cshtml", offficeType);
        }

        public ActionResult Create()
        {
            return View(@"~\Views\Configuration\OfficeType\Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OfficeTypeModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedDate = DateTime.Now;

                    officeTypeService.Add(model);

                    TempData["Success"] = $"{model.OfficeTypeName} Added !";

                    return RedirectToAction("Index");
                }

                return View(@"~\Views\Configuration\OfficeType\Create.cshtml",model);

            }
            catch (Exception e)
            {
                TempData["Danger"] = $"Oppss Something went wrong {e.Message} !";

                throw;
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var office = officeTypeService.GetOneModel(Convert.ToInt32(id));

            if (office == null)
            {

                return HttpNotFound();
            }

            return View(@"~\Views\Configuration\OfficeType\Edit.cshtml", office);    
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OfficeTypeModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    model.UpdatedDate = DateTime.Now;

                    officeTypeService.Update(model);

                    TempData["Success"] = $"{model.OfficeTypeName} is updated";

                    return RedirectToAction("Index");
                }

                return View(@"~\Views\Configuration\OfficeType\Edit.cshtml", model);

            }
            catch (Exception e)
            {
                TempData["Danger"] = $"Oppsss something went wrong {e.Message}";

                throw;
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            try
            {

                officeTypeService.Delete(id);

                TempData["Success"] = "OfficeType Deleted Successfully !";

                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                TempData["Danger"] = $"Opps Something went wrong {e.Message}";

                throw;
            } 
        }

    }
}