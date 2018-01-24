using System.Collections.Generic;
using System.Runtime.InteropServices;
using ApplicationService.Models;
using ApplicationRepository.UnitOfWork;
using ApplicationRepository;
using System.Web.Mvc;
using System.Linq;
using System;

namespace ApplicationService.GlobalSelectList
{
    public class DynamicSelectList : IDynamicSelectList
    {
        private readonly practiceEntities DB = new practiceEntities();

        private readonly IUnitOfWork unitOfWork;

        public DynamicSelectList(IUnitOfWork _unitOfWork = null)
        {
            unitOfWork = _unitOfWork ?? new UnitOfWork();
        }

        public IEnumerable<SelectListItem> GetRolesSelectList([Optional] int roleId)
        {
            List<SelectListItem> roleSelectList = new List<SelectListItem>();

            var getRoles = unitOfWork.RoleRepository.All().ToList();

            foreach (var item in getRoles)
            {
                roleSelectList.Add(new SelectListItem
                {
                    Selected = roleId == item.RoleId,
                    Value = item.RoleId.ToString(),
                    Text = item.Name
                });
            }
            return roleSelectList;
        }

        public IEnumerable<SelectListItem> GetDistrictSelectList(int? districtId = 0)
        {
            var list = new List<SelectListItem>();

            var districts = unitOfWork.DistrictRepository.All().ToList();

          

            foreach (var district in districts)
            {
                list.Add(new SelectListItem
                {
                    Value = district.Id.ToString(),
                    Text = district.DistrictNameEng,
                    Selected = districtId == district.Id
                });
            }

            return list;
        }

        public IEnumerable<SelectListItem> GetMunicipalityTypeList([Optional] int munTypeId)
        {

            var municipalityTypeList = unitOfWork.MunicipalityTypeRepository.All().ToList();

            var list = new List<SelectListItem>();

            foreach (var item in municipalityTypeList)
            {
                list.Add(new SelectListItem
                {
                    Value = item.id.ToString(),
                    Text = item.MuniType,
                    Selected = munTypeId == item.id
                });
            }

            return list;
        }

        public IEnumerable<SelectListItem> GetOfficeTypeList([Optional] int officeTypeId )
        {
            var officeTypeList = unitOfWork.OfficeTypeRepository.All().ToList();

            var list = new List<SelectListItem>();

            foreach (var item in officeTypeList)
            {
                list.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.OfficeTypeName,
                    Selected = officeTypeId == item.Id
                });

            }

            return list;
        }

        public IEnumerable<SelectListItem> GetFiscalYearList([Optional] int fiscalYearId)
        {
            var list = new List<SelectListItem>();

            var fiscalYearList = unitOfWork.FiscalYearRepository
                .All().ToList();

            foreach (var item in fiscalYearList)
            {
                list.Add(new SelectListItem
                {
                    Selected = fiscalYearId == item.Id,
                    Value = item.Id.ToString(),
                    Text = item.FiscalYearName
                });
            }
                

            return list;
        }

        public IEnumerable<SelectListItem> GetOfficeList([Optional] int officeId)
        {
            var officeList = unitOfWork.OfficeRepository
                .All()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.OfficeName,
                    Selected = officeId == x.Id
                })
                .ToList();

            return officeList;
        }

        public IEnumerable<SelectListItem> GetDesignationList([Optional] int designationId)
        {
            var designationList = unitOfWork.DesignationRepository
                .All()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.DesgName,
                    Selected = designationId == x.Id
                })
                .ToList();

            return designationList;
        }

        public IEnumerable<SelectListItem> GetColorList([Optional] int colorId) =>
            unitOfWork.ColourRepository
            .All()
            .Select(x => new SelectListItem
            {
                Value = x.id.ToString(),
                Text = x.ColourName,
                Selected = colorId == x.id
            })
            .ToList();

        public IEnumerable<SelectListItem> GetEducationList([Optional] int eduId) =>
            unitOfWork.EducationLevelRepository
            .All()
            .Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.LevelName,
                Selected = eduId == x.Id
            })
            .ToList();

        public IEnumerable<SelectListItem> GetReligionList([Optional] int regId) =>
            unitOfWork.ReligionRepository
            .All()
            .Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.ReligionName,
                Selected = regId == x.Id
            })
            .ToList();

        public IEnumerable<SelectListItem> GetCountryList([Optional] int countryId) =>
            unitOfWork.CountryRepository
            .All()
            .Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.CountryName,
                Selected = countryId == x.Id
            })
            .ToList();

        public IEnumerable<SelectListItem> GetStateList([Optional] int stateId) =>
            unitOfWork.StateRepository
            .All()
            .Select(x => new SelectListItem
            {
                Value = x.StateId.ToString(),
                Text = x.StateName,
                Selected = stateId == x.StateId
            })
            .ToList();

        public IEnumerable<SelectListItem> GetIdTypeList([Optional] int idType) =>
            unitOfWork.IdTypeRepository
            .All()
            .Select(x => new SelectListItem
            {
                Value = x.id.ToString(),
                Text = x.IdTypeName,
                Selected = idType == x.id
            })
            .ToList();

        public IEnumerable<SelectListItem> GetEthnicities([Optional] int ethId) =>
            unitOfWork.EthnicityRepository
            .All()
            .Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.EthnicityName,
                Selected = ethId == x.Id
            })
            .ToList();

        public IEnumerable<SelectListItem> GetDistrictListByStateId(int? stateId = 0)
        {
            var districtList = new List<SelectListItem>();

            var districts = stateId != 0 ? unitOfWork.DistrictRepository
                .Get(x => x.StateId == stateId).ToList() : unitOfWork.DistrictRepository.All().ToList();

            foreach (var item in districts)
            {
                districtList.Add(new SelectListItem
                {
                    Text = item.DistrictNameEng,
                    Value = item.Id.ToString(),
                    Selected = stateId == item.StateId
                });
            }
            return districtList;
            
        }

        public IEnumerable<SelectListItem> GetMunicipalityListByDistrictId(int? districtId = 0)
        {
            var municipalityList = new List<SelectListItem>();

            if (districtId !=0)
            {
                municipalityList = unitOfWork.MunicipalityRepository
                    .Get(x => x.DisId == districtId)
                    .Select(x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.MunicipalityName,
                        Selected = districtId == x.DisId
                    })
                    .ToList();
            }

            return municipalityList;
        }
    }
}
