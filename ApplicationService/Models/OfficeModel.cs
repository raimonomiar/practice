namespace ApplicationService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class OfficeModel
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name ="Name")]
        public string OfficeName { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name ="Code")]
        public string OfficeCode { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name ="Address")]
        public string OfficeAddress { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Phone")]
        public string OfficePhone { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string OfficeEmail { get; set; }

        [Display(Name ="Status")]
        public bool IsActive { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Updated Date")]
        public DateTime? UpdatedDate { get; set; }

        [Display(Name ="Office Type")]
        public int? OfficeTypeId { get; set; }

        public string OfficeTypeName { get; set; }

        public int DisId { get; set; }

        public virtual DistrictModel District { get; set; }

        public virtual OfficeTypeModel OfficeType { get; set; }

        public IEnumerable<SelectListItem> OfficeTypeList { get; set; }
    }
}
