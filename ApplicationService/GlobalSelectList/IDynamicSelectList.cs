using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ApplicationService.GlobalSelectList
{
    public interface IDynamicSelectList
    {

        IEnumerable<SelectListItem> GetRolesSelectList([Optional] int roleId);

        IEnumerable<SelectListItem> GetMunicipalityTypeList([Optional] int munTypeId);

        IEnumerable<SelectListItem> GetDistrictSelectList(int? districtId = 0);

        IEnumerable<SelectListItem> GetOfficeTypeList([Optional] int officeTypeId);

        IEnumerable<SelectListItem> GetOfficeList([Optional] int officeId);

        IEnumerable<SelectListItem> GetFiscalYearList([Optional] int fiscalYearId);

        IEnumerable<SelectListItem> GetDesignationList([Optional] int designationId);

        IEnumerable<SelectListItem> GetColorList([Optional] int colorId);

        IEnumerable<SelectListItem> GetEducationList([Optional] int eduId);

        IEnumerable<SelectListItem> GetReligionList([Optional] int regId);

        IEnumerable<SelectListItem> GetCountryList([Optional] int countryId);

        IEnumerable<SelectListItem> GetStateList([Optional] int stateId);

        IEnumerable<SelectListItem> GetIdTypeList([Optional]int idType);

        IEnumerable<SelectListItem> GetEthnicities([Optional]int ethId);

        


    }
}
