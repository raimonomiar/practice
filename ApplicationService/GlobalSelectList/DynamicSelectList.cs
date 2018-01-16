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
            var fiscalYearList = unitOfWork.FiscalYearRepository
                .All()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.FiscalYearName,
                    Selected = fiscalYearId == x.Id
                })
                .ToList();

            return fiscalYearList;
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

    }
}
