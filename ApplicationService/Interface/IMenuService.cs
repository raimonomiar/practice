using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Interface
{
    public interface IMenuService
    {

        List<MenuModel> GetAllActiveMenus(int roleId,MenuModel model);

        List<MenuModel> GetMainMenuList(int roleId);
    }
}
