namespace ApplicationService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public  class ColourModel
    {
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string ColourName { get; set; }
    }
}
