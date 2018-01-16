using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationService.Models
{
    /// <summary>
    /// Represents a Roles.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public class RolesModel 
    {
        public int RoleId { get; set; }
        
        [Required]
        public string Name { get; set; }
 
        [Required]
        public string Detail { get; set; }
 

        public bool AccessAll { get; set; } 
 
        public bool? IsPermanent { get; set; }
    }
}      
