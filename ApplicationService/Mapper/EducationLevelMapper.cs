using ApplicationRepository;
using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Mapper
{
    public class EducationLevelMapper
    {
        public static EducationLevel EducationLevelModelToEducationLevel(EducationLevelModel model)
        {
            var educationLevelModel = new EducationLevel
            {
                Id = model.Id,
                DisplayOrder = model.DisplayOrder,
                IsActive = model.IsActive,
                LevelName = model.LevelName

            };

            return educationLevelModel;
        }

        public static EducationLevelModel EducationLevelToEducationLevelModel(EducationLevel model)
        {
            var educationLevelModel = new EducationLevelModel
            {
                Id = model.Id,
                DisplayOrder = model.DisplayOrder,
                IsActive = model.IsActive,
                LevelName = model.LevelName
            };

            return educationLevelModel;
        }


        public static  List<EducationLevelModel> EducationLevelToEducationLevelModelList(List<EducationLevel> model)
        {
            var educationLevelModelList = new List<EducationLevelModel>();

            foreach (var eduModel in model)
            {

                educationLevelModelList.Add(new EducationLevelModel
                {
                    Id = eduModel.Id,
                    DisplayOrder = eduModel.DisplayOrder,
                    IsActive = eduModel.IsActive,
                    LevelName = eduModel.LevelName
                });
            }

            return educationLevelModelList;
        }
    }
}
