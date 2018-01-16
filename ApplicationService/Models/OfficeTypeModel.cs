namespace ApplicationService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OfficeTypeModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name ="Office Type Name")]
        public string OfficeTypeName { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Updated Date")]
        public DateTime? UpdatedDate { get; set; }
        
    }
}
