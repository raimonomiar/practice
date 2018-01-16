using ApplicationRepository;
using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Mapper
{
    public class RoleAccessMapper
    {
        public static RoleAccess RoleAccessModelToRoleDb(RoleAccessModel model)
        {
            var roleAccess = new RoleAccess
            {
                Id = model.RoleAccessId,
                AllowAdd = model.AllowAdd,
                AllowDelete = model.AllowDelete,
                AllowEdit = model.AllowEdit,
                AllowView = model.AllowView,
                RoleId = model.RoleId,
                MenuId =model.MenuId
            };

            return roleAccess;
        }
        
        public static RoleAccessModel RoleAccessDbToRoleAccessModel(RoleAccess role)
        {
            var roleAccessModel = new RoleAccessModel
            {
                RoleAccessId = role.Id,
                AllowAdd = role.AllowAdd,
                AllowDelete = role.AllowDelete,
                AllowEdit = role.AllowEdit,
                AllowView = role.AllowView,
                RoleId = role.RoleId,
                MenuId = role.MenuId
            };

            return roleAccessModel;
        }

        public static List<RoleAccessModel> RoleAccessDbToRoleAccessModelList(List<RoleAccess> roles)
        {
            var roleAccessModelList = new List<RoleAccessModel>();

            foreach (var item in roles)
            {
                var roleAccessModel = new RoleAccessModel
                {
                    RoleAccessId = item.Id,
                    AllowAdd = item.AllowAdd,
                    AllowDelete = item.AllowDelete,
                    AllowEdit = item.AllowEdit,
                    AllowView = item.AllowView,
                    Menu = new MenuModel
                    {
                        Name = item.Menu.Name
                    },
                    Role = new RolesModel
                    {
                        Name = item.Role.Name
                    }
                    
                };

                roleAccessModelList.Add(roleAccessModel);
            }

            return roleAccessModelList;
        }
    }
}
