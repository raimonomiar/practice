using ApplicationService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationService.Models;
using ApplicationRepository.UnitOfWork;
using System.Web;
using ApplicationRepository;

namespace ApplicationService.Implementation
{
    public class MenuService : IMenuService
    {

        private readonly IUnitOfWork unitOfWork;

        public MenuService(IUnitOfWork _unitOfWork = null)
        {
            unitOfWork = _unitOfWork ?? new UnitOfWork();
        }

        public List<MenuModel> GetAllActiveMenus(int roleId, MenuModel model)
        {
            string ControllerName = model.Controller;

            string ActionName = model.MenuLink;

            int? ParentId = 0;

            ParentId = unitOfWork.MenuRepository.Get(x => x.Controller.ToLower() == ControllerName).Select(x => x.ParentId).FirstOrDefault();
           

            List<int> RoleMenu = unitOfWork.RoleAccessRepository.Get(x => x.RoleId == roleId).Select(x => x.MenuId).ToList();

            List<Menu> MenuModel = new List<Menu>();

            if (ParentId != null && ParentId !=0)
            {
                MenuModel = unitOfWork.MenuRepository.Get(x =>x.IsActive==true &&  RoleMenu.Contains(x.Id) && x.ParentId != x.Id && x.ParentId == ParentId).ToList();
            }
            else
            {
                MenuModel = unitOfWork.MenuRepository.Get(x => RoleMenu.Contains(x.Id) && x.ParentId != x.ParentId && x.IsDefault == true).ToList();

            }

            List<MenuModel> activeMenuList = Mapper.MenuMapper.MenuToMenuModelList(MenuModel);

            return activeMenuList;
        }


        public List<MenuModel> GetMainMenuList(int roleId)
        {
            List<int> RoleMenu = unitOfWork.RoleAccessRepository.Get(x => x.RoleId == roleId).Select(x => x.MenuId).ToList();

            List<Menu> Record = unitOfWork.MenuRepository.Get(x => x.IsActive == true && x.ParentId == x.Id && RoleMenu.Contains(x.Id)).OrderBy(x => x.DisplayOrder).ToList();

            List<MenuModel> mainMenuList = Mapper.MenuMapper.MenuToMenuModelList(Record);

            return mainMenuList;    
        }


    }
}
