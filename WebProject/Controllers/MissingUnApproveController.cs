using ApplicationService.GlobalSelectList;
using ApplicationService.Implementation;
using ApplicationService.Interface;
using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
                FiscalYear = dynamicSelectList.GetFiscalYearList(),
                OfficeList = dynamicSelectList.GetOfficeTypeList(),
                GenderList = StaticSelectList.GenderList()
                
            };

            return View(missingUnApproveViewModel);
        }
    }
}