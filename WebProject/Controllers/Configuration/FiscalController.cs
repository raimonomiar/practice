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
    public class FiscalController : BaseController
    {
        private IFiscalYearService fiscalService;

        public FiscalController()
        {
            fiscalService = new FiscalYearService();
        }
        // GET: Fiscal
        public ActionResult Index()
        {
            var fiscalYears = fiscalService.GetAllT();

            return View(@"~\Views\Configuration\FiscalYear\Index.cshtml",fiscalYears);
        }

        public ActionResult Create()
        {
            return View(@"~\Views\Configuration\FiscalYear\Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FiscalYearModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedDate = DateTime.Now;

                    model.StartDateNp = "";
                    model.EndDateNp = "";
                    fiscalService.Add(model);

                    TempData["Success"] = $"{model.FiscalYearName} Added !";

                    return RedirectToAction("Index");
                }

                return View(@"~\Views\Configuration\FiscalYear\Create.cshtml", model);

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

            var fiscalYear = fiscalService.GetOneModel(Convert.ToInt32(id));

            if (fiscalYear == null)
            {
                return HttpNotFound();
            }

            return View(@"~\Views\Configuration\FiscalYear\Edit.cshtml", fiscalYear);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FiscalYearModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.UpdatedDate = DateTime.Now;

                    model.StartDateNp = "";

                    model.EndDateNp = "";

                    fiscalService.Update(model);

                    TempData["Success"] = $"{model.FiscalYearName} is updated !";

                    return RedirectToAction("Index");
                }

                return View(@"~\Views\Configuration\FiscalYear\Edit.cshtml", model);
            }
            catch (Exception e)
            {
                TempData["Danger"] = $"Oppps something went wrong {e.Message}";

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

                fiscalService.Delete(id);

                TempData["Success"] = "Deleted Successfully !";

                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                TempData["Danger"] = $"Oppsss something went wrong {e.Message}";

                throw;
            }
        }





    }
}