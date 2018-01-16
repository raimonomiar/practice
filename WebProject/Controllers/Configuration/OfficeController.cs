using ApplicationService.GlobalSelectList;
using ApplicationService.Implementation;
using ApplicationService.Interface;
using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace WebProject.Controllers.Configuration
{
    public class OfficeController : BaseController
    {
        private readonly IOfficeService officeService;

        private readonly IDynamicSelectList dynamicList;
        public OfficeController()
        {
            officeService = new OfficeService();

            dynamicList = new DynamicSelectList();
        }

        // GET: Office
        public ActionResult Index()
        {
            var officeList = officeService.GetAllT();

            return View(@"~\Views\Configuration\Office\Index.cshtml",officeList);
        }

        public ActionResult Create()
        {
            var office = officeService.GetEmptyModel();

            office.OfficeTypeList = dynamicList.GetOfficeTypeList();

            return View(@"~\Views\Configuration\Office\Create.cshtml",office);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OfficeModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedDate = DateTime.Now;

                    officeService.Add(model);

                    TempData["Success"] = $"{model.OfficeName} Added !";

                    return RedirectToAction("Index");
                }

                model.OfficeTypeList = dynamicList.GetOfficeTypeList();

                return View(@"~\Views\Configuration\Office\Create.cshtml", model); 

            }
            catch (Exception e)
            {
             
                TempData["Danger"] = $"Opppsss something went wrong {e.Message}";

                throw;
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var office = officeService.GetOneModel(Convert.ToInt32(id));

            office.OfficeTypeList = dynamicList.GetOfficeTypeList();

            return View(@"~\Views\Configuration\Office\Edit.cshtml", office);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OfficeModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.UpdatedDate = DateTime.Now;

                    officeService.Update(model);

                    TempData["Success"] = $"{model.OfficeName} is updated !";

                    return RedirectToAction("Index");
                }

                model.OfficeTypeList = dynamicList.GetOfficeTypeList();

                return View(@"~\Views\Configuration\Office\Edit.cshtml", model);
            }
            catch (Exception e)
            {
                TempData["Danger"] = $"Oppss Something went wrong {e.Message}";
                throw;
            }
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var office = officeService.GetOneModel(Convert.ToInt32(id));

            if (office==null)
            {
                return HttpNotFound();
            }

            return View(@"~\Views\Configuration\Office\Details.cshtml", office);

        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                officeService.Delete(id);

                TempData["Success"] = "Office Deleted Successfully !";

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["Danger"] = $"Opps something went wrong {e.Message} !";

            }

            return RedirectToAction("Index");

        }




    }
}