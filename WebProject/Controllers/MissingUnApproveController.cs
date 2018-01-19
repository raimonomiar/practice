using ApplicationService.GlobalSelectList;
using ApplicationService.Implementation;
using ApplicationService.Interface;
using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.App_Classes;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class MissingUnApproveController : Controller
    {
        private readonly IMissingService missingService;

        private readonly IAllService<PhotoModel> photoService;

        private readonly IDynamicSelectList dynamicSelectList;

        public MissingUnApproveController()
        {
            missingService = new MissingService();

            photoService = new PhotoService();

            dynamicSelectList = new DynamicSelectList();
        }
        // GET: MissingUnApprove
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Create()
        {
            var missingUnApproveViewModel = new MissingUnApproveViewModel
            {
                MissingModel = missingService.GetEmptyModel(),
                FiscalYearList = dynamicSelectList.GetFiscalYearList(),
                GenderList = StaticSelectList.GenderList()

            };

            return View(missingUnApproveViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MissingUnApproveViewModel model)
        {
            try
            {
                model.MissingModelList = missingService.MissingMatches(model.MissingModel).ToList();

                if (model.MissingModelList.Count>0)
                {
                    model.IsMatches = true;

                    model.MissingCount = model.MissingModelList.Count;
                }

                //found matches here

                //deadbody matches here

                if (missingService.RegistrationNumberExist(Convert.ToInt32(model.MissingModel.OfficeId), Convert.ToInt32(model.MissingModel.FiscalYearId), model.MissingModel.RegistrationNumber))
                {
                    TempData["Danger"] = $"{model.MissingModel.RegistrationNumber} Already exists please select another one !";

                    return View(model);
                }

                    if (Request.Form["yes"] == "yes" || !model.IsMatches)
                {
                    try
                    {
                       
                        if (ModelState.IsValid)
                        {
                            model.MissingModel.OfficeId = Convert.ToInt32(Session["OfficeId"]);

                            model.MissingModel.UserId = Convert.ToInt32(Session["OfficeId"]);

                            model.MissingModel.VerifyStatus = "P";

                            model.MissingModel.EnteredDate = DateTime.Now;

                            model.MissingModel.MissingStatus = Convert.ToByte(AppGeneral.MissingStatusValue.Missing);

                            model.MissingModel.Id = missingService.AddMissing(model.MissingModel).Id;
                            TempData["Success"] = $"{model.MissingModel.Fname} Record Added , Now Add full details please !!";
                            return RedirectToAction("Index", "MissingUnApproveController", new { id = model.MissingModel.Id });


                        }

                        TempData["Danger"] = string.Join("|" ,ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));

                        model.FiscalYearList = dynamicSelectList.GetFiscalYearList();

                        model.GenderList = StaticSelectList.GenderList();

                        return View(model);
                    }
                    catch (DbEntityValidationException ex)
                    {
                        TempData["Danger"] = $"Opps something went wrong { string.Join(";", ex.EntityValidationErrors.SelectMany(e => e.ValidationErrors).Select(e => e.ErrorMessage))}"; 
                    }
                }
                model.FiscalYearList = dynamicSelectList.GetFiscalYearList();

                model.GenderList = StaticSelectList.GenderList();
                return View(model);

            }
            catch (Exception e)
            {

                TempData["Danger"] = $"Ooops something went wrong {e.Message}";

                model.FiscalYearList = dynamicSelectList.GetFiscalYearList();

                model.GenderList = StaticSelectList.GenderList();
                return View(model); 
            }
        }
    }
}