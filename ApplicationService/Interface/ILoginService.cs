using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Interface
{
    public interface ILoginService
    {
        UserModel GetUserDetails(UserModel model);

        int UpdatePassword(int userId, string password);
    }
}
