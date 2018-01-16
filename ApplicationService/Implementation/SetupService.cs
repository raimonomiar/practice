using ApplicationRepository.UnitOfWork;
using ApplicationService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationService.Models;
using ApplicationRepository;
using System.Web.Mvc;
using System.Transactions;

namespace ApplicationService.Implementation
{
    public class SetupService : ISetupService
    {
        private readonly IUnitOfWork unitOfWork;

        public SetupService(UnitOfWork _unitOfWork = null)
        {
            unitOfWork = _unitOfWork ?? new UnitOfWork();
        }

        public void AddMenu(MenuModel model)
        {
            var menu = Mapper.MenuMapper.MenuModelToMenu(model);

            unitOfWork.MenuRepository.Create(menu);
            
        }

        //public SetupService()
        //{
        //    unitOfWork = new UnitOfWork();
        //}

        public void AddRole(RolesModel roleModel)
        {
            Role role = Mapper.RoleMapper.RoleModelToRoleDb(roleModel);

            unitOfWork.RoleRepository.Create(role);
        }

        public void AddRoleAccess(AssignMenuModel model)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                unitOfWork.RoleAccessRepository.Delete(x => x.RoleId == model.Id);

                foreach (var item in model.Menu)
                {
                    if (item.Create || item.Read || item.Update || item.Delete)
                    {
                        var roleAccess = new RoleAccess
                        {
                            RoleId = model.Id,
                            MenuId = item.Id,
                            AllowAdd = item.Create,
                            AllowView = item.Read,
                            AllowEdit = item.Update,
                            AllowDelete = item.Delete
                            
                        };

                        unitOfWork.RoleAccessRepository.Create(roleAccess);
                            
                    }
                }

                ts.Complete();
            }
        }

        public void DeleteRole(object Id)
        {
            unitOfWork.RoleRepository.Delete(Id);
        }

        public List<MenuModel> GetAllMenus()
        {
            var menuList = unitOfWork.MenuRepository.All().ToList();

            var menuModelList = Mapper.MenuMapper.MenuToMenuModelList(menuList);

            return menuModelList;
        }

        public List<RolesModel> GetAllRoles()
        {
            var rolesList = unitOfWork.RoleRepository.All().ToList();

            List<RolesModel> returnRoleList = Mapper.RoleMapper.RoleDbToRoleModelList(rolesList);

            return returnRoleList;
        }

        public MenuModel GetOneMenu(int? id)
        {
            var menu = unitOfWork.MenuRepository.GetById(id);

            var menuModel = Mapper.MenuMapper.MenuToMenuModel(menu);

            return menuModel;
        }

        public RolesModel GetOneRole(int id)
        {
            var getRole = unitOfWork.RoleRepository.GetById(id);

            RolesModel returnRole = Mapper.RoleMapper.RoleDbToRoleModel(getRole);

            return returnRole;
        }

        public IEnumerable<SelectListItem> GetParenMenus()
        {
            var parentMenuList = new List<SelectListItem>();

            var menuList = GetAllMenus();

            foreach (var item in menuList)
            {
                parentMenuList.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()

                });
            }

            return parentMenuList;
        }

        public AssignMenuModel GetRoleAccess(int id)
        {
            var assignMenuModel = new AssignMenuModel();

            List<MenuModel> menuModelList = new List<MenuModel>();

            var menu = unitOfWork.MenuRepository.All().ToList();

            foreach (var item in menu)
            {
                var roleAccess = unitOfWork.RoleAccessRepository.Get(x => x.RoleId == id && x.MenuId == item.Id).FirstOrDefault();

                var menuModel = new MenuModel();

                if (roleAccess !=null)
                {
                    menuModel.Id = roleAccess.MenuId;
                    menuModel.IsSelected = true;
                    menuModel.Name = item.Name;
                    menuModel.MenuDetails = item.MenuDetails;
                    menuModel.Create = roleAccess.AllowAdd;
                    menuModel.Update = roleAccess.AllowEdit;
                    menuModel.Delete = roleAccess.AllowDelete;
                    menuModel.Read = roleAccess.AllowView;


                }
                else
                {
                    menuModel.Id = item.Id;
                    menuModel.Name = item.Name;
                    menuModel.MenuDetails = item.MenuDetails;
                }
                menuModelList.Add(menuModel);
            }

            assignMenuModel.Menu = menuModelList;

            assignMenuModel.Id = id;

            return assignMenuModel;
        }

        public void UpdateMenu(MenuModel model)
        {
            var menu = Mapper.MenuMapper.MenuModelToMenu(model);

            unitOfWork.MenuRepository.Update(menu);

        }

        public void UpdateRole(RolesModel roleModel)
        {
            Role role = Mapper.RoleMapper.RoleModelToRoleDb(roleModel);
            unitOfWork.RoleRepository.Update(role);
        }
    }
}
