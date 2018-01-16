using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Interface
{
    public interface IUserService
    {

        void AddUser(UserModel userModel);

        void UpdateUser(UserModel userModel);

        void UpdateUserRecord(UserModel model);
        void Delete(object id);

        UserModel GetEmptyUserModel();
        UserModel GetUser(int? id);

        List<UserModel> GetAllUser();
        UserModel getSingleUser(int? id);
    }
}
