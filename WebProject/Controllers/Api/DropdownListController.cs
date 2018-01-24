using ApplicationService.GlobalSelectList;
using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebProject.Controllers.Api
{
    public class DropdownListController : ApiController
    {
        private readonly IDynamicSelectList dynamicSelectList;

        public DropdownListController()
        {
            dynamicSelectList = new DynamicSelectList();
        }

        [HttpGet]
        public IHttpActionResult GetDistrict(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var selectedDistricts = dynamicSelectList.GetDistrictListByStateId(id);

            return Ok(selectedDistricts);
        }

        [HttpGet]
        public IHttpActionResult GetMunicipality(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var selectedMunicipalities = dynamicSelectList.GetMunicipalityListByDistrictId(id);

            return Ok(selectedMunicipalities);
        }
    }
}
