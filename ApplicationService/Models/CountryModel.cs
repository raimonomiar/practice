using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Models
{
    public class CountryModel
    {
        public int Id { get; set; }

        [Display(Name ="Country Name")]
        public string CountryName { get; set; }
        public string CountryNameNp { get; set; }

        [Display(Name ="Country Code")]
        public string CountryCode { get; set; }
        public string Nationality { get; set; }
    }
}
