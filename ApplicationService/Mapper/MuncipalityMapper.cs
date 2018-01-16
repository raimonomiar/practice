using ApplicationRepository;
using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Mapper
{
    public class MuncipalityMapper
    {
        public static Municipality MuncipalityModelToMunicpality(MunicipalityModel model)
        {
            var muncipality = new Municipality
            {
                Id = model.Id,
                CreatedDate = model.CreatedDate,
                DisId = model.DisId,
                MunicipalityName = model.MunicipalityName,
                MuniTypeId = model.MuniTypeId,
                UpdatedDate = model.UpdatedDate
            };

            return muncipality;
        }

        public static MunicipalityModel MuncipalityToMuncipalityModel(Municipality model)
        {

            var muncipalityModel = new MunicipalityModel
            {
                Id = model.Id,
                MuniTypeId = model.MuniTypeId,
                MunType = new MuncipalityTypeModel
                {
                    MuniType = model.MunicipalityType != null ? model.MunicipalityType.MuniType : "",
                },
                DisId = model.DisId,
                District = new DistrictModel
                {
                    DistrictNameEng = model.District != null ? model.District.DistrictNameEng : ""
                },
                MunicipalityName = model.MunicipalityName,
                CreatedDate = model.CreatedDate,
                UpdatedDate = model.UpdatedDate

            };

            return muncipalityModel;
        }

        public static List<MunicipalityModel> MunicipalityToMunicipalityModelList(List<Municipality> model)
        {
            var municipalityModelList = new List<MunicipalityModel>();

            foreach (var item in model)
            {
                municipalityModelList.Add(new MunicipalityModel
                {
                    Id = item.Id,
                    MuniTypeId = item.MuniTypeId,
                    MunType = new MuncipalityTypeModel
                    {
                        MuniType = item.MunicipalityType != null ? item.MunicipalityType.MuniType : "",
                    },
                    DisId = item.DisId,
                    District = new DistrictModel
                    {
                        DistrictNameEng = item.District != null ? item.District.DistrictNameEng : ""
                    },
                    MunicipalityName = item.MunicipalityName,
                    CreatedDate = item.CreatedDate,
                    UpdatedDate = item.UpdatedDate
                });
            }

            return municipalityModelList;
        }
    }
}
