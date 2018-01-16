using System.ComponentModel.DataAnnotations;

namespace ApplicationService.Models
{
    public class MuncipalityTypeModel
    {
        public int id { get; set; }
        
        [Display(Name ="Municipality Name")]
        [StringLength(255)]
        public string MuniType { get; set; }
    }
}