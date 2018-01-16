namespace ApplicationService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class MunicipalityModel
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name ="Muncipality Name")]
        public string MunicipalityName { get; set; }

        [Display(Name ="Created Date")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Updated Date")]
        public DateTime? UpdatedDate { get; set; }

        [Display(Name ="Municipality Type")]
        public int? MuniTypeId { get; set; }

        [Display(Name ="Districts")]
        public int? DisId { get; set; }

        public MuncipalityTypeModel MunType { get; set; }
        public  DistrictModel District { get; set; }

        public IEnumerable<SelectListItem> MunicipalityTypeList { get; set; }

        public IEnumerable<SelectListItem> DistrictList{ get; set; }
    }
}
