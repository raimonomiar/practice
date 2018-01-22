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

        public IEnumerable<SelectListItem> ColourList { get; set; }

        public IEnumerable<SelectListItem> EducationList{ get; set; }

        public IEnumerable<SelectListItem> ReligionList { get; set; }


        public IEnumerable<SelectListItem> CountryList { get; set; }

        public IEnumerable<SelectListItem> StateList { get; set; }

        public IEnumerable<SelectListItem> DistrictList { get; set; }

        public IEnumerable<SelectListItem> MunicipalitiesList { get; set; }

        public IEnumerable<SelectListItem> IdTypeList{ get; set; }

        public IEnumerable<SelectListItem> EthnicityList { get; set; }

        public IEnumerable<SelectListItem> MartialStatusList { get; set; }

        public IEnumerable<SelectListItem> PersonTypeList { get; set; }

        public IEnumerable<SelectListItem> HeightUnitList { get; set; }


        public IEnumerable<SelectListItem> PDistrictList { get; set; }

        public IEnumerable<SelectListItem> TDistrictList { get; set; }

        public IEnumerable<SelectListItem> MDistrictList { get; set; }

        public IEnumerable<SelectListItem> PMunicipalityList{ get; set; }

        public IEnumerable<SelectListItem> TMunicipalityList{ get; set; }

        public IEnumerable<SelectListItem> MMunicipalityList { get; set; }

        public IEnumerable<PhotoModel> PhotoList { get; set; }

        public MissingModel MissingModel { get; set; }

        public List<MissingModel> MissingModelList { get; set; }

        public bool IsMatches { get; set; }

        public int? MissingCount { get; set; }

        public int? FiscalYearId { get; set; }


    }
}