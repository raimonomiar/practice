using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(255)]
        public string LoginId { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }
    }
}