using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationRepository;
using ApplicationService.Models;
namespace ApplicationService.Mapper
{
    public class OfficeMapper
    {

        public static Office OfficeModelToOffice(OfficeModel model)
        {
            var office = new Office
            {
                Id = model.Id,
                CreatedDate = model.CreatedDate,
                IsActive = model.IsActive,
                OfficeAddress = model.OfficeAddress,
                OfficeCode = model.OfficeCode,
                OfficeEmail = model.OfficeEmail,
                OfficeName = model.OfficeName,
                OfficePhone = model.OfficePhone,
                OfficeTypeId = model.OfficeTypeId,
                UpdatedDate = model.UpdatedDate,

            };

            return office;
        }

        public static OfficeModel OfficeToOfficeModel(Office model)
        {
            var officeModel = new OfficeModel
            {
                Id = model.Id,
                CreatedDate = model.CreatedDate,
                IsActive = model.IsActive,
                OfficeAddress = model.OfficeAddress,
                OfficeCode = model.OfficeCode,
                OfficeEmail = model.OfficeEmail,
                OfficeName = model.OfficeName,
                OfficePhone = model.OfficePhone,
                UpdatedDate = model.UpdatedDate,
                OfficeTypeId = model.OfficeTypeId,
                OfficeTypeName = model.OfficeType.OfficeTypeName
                
            };

            return officeModel;


        }

        public static List<OfficeModel> OfficeToOfficeModelList(List<Office> model)
        {
            var officeModelList = new List<OfficeModel>();

            foreach (var officeList in model)
            {
                officeModelList.Add(new OfficeModel
                {
                    Id = officeList.Id,
                    CreatedDate = officeList.CreatedDate,
                    IsActive = officeList.IsActive,
                    OfficeAddress = officeList.OfficeAddress,
                    OfficeCode = officeList.OfficeCode,
                    OfficeEmail = officeList.OfficeEmail,
                    OfficeName = officeList.OfficeName,
                    OfficePhone = officeList.OfficePhone,
                    UpdatedDate = officeList.UpdatedDate,
                    OfficeTypeId = officeList.OfficeTypeId,
                    OfficeTypeName = officeList.OfficeType.OfficeTypeName
                });
            }

            return officeModelList;
        }
    }
}
