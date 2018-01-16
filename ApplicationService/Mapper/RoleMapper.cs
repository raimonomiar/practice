using ApplicationRepository;
using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Mapper
{
    public class RoleMapper
    {

        public static RolesModel RoleDbToRoleModel(Role role)
        {
            var roleModel = new RolesModel
            {
                RoleId = role.RoleId,
                AccessAll = role.AccessAll,
                Detail = role.Detail,
                IsPermanent = role.IsPermanent,
                Name = role.Name
            };

            return roleModel;
        } 

        public static Role RoleModelToRoleDb(RolesModel roleModel)
        {
            var role = new Role
            {
                RoleId = roleModel.RoleId,
                AccessAll = roleModel.AccessAll,
                Detail = roleModel.Detail,
                IsPermanent = roleModel.IsPermanent,
                Name = roleModel.Name
                
            };

            return role;
        }

        public static List<RolesModel> RoleDbToRoleModelList(List<Role> role)
        {
            var roleModelList = new List<RolesModel>();

            foreach (var item in role)
            {
                var roleModel = new RolesModel
                {
                    RoleId = item.RoleId,
                    AccessAll = item.AccessAll,
                    Detail = item.Detail,
                    IsPermanent = item.IsPermanent,
                    Name = item.Name
                };

                roleModelList.Add(roleModel);
            }

            return roleModelList;
        }
    }
}
