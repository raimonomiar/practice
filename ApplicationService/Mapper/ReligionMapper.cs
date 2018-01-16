using ApplicationRepository;
using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Mapper
{
    public class ReligionMapper
    {
        public static Religion ReligionModelToReligion(ReligionModel model)
        {
            var religion = new Religion
            {
                Id = model.Id,
                IsActive = model.IsActive,
                ReligionName = model.ReligionName
            };

            return religion;
        }

        public static ReligionModel ReligionToReligionModel(Religion model)
        {
            var religionModel = new ReligionModel
            {
                Id = model.Id,
                IsActive = model.IsActive,
                ReligionName = model.ReligionName
            };

            return religionModel;
        }

        public static List<ReligionModel> ReligionToReligionModelList(List<Religion> model)
        {
            var religionModelList = new List<ReligionModel>();

            foreach (var religionList in model)
            {
                religionModelList.Add(new ReligionModel
                {

                    Id = religionList.Id,
                    IsActive = religionList.IsActive,
                    ReligionName = religionList.ReligionName


                });
            }

            return religionModelList;
        }

    }
}
