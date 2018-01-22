using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Models
{
    public class IdTypeModel
    {
        public int id { get; set; }

        [Display(Name ="Id Type")]
        public string IdTypeName { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
