using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Models
{
    public class StateModel
    {
        public int StateId { get; set; }

        [Display(Name ="State Name")]
        public string StateName { get; set; }
    }
}
