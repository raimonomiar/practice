using ApplicationRepository;
using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Mapper
{
    public class FiscalYearMapper
    {
        public static FiscalYear FiscalYearModelToFiscalYear(FiscalYearModel model)
        {
            var fiscalYear = new FiscalYear
            {
                Id = model.Id,
                CreatedDate = model.CreatedDate,
                CurrentFiscalYear = model.CurrentFiscalYear,
                EndDate = model.EndDate,
                EndDateNp = model.EndDateNp,
                FiscalYearName = model.FiscalYearName,
                StartDate = model.StartDate,
                StartDateNp = model.StartDateNp,
                UpdatedDate = model.UpdatedDate

            };

            return fiscalYear;
        }

        public static FiscalYearModel FiscalYearToFiscalYearModel(FiscalYear model)
        {
            var fiscalYearModel = new FiscalYearModel
            {
                Id = model.Id,
                CreatedDate = model.CreatedDate,
                CurrentFiscalYear = model.CurrentFiscalYear,
                EndDate = model.EndDate,
                EndDateNp = model.EndDateNp,
                FiscalYearName = model.FiscalYearName,
                StartDate = model.StartDate,
                StartDateNp = model.StartDateNp,
                UpdatedDate = model.UpdatedDate
            };

            return fiscalYearModel;
        }


        public static List<FiscalYearModel> FiscalYearToFiscalYearModelList(List<FiscalYear> model)
        {

            var fiscalYearModel = new List<FiscalYearModel>();

            foreach (var fiscalModel in model)
            {
                fiscalYearModel.Add(new FiscalYearModel
                {
                    Id = fiscalModel.Id,
                    CreatedDate = fiscalModel.CreatedDate,
                    CurrentFiscalYear = fiscalModel.CurrentFiscalYear,
                    EndDate = fiscalModel.EndDate,
                    EndDateNp = fiscalModel.EndDateNp,
                    FiscalYearName = fiscalModel.FiscalYearName,
                    StartDate = fiscalModel.StartDate,
                    StartDateNp = fiscalModel.StartDateNp,
                    UpdatedDate = fiscalModel.UpdatedDate
                });

            }
            return fiscalYearModel;

        }
    }
}
