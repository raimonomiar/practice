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
    public class OfficeTypeService : IAllService<OfficeTypeModel>
    {
        private readonly IUnitOfWork unitOfWork;

        public OfficeTypeService(IUnitOfWork _unitOfWork = null)
        {
            unitOfWork = _unitOfWork ?? new UnitOfWork();
        }
        public void Add(OfficeTypeModel model)
        {
            var officeType = Mapper.OfficeTypeMapper.OfficeTypeModelToOfficeType(model);

            unitOfWork.OfficeTypeRepository.Create(officeType);
        }

        public void Delete(object id)
        {
            unitOfWork.OfficeTypeRepository.Delete(id);
        }

        public List<OfficeTypeModel> GetAllT()
        {
            var officeTypeList = unitOfWork.OfficeTypeRepository.All().ToList();

            var officeTypeModelList = Mapper.OfficeTypeMapper.OfficeToOfficeTypeModelList(officeTypeList);

            return officeTypeModelList;
        }

        public OfficeTypeModel GetEmptyModel() => new OfficeTypeModel();

        public OfficeTypeModel GetOneModel(int Id)
        {
            var officeType = unitOfWork.OfficeTypeRepository.GetById(Id);

            var officeTypeModel = Mapper.OfficeTypeMapper.OfficeTypeToOfficeTypeModel(officeType);

            return officeTypeModel;
        }

        public void Update(OfficeTypeModel model)
        {
            var officeType = Mapper.OfficeTypeMapper.OfficeTypeModelToOfficeType(model);

            unitOfWork.OfficeTypeRepository.Update(officeType);
        }
    }
}
