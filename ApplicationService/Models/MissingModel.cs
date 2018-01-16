using ApplicationRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Models
{
    public class MissingModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Registration Number")]
        public int RegistrationNumber { get; set; }

        [Display(Name ="Office")]
        public int? OfficeId { get; set; }
        public int?UserId { get; set; }

        [Required]
        [Display(Name = "Fiscal year")]
        public int?FiscalYearId { get; set; }
        public int?VerifyUserId { get; set; }

        [Display(Name ="Verify Status")]
        public string VerifyStatus { get; set; }

        [DisplayFormat(DataFormatString ="{0: yyyy-mm-dd}",ApplyFormatInEditMode =true)]
        public DateTime? verifydate { get; set; }
        public string VerifyMessage { get; set; }

        [DisplayFormat(DataFormatString = "{0: yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EnteredDate { get; set; }

        [Required]
        [Display(Name ="First Name")]
        [StringLength(100)]
        public string Fname { get; set; }

        [Required]
        [Display(Name ="Last Name")]
        [StringLength(100)]
        public string Lname { get; set; }


        [StringLength(100)]
        [Display(Name ="Nick Name")]
        public string Alias { get; set; }

        [StringLength(100)]
        [Display(Name ="Marital Status")]
        public string MaritialStatus { get; set; }

        [Display(Name ="Ethnicity")]
        [Required]
        public int?EthnicityId { get; set; }

        [Required]
        public string Gender { get; set; }

        [Display(Name ="Type")]
        public string PersonType { get; set; }

        [StringLength(100)]
        [Display(Name ="Father's Name")]
        public string FatherName { get; set; }

        [StringLength(100)]
        [Display(Name ="Mother's Name")]
        public string MotherName { get; set; }

        [StringLength(100)]
        [Display(Name ="Spouse")]
        public string SpouseName { get; set; }

        public string SpecialIdentifier { get; set; }
        public int?NationalityId { get; set; }
        public int?IdTypeId { get; set; }

        [Display(Name ="Identification Number")]
        public string IdTypeNumber { get; set; }

        [Display(Name ="Religion")]
        public int?ReligionId { get; set; }


        public string Occupation { get; set; }
        public int?EducationLevelId { get; set; }
        public DateTime? DOB { get; set; }

        [Display(Name ="Estimate Age")]
        public int?EstimatedAge { get; set; }
        public string Hieght { get; set; }
        public string Weight { get; set; }

        public string HeightUnit { get; set; }

        [Display(Name ="Clothes Worn")]
        public string ClothesWorn { get; set; }

        public int?EyeColorId { get; set; }

        [Display(Name ="Hair Colour")] 
        public string Hair { get; set; }
        public int?HairColorId { get; set; }
        public string Build { get; set; }
        public string Language { get; set; }

        [StringLength(255)]
        [Display(Name ="State")]
        public int?TStateId { get; set; }

        [Display(Name ="District")]
        public int?TDistrictId { get; set; }

        [Display(Name ="Municipality")]
        public int?TMunicipalityId { get; set; }
        public string TWardNumber { get; set; }

        [Display(Name ="Tole")]
        public string TToleName { get; set; }

        [StringLength(255)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name ="Mobile")]
        public string TContactNumber { get; set; }

        [Display(Name ="State")]
        public int?PStateId { get; set; }
        [Display(Name ="District")]
        public int? PDistrictId { get; set; }

        [Display(Name ="Municipality")]
        public int?PMunicipalityId { get; set; }

        [Display(Name ="Ward no.")]
        public string PWardNumber { get; set; }

        [Display(Name ="Tole")]
        public string PToleName { get; set; }

        [StringLength(255)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile")]
        public string PContactNumber { get; set; }

        [Display(Name ="Last Seen Date")]
        public DateTime? LastSeenDate { get; set; }

        [Display(Name ="Last Seen Place")]
        public string LastSeenPlace { get; set; }

        [Display(Name ="Last Seen Time")]
        public string LastSeenTime { get; set; }

        [Display(Name ="State")]
        public int?MStateId { get; set; }

        [Display(Name ="District")]
        public int?MDistrictId { get; set; }

        [Display(Name ="Municipality")]
        public int?MMunicipalityId { get; set; }

        [Display(Name ="Ward No.")]
        public string MWardNumber { get; set; }

        [Display(Name ="Tole")]
        public string MToleName { get; set; }

        [Display(Name ="Complain")]
        public string ComplainByName { get; set; }

        [Display(Name ="Relation With Victim")]
        public string RelationWithVictim { get; set; }

        [Display(Name ="Contact Number")]
        public string ComplainContactNumber { get; set; }

        [Display(Name ="Complain Date")]
        public DateTime? ComplainDate { get; set; }


        public string Remarks { get; set; }
        public string Photo { get; set; }

        [Display(Name ="Possible Places")]
        public string PossiblePlaces { get; set; }

        [Display(Name ="Missing Reasons")]
        public string MissingReason { get; set; }

        [Display(Name ="Status")]
        public byte? MissingStatus { get; set; }

        [Display(Name ="Found Date")]
        public DateTime? DateOfFound { get; set; }

        [Display(Name ="Founnd Address")]
        public string FoundAddress { get; set; }

        [Display(Name = "Satus")]
        public string LiveStatus { get; set; }

        [Display(Name ="Remarks")]
        public string FoundRemarks { get; set; }

        [Display(Name = "Found Office")]
        public int?FoundByOfficeId { get; set; }

        [Display(Name ="Hand Over")]
        public string HandOverTo { get; set; }

        [Display(Name ="Hand Over Time")]
        public DateTime? HandOverDate { get; set; }

        [Display(Name ="Relation With Handover")]
        public string HandOverRelation { get; set; }

        [Display(Name ="Handover Details")]
        public string HandOverDetails { get; set; }

        [Display(Name = "Handover Contact")]
        public string HandOverContactNumber { get; set; }
        public DateTime? LastSearchActivityDate { get; set; }

        public string NDob { get; set; }

        public string  NLastSeenDate { get; set; }

        public string NComplainDate { get; set; }

        public string NDateOfFound { get; set; }

        public string NHandOverDate { get; set; }

        public string OfficeName { get; set; }

        public string UserName { get; set; }

        public string[] PhotoDetail { get; set; }

        public string MState { get; set; }

        public string  MMunicipalityName { get; set; }

        public string MDistrictName { get; set; }

        public string PState { get; set; }

        public string PMunicipalityName { get; set; }

        public string PDistrictName { get; set; }

        public string Verifier { get; set; }

        public string NVerifyDate { get; set; }

        public string HairColor { get; set; }

        public string EyeColor { get; set; }

        public string TState { get; set; }

        public string TMunicipalityName { get; set; }

        public string TDistrictName { get; set; }


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
