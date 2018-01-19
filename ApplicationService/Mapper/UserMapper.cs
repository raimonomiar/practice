using ApplicationRepository;
using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Mapper
{
    public class UserMapper
    {
        public static User UserModelToUserDb(UserModel userModel)
        {
            var user = new User
            {
                UserId = userModel.UserId,
                CreatedDate = userModel.CreatedDate,
                EmailAddress = userModel.EmailAddress,
                IsActive = userModel.IsActive,
                LastLoginDate = userModel.LastLoginDate,
                LoginAttempt = userModel.LoginAttempt,
                LoginCount = userModel.LoginCount,
                LoginId = userModel.LoginId,
                Password = userModel.Password,
                RoleId = userModel.RoleId,
                UpdatedDate = userModel.UpdatedDate,
                Username = userModel.Username,
                OfficeId = userModel.OfficeId,
                DesgId = userModel.DesignationId
                

            };

            return user;
        }

        public static UserModel UserDbToUserModel(User user)
        {
            var users = new UserModel
            {
                UserId = user.UserId,
                CreatedDate = user.CreatedDate,
                EmailAddress = user.EmailAddress,
                IsActive = user.IsActive,
                LastLoginDate = user.LastLoginDate,
                LoginAttempt = user.LoginAttempt,
                LoginCount = user.LoginCount,
                LoginId = user.LoginId,
                Password = user.Password,
                RoleId = user.RoleId,
                RoleName= user.Role.Name,
                UpdatedDate = user.UpdatedDate,
                Username = user.Username,
                DesignationId = user.DesgId,
                OfficeId= user.OfficeId,
                Designation = new DesignationModel
                {
                    Id = Convert.ToInt32(user.DesgId),
                    DesgName =  user.Designation.DesgName
                },
                Office = new OfficeModel
                {
                    Id = Convert.ToInt32(user.OfficeId),
                    OfficeName = user.Office.OfficeName
                }
            };

            return users;
        }

        public static List<UserModel> UserDbToUserModelList(List<User> user)
        {
                var userModelList = new List<UserModel>();
                foreach (var item in user)
                {
                    var userModel = new UserModel
                    {
                        UserId = item.UserId,
                        CreatedDate = item.CreatedDate,
                        EmailAddress = item.EmailAddress,
                        IsActive = item.IsActive,
                        LastLoginDate = item.LastLoginDate,
                        LoginAttempt = item.LoginAttempt,
                        LoginCount = item.LoginCount,
                        LoginId = item.LoginId,
                        Password = item.Password,
                        RoleId = item.RoleId,
                        UpdatedDate = item.UpdatedDate,
                        Username = item.Username,
                        DesignationId = item.DesgId,
                        OfficeId = item.OfficeId,
                        Designation = new DesignationModel
                        {
                            Id = Convert.ToInt32(item.DesgId),
                            DesgName = item.Designation.DesgName
                        },
                        Office = new OfficeModel
                        {
                            Id = Convert.ToInt32(item.OfficeId),
                            OfficeName = item.Office.OfficeName
                        }
                    };

                    userModelList.Add(userModel);
                }

            return userModelList;
            
        }
    }
}
