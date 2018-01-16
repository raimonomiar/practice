using ApplicationService.GlobalSelectList;
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
    public class MunicipalityController : BaseController
    {
        private readonly IMunicipalityService munService;

        private readonly IDynamicSelectList dynamicList; 

        public MunicipalityController()
        {
            munService = new MunicipalityService();

            dynamicList = new DynamicSelectList();
        }

        // GET: Municipality
        public ActionResult Index()
        {
            var municipalitiesList = munService.GetAllMunicipalityRecord();

            if (municipalitiesList == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(@"~\Views\Configuration\Municipality\Index.cshtml",municipalitiesList);
        }

        public ActionResult Create()
        {
            var muncipality = munService.GetEmptyModel();

            muncipality.DistrictList = dynamicList.GetDistrictSelectList();

            muncipality.MunicipalityTypeList = dynamicList.GetMunicipalityTypeList();

            return View(@"~\Views\Configuration\Municipality\Create.cshtml", muncipality);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MunicipalityModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedDate = DateTime.Now;

                    munService.Add(model);

                    TempData["Success"] = $"{model.MunicipalityName} added !!";

                    return RedirectToAction("Index");

                }

                TempData["Danger"] = "Form Error";
            }
            catch (Exception e)
            {
                TempData["Danger"] = $"Something went wrong {e.Message}";
                
            }

            model.DistrictList = dynamicList.GetDistrictSelectList();

            model.MunicipalityTypeList = dynamicList.GetMunicipalityTypeList();

            return View(@"~\Views\Configuration\Municipality\Create.cshtml", model);


            
        }

        public ActionResult Edit(int? id)
        {
            var municipality = munService.GetOneMunicipalityRecord(Convert.ToInt32(id));

            if (municipality == null)
            {
                return View();
            }

            municipality.DistrictList = dynamicList.GetDistrictSelectList();

            municipality.MunicipalityTypeList = dynamicList.GetMunicipalityTypeList();

            return View(@"~\Views\Configuration\Municipality\Edit.cshtml", municipality);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MunicipalityModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.UpdatedDate = DateTime.Now;

                    munService.Update(model);

                    TempData["Success"] = $"{model.MunicipalityName} is updated!!";

                    return RedirectToAction("Index");
                }

                TempData["Danger"] = "Something went wrong Form error";
            }
            catch (Exception e)
            {
                TempData["Danger"] = $"Oppppsss something went wrong {e.Message}";
            }

            model.MunicipalityTypeList = dynamicList.GetMunicipalityTypeList();

            model.DistrictList = dynamicList.GetDistrictSelectList();

            return View(@"~\Views\Configuration\Municipality\Edit.cshtml", model);

        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var municipality = munService.GetOneMunicipalityRecord(Convert.ToInt32(id));

            if (municipality == null)
            {
                return RedirectToAction("Index");
            }

            return View(@"~\Views\Configuration\Municipality\Details.cshtml",municipality);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                munService.Delete(id);

                TempData["Success"] = "Successfully Deleted!!";

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["Danger"] = $"Opppps something went wrong {e.Message}";
            }

            return RedirectToAction("Index");



        }

    }
}