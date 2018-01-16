using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Interface
{
    public interface IMissingService : IAllService<MissingModel>
    {
        MissingModel GetOneMissingModel(object id);

        List<MissingModel> GetAllMissingModels(MissingModel model);

        List<MissingModel> GetAllMissingUnApprovedRecords(int officeId);

        List<MissingModel> GetAllMissingPendingRecords(int pfficeId, int roleId);

        List<MissingModel> FindMissingRecords(string fname, string lname, DateTime? missingDate, int? missingDistrict, int? missingOffice, string registrationNumber);

        List<MissingModel> ExecuteSpWithParameterForList();

        IEnumerable<MissingModel> MissingMatches(MissingModel model);


        bool RegistrationNumberExist(int officeId, int fiscalYearId, int registrationNumber, int missingId = 0);

        IEnumerable<MissingExcelReportModel> GetMissingReport(DateTime? startDate, DateTime? endDate, string gender, int? districtId, int? officeId, int? statusId, int? fiscalYearId, string PersonType);

        IEnumerable<MissingModel> GetMissingPDFReport(DateTime? startDate,DateTime? endDate,string gender,int? districtId,int? officeId,int? statusId,int? fiscalYearId,string personType);
    }
}
