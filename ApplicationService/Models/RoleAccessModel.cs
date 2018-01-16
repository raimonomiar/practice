using ApplicationRepository;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ApplicationService.Models
{
    /// <summary>
    /// Represents a RoleAccess.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public class RoleAccessModel 
    {
        public int RoleAccessId { get; set; }
 
        public bool AllowAdd { get; set; }
 
        public bool AllowEdit { get; set; }
 
        public bool AllowDelete { get; set; }
 
        public bool AllowView { get; set; }
 
        public int RoleId { get; set; }

        public int MenuId { get; set; }

        public IEnumerable<Menu> MenuSelectList{ get; set; }

        public IEnumerable<Role> RoleSelectList { get; set; }

        public MenuModel Menu { get; set; }

        public RolesModel  Role { get; set; }
    }
}      
