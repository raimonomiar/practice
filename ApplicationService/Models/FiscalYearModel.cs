namespace ApplicationService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FiscalYearModel
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Display(Name ="Fiscal Yearr")]
        public string FiscalYearName { get; set; }

        [Required]
        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:MM/dd/yyyy}")]
        [Display(Name ="Start Date English")]
        public DateTime StartDate { get; set; }

        [Required]
        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name ="End Date English")]
        public DateTime EndDate { get; set; }


        [StringLength(12)]
        [Display(Name ="Start Date Nepali")]
        public string StartDateNp { get; set; }


        [StringLength(12)]
        [Display(Name ="End Date Nepali")]
        public string EndDateNp { get; set; }

        [Display(Name = "Current Fiscal Year?")]
        public bool CurrentFiscalYear { get; set; }

        [Display(Name ="Created Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name ="Updated Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? UpdatedDate { get; set; }
    }
}
