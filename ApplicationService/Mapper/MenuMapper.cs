using ApplicationRepository;
using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Mapper
{
    public class MenuMapper
    {

        public static Menu  MenuModelToMenu(MenuModel model)
        {
            var menu = new Menu
            {
                Id = model.Id,
                Controller = model.Controller,
                CssClass = model.CssClass,
                DisplayOrder = model.Order,
                IsActive = model.IsActive,
                IsDefault = model.IsDefault,
                MenuDetails = model.MenuDetails,
                MenuLink = model.MenuLink,
                Name = model.Name,
                ParentId = model.ParentId
               
            };

            return menu;
        }


        public static MenuModel MenuToMenuModel(Menu model)
        {
            var menuModel = new MenuModel
            {
                Id = model.Id,
                Controller = model.Controller,
                CssClass = model.CssClass,
                Order = model.DisplayOrder,
                IsActive = model.IsActive,
                IsDefault = model.IsDefault,
                MenuDetails = model.MenuDetails,
                MenuLink = model.MenuLink,
                Name = model.Name,
                ParentId = model.ParentId
            };

            return menuModel;

        }

        public static List<MenuModel> MenuToMenuModelList(List<Menu> model)
        {
            var menuModelList = new List<MenuModel>();

            foreach (var menu in model)
            {
                menuModelList.Add(new MenuModel
                {
                    Id = menu.Id,
                    Controller = menu.Controller,
                    CssClass = menu.CssClass,
                    Order = menu.DisplayOrder,
                    IsActive = menu.IsActive,
                    IsDefault = menu.IsDefault,
                    MenuDetails = menu.MenuDetails,
                    MenuLink = menu.MenuLink,
                    Name = menu.Name,
                    ParentId = menu.ParentId
                });
            }

            return menuModelList;
        }
    }
}
