using ApplicationRepository.UnitOfWork;
using ApplicationService.Interface;
using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementation
{
    public class ReligionService : IAllService<ReligionModel>
    {
        private readonly IUnitOfWork unitOfWork;

        public ReligionService(IUnitOfWork _unitOfWork = null)
        {
            unitOfWork = _unitOfWork ?? new UnitOfWork();
        }
        public void Add(ReligionModel model)
        {
            var religion = Mapper.ReligionMapper.ReligionModelToReligion(model);

            unitOfWork.ReligionRepository.Create(religion);
        }

        public void Delete(object id)
        {
            unitOfWork.ReligionRepository.Delete(id);
        }

        public List<ReligionModel> GetAllT()
        {
            var religionList = unitOfWork.ReligionRepository.All().ToList();

            var religionModelList = Mapper.ReligionMapper.ReligionToReligionModelList(religionList);

            return religionModelList;
        }

        public ReligionModel GetEmptyModel() => new ReligionModel();

        public ReligionModel GetOneModel(int Id)
        {
            var religion = unitOfWork.ReligionRepository.GetById(Id);

            var religionModel = Mapper.ReligionMapper.ReligionToReligionModel(religion);

            return religionModel;
        }

        public void Update(ReligionModel model)
        {
            var religion = Mapper.ReligionMapper.ReligionModelToReligion(model);

            unitOfWork.ReligionRepository.Update(religion);
        }
    }
}
