namespace ApplicationService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReligionModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name ="Religion")]
        public string ReligionName { get; set; }

        public bool IsActive { get; set; }
    }
}
