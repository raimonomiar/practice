using ApplicationRepository;
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
    public class DesignationService : IAllService<DesignationModel>
    {
        private readonly IUnitOfWork unitOfWork;

        public DesignationService(IUnitOfWork _unitOfWork = null)
        {
            unitOfWork = _unitOfWork ?? new UnitOfWork();
        }

        public void Add(DesignationModel model)
        {
            Designation designation = Mapper.DesignationMapper.DesignationModelToDesignation(model);

            unitOfWork.DesignationRepository.Create(designation);
        }

        public void Delete(object id)
        {
            unitOfWork.DesignationRepository.Delete(id);
        }

        public List<DesignationModel> GetAllT()
        {
            var designationList = unitOfWork.DesignationRepository.All().ToList();

            var designationModelList = Mapper.DesignationMapper.DesignationToDesignationModelList(designationList);

            return designationModelList;
        }

        public DesignationModel GetEmptyModel() => new DesignationModel();

        public DesignationModel GetOneModel(int Id)
        {
            var designation = unitOfWork.DesignationRepository.GetById(Id);

            var designationModel = Mapper.DesignationMapper.DesignationToDesignationModel(designation);

            return designationModel;
        }

        public void Update(DesignationModel model)
        {
            var designation = Mapper.DesignationMapper.DesignationModelToDesignation(model);

            unitOfWork.DesignationRepository.Update(designation);
        }
    }
}
