using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ApplicationService.Interface
{
    public interface ISetupService
    {
#region role
        void AddRole(RolesModel roleModel);

        List<RolesModel> GetAllRoles();

        RolesModel GetOneRole(int id);

        void UpdateRole(RolesModel roleModel);

        void DeleteRole(object Id);
        #endregion

        List<MenuModel> GetAllMenus();

        IEnumerable<SelectListItem> GetParenMenus();

        void AddMenu(MenuModel model);

        MenuModel GetOneMenu(int? id);

        void UpdateMenu(MenuModel model);

        AssignMenuModel GetRoleAccess(int id);

        void AddRoleAccess(AssignMenuModel model);

    }
}
