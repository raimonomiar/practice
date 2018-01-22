using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Models
{
    public class EthnicityModel
    {
        public int Id { get; set; }

        [Display(Name ="Ethnicity Name")]
        public string EthnicityName { get; set; }
    }
}
