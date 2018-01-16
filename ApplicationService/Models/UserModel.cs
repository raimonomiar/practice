using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ApplicationService.Models
{
    /// <summary>
    /// Represents a Users.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public class UserModel 
    {
        public int UserId { get; set; }
 
        [Required]
        [StringLength(100)]
        public string Username { get; set; }
 
        [Required]
        [Display(Name ="Email Address")]
        public string EmailAddress { get; set; }
 
        [Required]
        [StringLength(255)]
        [Remote("IsUsernameAvailable","User",ErrorMessage ="The username is in use. Choose Another one !!")]
        public string LoginId { get; set; }


        [Required]
        [StringLength(255)]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage ="Confirm Password is required")]
        [StringLength(255)]
        [System.ComponentModel.DataAnnotations.CompareAttribute("Password", ErrorMessage ="Password Doesnt Match")]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name ="Created Date")]
        public DateTime? CreatedDate { get; set; }
 
        [Display(Name ="Updated Date")]
        public DateTime? UpdatedDate { get; set; }
 
        public DateTime? LastLoginDate { get; set; }
 
        public int? LoginCount { get; set; }
 
        public int? LoginAttempt { get; set; }
 
        [Display(Name ="Status")]
        public bool? IsActive { get; set; }

        [HiddenInput]
        public string ReturnUrl { get; set; }

        [Required]
        [Display(Name ="Role")]
        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public int OfficeId { get; set; }
        public IEnumerable<SelectListItem> dRoleList { get; set; }

        public IEnumerable<UserModel> UserList { get; set; }
    }
}      
