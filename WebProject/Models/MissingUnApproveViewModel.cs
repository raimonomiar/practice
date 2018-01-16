using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProject.Models
{
    public class MissingUnApproveViewModel
    {
        public IEnumerable<SelectListItem> GenderList { set; get; }

        public IEnumerable<SelectListItem> OfficeList { get; set; }

        public IEnumerable<SelectListItem> FiscalYearList { get; set; }

        public MissingModel MissingModel{ get; set; }

        public List<MissingModel> MissingModelList { get; set; }

        public bool IsMatches { get; set; }

        public int? MissingCount { get; set; }


    }
}