//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApplicationRepository
{
    using System;
    using System.Collections.Generic;
    
    public partial class Missing
    {
        public int Id { get; set; }
        public int RegistrationNumber { get; set; }
        public Nullable<int> OfficeId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> FiscalYearId { get; set; }
        public Nullable<int> VerifyUserId { get; set; }
        public string VerifyStatus { get; set; }
        public Nullable<System.DateTime> verifydate { get; set; }
        public string VerifyMessage { get; set; }
        public Nullable<System.DateTime> EnteredDate { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Alias { get; set; }
        public string MaritialStatus { get; set; }
        public Nullable<int> EthnicityId { get; set; }
        public string Gender { get; set; }
        public string PersonType { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string SpouseName { get; set; }
        public string SpecialIdentifier { get; set; }
        public Nullable<int> NationalityId { get; set; }
        public Nullable<int> IdTypeId { get; set; }
        public string IdTypeNumber { get; set; }
        public Nullable<int> ReligionId { get; set; }
        public string Occupation { get; set; }
        public Nullable<int> EducationLevelId { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public Nullable<int> EstimatedAge { get; set; }
        public string Hieght { get; set; }
        public string Weight { get; set; }
        public string ClothesWorn { get; set; }
        public Nullable<int> EyeColorId { get; set; }
        public string Hair { get; set; }
        public Nullable<int> HairColorId { get; set; }
        public string Build { get; set; }
        public string Language { get; set; }
        public Nullable<int> TStateId { get; set; }
        public Nullable<int> TDistrictId { get; set; }
        public Nullable<int> TMunicipalityId { get; set; }
        public string TWardNumber { get; set; }
        public string TToleName { get; set; }
        public string TContactNumber { get; set; }
        public Nullable<int> PStateId { get; set; }
        public Nullable<int> PDistrictId { get; set; }
        public Nullable<int> PMunicipalityId { get; set; }
        public string PWardNumber { get; set; }
        public string PToleName { get; set; }
        public string PContactNumber { get; set; }
        public Nullable<System.DateTime> LastSeenDate { get; set; }
        public string LastSeenPlace { get; set; }
        public string LastSeenTime { get; set; }
        public Nullable<int> MStateId { get; set; }
        public Nullable<int> MDistrictId { get; set; }
        public Nullable<int> MMunicipalityId { get; set; }
        public string MWardNumber { get; set; }
        public string MToleName { get; set; }
        public string ComplainByName { get; set; }
        public string RelationWithVictim { get; set; }
        public string ComplainContactNumber { get; set; }
        public Nullable<System.DateTime> ComplainDate { get; set; }
        public string Remarks { get; set; }
        public string Photo { get; set; }
        public string PossiblePlaces { get; set; }
        public string MissingReason { get; set; }
        public Nullable<byte> MissingStatus { get; set; }
        public Nullable<System.DateTime> DateOfFound { get; set; }
        public string FoundAddress { get; set; }
        public string LiveStatus { get; set; }
        public string FoundRemarks { get; set; }
        public Nullable<int> FoundByOfficeId { get; set; }
        public string HandOverTo { get; set; }
        public Nullable<System.DateTime> HandOverDate { get; set; }
        public string HandOverRelation { get; set; }
        public string HandOverDetails { get; set; }
        public string HandOverContactNumber { get; set; }
        public Nullable<System.DateTime> LastSearchActivityDate { get; set; }
    
        public virtual Colour Colour { get; set; }
        public virtual Colour Colour1 { get; set; }
        public virtual country country { get; set; }
        public virtual EducationLevel EducationLevel { get; set; }
        public virtual Ethnicity Ethnicity { get; set; }
        public virtual FiscalYear FiscalYear { get; set; }
        public virtual IdType IdType { get; set; }
        public virtual Office Office { get; set; }
        public virtual Municipality Municipality { get; set; }
        public virtual Religion Religion { get; set; }
        public virtual Municipality Municipality1 { get; set; }
        public virtual User User { get; set; }
    }
}
