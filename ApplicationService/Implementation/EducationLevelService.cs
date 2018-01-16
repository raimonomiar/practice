using System;
using System.Collections.Generic;
using ApplicationService.Interface;
using ApplicationService.Models;
using ApplicationRepository.UnitOfWork;
using System.Linq;

namespace ApplicationService.Implementation
{
    public class EducationLevelService : IAllService<EducationLevelModel>
    {
        private readonly IUnitOfWork unitOfWork;
        public EducationLevelService(IUnitOfWork _unitOfWork = null)
        {
            unitOfWork = _unitOfWork ?? new UnitOfWork();
        }
        public void Add(EducationLevelModel model)
        {
            var educationLevel = Mapper.EducationLevelMapper.EducationLevelModelToEducationLevel(model);

            unitOfWork.EducationLevelRepository.Create(educationLevel);
        }

        public void Delete(object id)
        {
            unitOfWork.EducationLevelRepository.Delete(id);
        }

        public List<EducationLevelModel> GetAllT()
        {
            var educationLevelList = unitOfWork.EducationLevelRepository.All().OrderBy(x => x.DisplayOrder).ToList();

            var educationLevelModelList = Mapper.EducationLevelMapper.EducationLevelToEducationLevelModelList(educationLevelList);

            return educationLevelModelList;
        }

        public EducationLevelModel GetEmptyModel() => new EducationLevelModel();

        public EducationLevelModel GetOneModel(int Id)
        {
            var educationLevel = unitOfWork.EducationLevelRepository.GetById(Id);

            var educationLevelModel = Mapper.EducationLevelMapper.EducationLevelToEducationLevelModel(educationLevel);

            return educationLevelModel;
        }

        public void Update(EducationLevelModel model)
        {
            var educationLevel = Mapper.EducationLevelMapper.EducationLevelModelToEducationLevel(model);

            unitOfWork.EducationLevelRepository.Update(educationLevel);
        }
    }
}
