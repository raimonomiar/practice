using ApplicationService.GlobalSelectList;
using ApplicationService.Implementation;
using ApplicationService.Interface;
using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProject.Controllers
{
    public class MissingController : BaseController
    {
        private readonly IMissingService missingService;

        private readonly IDynamicSelectList dynamicSelectList;

        private readonly IAllService<PhotoModel> photoService;

        private const int paageSize = 5;


        public MissingController()  
        {
            missingService = new MissingService();

            dynamicSelectList = new DynamicSelectList();

            photoService = new PhotoService();
        }
        // GET: Missing
        public ActionResult Index()
        {
            return View();
        }
    }
}