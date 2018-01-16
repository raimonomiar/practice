using ApplicationRepository;
using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Mapper
{
    public class DesignationMapper
    {
        public static Designation DesignationModelToDesignation(DesignationModel model)
        {
            var designation = new Designation
            {
                Id = model.Id,
                Code = model.Code,
                CreatedDate = model.CreatedDate,
                DesgName = model.DesgName,
                DiplayOrder = model.DiplayOrder,
                UpdatedDate = model.UpdatedDate
            };

            return designation;

        }

        public static DesignationModel DesignationToDesignationModel(Designation model)
        {
            var designationModel = new DesignationModel
            {
                Id = model.Id,
                Code = model.Code,
                CreatedDate = model.CreatedDate,
                DesgName = model.DesgName,
                DiplayOrder = model.DiplayOrder,
                UpdatedDate = model.UpdatedDate
            };

            return designationModel;
        }

        public static List<DesignationModel> DesignationToDesignationModelList(List<Designation> model)
        {
            var designationList = new List<DesignationModel>();

            foreach (var designation in model)
            {
                designationList.Add(new DesignationModel
                {
                    Id = designation.Id,
                    Code = designation.Code,
                    CreatedDate = designation.CreatedDate,
                    DesgName = designation.DesgName,
                    DiplayOrder = designation.DiplayOrder,
                    UpdatedDate = designation.UpdatedDate
                });
            }

            return designationList;
        }
    }
}
