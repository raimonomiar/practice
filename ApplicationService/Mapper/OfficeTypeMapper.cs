using ApplicationRepository;
using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Mapper
{
    public class OfficeTypeMapper
    {
        public static OfficeType OfficeTypeModelToOfficeType(OfficeTypeModel model)
        {
            var officeType = new OfficeType
            {
                Id = model.Id,
                CreatedDate = model.CreatedDate,
                OfficeTypeName = model.OfficeTypeName,
                UpdatedDate = model.UpdatedDate
            };

            return officeType;
        }

        public static OfficeTypeModel OfficeTypeToOfficeTypeModel(OfficeType model)
        {
            var officeTypeModel = new OfficeTypeModel
            {
                Id = model.Id,
                CreatedDate = model.CreatedDate,
                OfficeTypeName = model.OfficeTypeName,
                UpdatedDate = model.UpdatedDate
            };

            return officeTypeModel;
        }

        public static List<OfficeTypeModel> OfficeToOfficeTypeModelList(List<OfficeType> model)
        {
            var officeTypeList = new List<OfficeTypeModel>();

            foreach (var officeType in model)
            {
                officeTypeList.Add(new OfficeTypeModel
                {
                    Id = officeType.Id,
                    CreatedDate = officeType.CreatedDate,
                    OfficeTypeName = officeType.OfficeTypeName,
                    UpdatedDate = officeType.UpdatedDate

                });
                  
            }

            return officeTypeList;
        }
        
    }
}
