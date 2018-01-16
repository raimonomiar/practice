using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Models
{
    public class MissingExcelReportModel
    {
        public int MissingId { get; set; }

        public int? OfficeId { get; set; }

        public int? FiscalYearId{ get; set; }

        public string FirstName { get; set; }

        public string LName { get; set; }

        public string MiddleName { get; set; }

        public string Alias { get; set; }

        public string MatrialStatus { get; set; }

        public int? EthnicityId { get; set; }

        public string Gender { get; set; }

        public string PersonType { get; set; }

        public string FatherName { get; set; }

        public string MotherName { get; set; }

        public string SpouseName { get; set; }

        public int? NationalityId { get; set; }

        public string SpecialIdentifier { get; set; }

        public int? IdType { get; set; }

        public string IdTypeNumber  { get; set; }

        public int? ReligionId { get; set; }

        public string occupation { get; set; }

        public int?  EducationLevelId { get; set; }

        public DateTime? Dob { get; set; }

        public int? EstimateAge { get; set; }

        public string Height { get; set; }

        public string HeightUnit { get; set; }

        public string Weight { get; set; }

        public string ClothesWorn { get; set; }

        public int? EyeColorId { get; set; }

        public int? HairColorId { get; set; }

        public string Build { get; set; }

        public int? TStateId { get; set; }

        public int? TDistrictId { get; set; }

        public int? TMunicipalityId { get; set; }

        public string TWardNumber { get; set; }

        public string TToleName{ get; set; }

        public string TContactNumber { get; set; }

        public int? PStateId { get; set; }

        public int? PDistrictId{ get; set; }

        public int? PMunicipalityId { get; set; }

        public string PWardNumber { get; set; }

        public string PToleName { get; set; }

        public string PContactNumber { get; set; }

        public DateTime? LastSeenDate { get; set; }

        public string LastSeenTime { get; set; }

        public string LastSeenPlace { get; set; }

        public int? MStateId { get; set; }

        public int? MDistrictId { get; set; }

        public int? MMunicipalityId { get; set; }

        public string MWardNumber { get; set; }

        public string MToleName { get; set; }

        public string ComplainName { get; set; }

        public DateTime? ComplaintDate { get; set; }

        public string RelationWithVictim { get; set; }

        public string ComplainContactNumber { get; set; }

        public string Remarks { get; set; }

        public string Photo { get; set; }

        public string PossiblePlaces { get; set; }

        public string MissingReason { get; set; }

        public byte? MissingStatus { get; set; }

        public DateTime? DateFound { get; set; }

        public string FoundAddress { get; set; }

        public string LiveStatus { get; set; }

        public string FoundRemarks { get; set; }

        public int? FoundByOfficeId { get; set; }

        public DateTime? LastSearchActivityDate { get; set; }

        public string HandOverTo { get; set; }

        public DateTime? HandOverDate { get; set; }

        public string HandOverRelation { get; set; }

        public string HandOverDetails { get; set; }

        public string HandOverContactNumber { get; set; }

        public string RegistrationNumber { get; set; }

        public string OfficeName { get; set; }

        public string TDistrictName { get; set; }

        public string TMunicipalityName { get; set; }

        public string MMunicipalityName { get; set; }

        public string MDistrictname { get; set; }

        public string PMunicipalityname { get; set; }

        public string PDistrictName { get; set; }

        public DateTime? EnteredDate { get; set; }


        public string NationalityName { get; set; }

        public string ReligionName { get; set; }

        public string EducationLevelName { get; set; }

        public IPagedList<MissingExcelReportModel>  MissingModelPagedList { get; set; }

    }
}
