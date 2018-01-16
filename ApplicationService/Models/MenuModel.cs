using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ApplicationService.Models
{
    public class MenuModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Parent Menu")]
        public int? ParentId { get; set; }

        [Required]
        [Display(Name ="Menu Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name ="Details")]
        public string MenuDetails { get; set; }

        [Required]
        [Display(Name ="Css Class")]
        public string  CssClass { get; set; }

        [Required]
        [Display(Name ="Action")]
        public string  MenuLink { get; set; }

        public int Order { get; set; }

        [Required]
        public string Controller { get; set; }

        public bool IsDefault { get; set; }

        [Display(Name ="Status")]
        public bool IsActive { get; set; }

        public IEnumerable<SelectListItem> ParentMenu { get; set; }

        public bool IsSelected { get; set; }

        public bool Create { get; set; }

        public bool Read { get; set; }

        public bool Update { get; set; }

        public bool Delete { get; set; }

        public List<MenuModel> ChildMenu { get; set; }


    }
}
