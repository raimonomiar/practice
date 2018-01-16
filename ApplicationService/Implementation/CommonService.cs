using ApplicationRepository;
using ApplicationRepository.UnitOfWork;
using ApplicationService.Interface;
using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementation
{
    public class CommonService : ICommonService
    {
        private  practiceEntities DB;

        private readonly IUnitOfWork unitOfWork;

        public CommonService()
        {
            unitOfWork = new UnitOfWork();

        }

        public AccessModel GetAccessValue(int menuId, int roleId)
        {

            if (roleId ==1002)
            {
                AccessModel model = new AccessModel
                {
                    CanAdd = true,
                    CanDelete = true,
                    CanEdit = true,
                    CanView = true
                };
                return model;
                
            }
            else
            {
                using (DB = new practiceEntities())
                {
                    AccessModel model;

                    var accessData = DB.RoleAccesses.FirstOrDefault(a => a.MenuId == menuId && a.RoleId == roleId);

                    if (accessData!=null)
                    {
                        model = new AccessModel
                        {
                            CanAdd = accessData.AllowAdd,
                            CanEdit = accessData.AllowEdit,
                            CanView = accessData.AllowView,
                            CanDelete = accessData.AllowDelete
                        };

                    }
                    else
                    {
                        model = new AccessModel
                        {
                            CanAdd = false,
                            CanDelete = false,
                            CanEdit = false,
                            CanView =false
                        };
                    }
                    return model;

                }

              
              
            }


        }

        public Menu GetMenuById(int menuId)
        {
            try
            {
                using (DB= new practiceEntities())
                {
                    var menu = DB.Menus.FirstOrDefault(x => x.Id == menuId);

                    return menu;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return null;
            }
        }

        public int GetMenuId(string controllerName)
        {
            try
            {
                using (DB = new practiceEntities())
                {
                    var menu = DB.Menus.FirstOrDefault(x => x.Controller == controllerName);

                    if (menu != null)
                    {

                        return menu.Id;
                    }

                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return 0;
            }
        }

        public string GetOfficeNameById(int officeId)
        {
            using (DB = new practiceEntities())
            {
                var office = DB.Offices.FirstOrDefault(x => x.Id == officeId);

                var text = office != null ? office.OfficeName : "";

                return text;
            }
        }

        public RoleAccess GetRoleAccessByMenuIdAndRoleId(int menuId, int roleId)
        {
            using (DB = new practiceEntities())
            {

                var roleAccess = DB.RoleAccesses.FirstOrDefault(a => a.MenuId == menuId && a.RoleId == roleId);

                return roleAccess;
            }
        }
    }
}
