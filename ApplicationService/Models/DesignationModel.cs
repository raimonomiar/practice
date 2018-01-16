namespace ApplicationService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DesignationModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name ="Designation")]
        public string DesgName { get; set; }

        [Required]
        [Display(Name ="Display Order")]
        public int? DiplayOrder { get; set; }

        [Display(Name ="Created Date")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name ="Updated Date")]
        public DateTime? UpdatedDate { get; set; }
    }
}
