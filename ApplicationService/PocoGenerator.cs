using System;
 
namespace ApplicationService.Test
{
    /// <summary>
    /// Represents a RoleAccess.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public class RoleAccess 
    {
        public int RoleAccessId { get; set; }
 
        public bool AllowAdd { get; set; }
 
        public bool AllowEdit { get; set; }
 
        public bool AllowDelete { get; set; }
 
        public bool AllowView { get; set; }
 
        public int RoleId { get; set; }
    }
}      
