namespace ApplicationService.Models
{
    using ApplicationRepository;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DistrictModel
    {
        public int Id { get; set; }

        public int DistrictCode { get; set; }

        [StringLength(255)]
        [Display(Name ="District Name")]
        public string DistrictNameEng { get; set; }

        [StringLength(255)]
        public string DistrictNameNp { get; set; }

        public int? StateId { get; set; }

        public State State { get; set; }


    }
}
