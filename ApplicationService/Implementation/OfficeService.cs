using ApplicationService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationService.Models;
using ApplicationRepository.UnitOfWork;
using ApplicationRepository;
using System.Data.Entity;

namespace ApplicationService.Implementation
{
    public class OfficeService : IOfficeService
    {
        private readonly IUnitOfWork unitOfWork;

        public OfficeService(IUnitOfWork _unitOfWork = null)
        {
            unitOfWork = _unitOfWork ?? new UnitOfWork();
        }
        public void Add(OfficeModel model)
        {
            var office = Mapper.OfficeMapper.OfficeModelToOffice(model);

            unitOfWork.OfficeRepository.Create(office);
        }

        public void Delete(object id)
        {
            unitOfWork.OfficeRepository.Delete(id);
        }

        public List<OfficeModel> GetActiveOfficesWithTypes()
        {
            practiceEntities context = new practiceEntities();

            var officeModelList = context.Offices
                .Include(x => x.OfficeType)
                .OrderBy(x => x.OfficeName)
                .Where(x => x.IsActive)
                .Select(x => new OfficeModel
                {
                    Id = x.Id,
                    OfficeCode = x.OfficeCode,
                    OfficeName = x.OfficeName,
                    OfficeAddress = x.OfficeAddress,
                    OfficeEmail = x.OfficeEmail,
                    OfficePhone = x.OfficePhone,
                    OfficeTypeName = x.OfficeType.OfficeTypeName
                })
                .ToList();

            return officeModelList;
        }

        public List<OfficeModel> GetAllT()
        {
            var practice = new practiceEntities();

            var officeList = practice.Offices
                .Include(x => x.OfficeType)
                .OrderBy(x => x.OfficeName)
                .ToList();

            var officeModelList = Mapper.OfficeMapper.OfficeToOfficeModelList(officeList);

            return officeModelList;
        }

        public OfficeModel GetEmptyModel() => new OfficeModel();

        public OfficeModel GetOneModel(int Id)
        {
            var office = unitOfWork.OfficeRepository.GetById(Id);

            var officeModel = Mapper.OfficeMapper.OfficeToOfficeModel(office);

            return officeModel;
        }

        public void Update(OfficeModel model)
        {
            var office = Mapper.OfficeMapper.OfficeModelToOffice(model);

            unitOfWork.OfficeRepository.Update(office);
        }
    }
}
