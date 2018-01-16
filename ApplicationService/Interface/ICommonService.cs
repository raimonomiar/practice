using ApplicationRepository;
using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Interface
{
    public interface ICommonService
    {
        int GetMenuId(string controllerName);

        Menu GetMenuById(int menuId);

        RoleAccess GetRoleAccessByMenuIdAndRoleId(int menuId, int roleId);

        AccessModel GetAccessValue(int menuId, int roleId);

        string GetOfficeNameById(int officeId);


    }
}
