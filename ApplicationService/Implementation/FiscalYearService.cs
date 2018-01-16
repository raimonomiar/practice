using ApplicationService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationService.Models;
using ApplicationRepository;
using ApplicationRepository.UnitOfWork;
using System.Transactions;

namespace ApplicationService.Implementation
{
    public class FiscalYearService : IFiscalYearService
    {
        private readonly practiceEntities Db;

        private readonly IUnitOfWork unitOfWork;

        public FiscalYearService(IUnitOfWork _unitOfWork =null)
        {
            unitOfWork = _unitOfWork ?? new UnitOfWork();
            Db = new practiceEntities();
        }
        public void Add(FiscalYearModel model)
        {
            var fiscalYear = Mapper.FiscalYearMapper.FiscalYearModelToFiscalYear(model);

            unitOfWork.FiscalYearRepository.Create(fiscalYear);
        }

        public void Delete(object id)
        {
            unitOfWork.FiscalYearRepository.Delete(id);
        }

        public List<FiscalYearModel> GetAllT()
        {
            var fiscalYearList = unitOfWork.FiscalYearRepository.All().ToList();

            var fiscalYearModelList = Mapper.FiscalYearMapper.FiscalYearToFiscalYearModelList(fiscalYearList);

            return fiscalYearModelList;
        }

        public FiscalYearModel GetEmptyModel() => new FiscalYearModel();

        public FiscalYearModel GetOneModel(int Id)
        {
            var fiscalYear = unitOfWork.FiscalYearRepository.GetById(Id);

            var fiscalYearModel = Mapper.FiscalYearMapper.FiscalYearToFiscalYearModel(fiscalYear);

            return fiscalYearModel;
        }

        public void Update(FiscalYearModel model)
        {
            var fiscalYear = Mapper.FiscalYearMapper.FiscalYearModelToFiscalYear(model);

            unitOfWork.FiscalYearRepository.Update(fiscalYear);
        }

        public void UpdateFiscalYearRecord(FiscalYearModel model)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                var fiscalYear = Db.FiscalYears.FirstOrDefault(x => x.Id == model.Id);

                if (fiscalYear != null)
                {
                    fiscalYear.FiscalYearName = model.FiscalYearName ?? fiscalYear.FiscalYearName;
                    fiscalYear.CreatedDate = model.CreatedDate ?? fiscalYear.CreatedDate;
                    fiscalYear.UpdatedDate = model.UpdatedDate ?? fiscalYear.UpdatedDate;
                    fiscalYear.StartDate = model.StartDate;
                    fiscalYear.EndDate = model.EndDate;
                    fiscalYear.StartDateNp = model.StartDateNp ?? fiscalYear.StartDateNp;
                    fiscalYear.EndDateNp = model.EndDateNp ?? fiscalYear.EndDateNp;
                    fiscalYear.CurrentFiscalYear = model.CurrentFiscalYear;


                    
                }

                Db.Entry(fiscalYear).CurrentValues.SetValues(fiscalYear);
                Db.SaveChanges();

                ts.Complete();
            }
        }
    }
}
