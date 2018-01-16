using ApplicationRepository;
using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Mapper
{
    public class DistrictMapper
    {
        public static District DistrictModelToDistrict(DistrictModel model)
        {
            var district = new District
            {
                Id = model.Id,
                DistrictCode = model.DistrictCode,
                DistrictNameEng = model.DistrictNameEng,
                DistrictNameNp = model.DistrictNameNp,
                StateId = model.State.StateId,
                State = new State
                {
                    StateId = model.State != null ? model.State.StateId : 0
                }
        };
            return district;

        }

        public static DistrictModel DistrictToDistrictModel(District model)
        {
            var districtModel = new DistrictModel
            {
                Id = model.Id,
                DistrictCode = model.DistrictCode,
                DistrictNameEng = model.DistrictNameEng,
                DistrictNameNp = model.DistrictNameNp,
                StateId = model.State.StateId,
                State = new State
                {
                    StateId = model.State != null ? model.State.StateId : 0
                }
            };

            return districtModel;
        }

        public static List<DistrictModel> DistrictToDistrictModelList(List<District> model)
        {
            var districtList = new List<DistrictModel>();

            foreach (var item in model)
            {
                districtList.Add(new DistrictModel
                {
                    Id = item.Id,
                    DistrictCode = item.DistrictCode,
                    DistrictNameEng = item.DistrictNameEng,
                    DistrictNameNp = item.DistrictNameNp,
                    StateId = item.StateId,
                    State = new State
                    {
                        StateId = item.State != null ? item.State.StateId : 0
                    }
                });
                
            }

            return districtList;
        }
    }
}
