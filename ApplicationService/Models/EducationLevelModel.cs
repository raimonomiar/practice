namespace ApplicationService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EducationLevelModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name ="Education Level")]
        public string LevelName { get; set; }

        [Display(Name ="Display Order")]
        public int DisplayOrder { get; set; }

        public bool? IsActive { get; set; }
    }
}
