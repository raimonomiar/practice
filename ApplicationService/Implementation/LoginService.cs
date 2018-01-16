using ApplicationService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationService.Models;
using ApplicationRepository.UnitOfWork;
using System.Security.Cryptography;
using ApplicationService.Helper;

namespace ApplicationService.Implementation
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork unitOfWork;

        public LoginService(IUnitOfWork _unitOfWork =null)
        {
            unitOfWork = _unitOfWork ?? new UnitOfWork();
        }
        public UserModel GetUserDetails(UserModel model)
        {
            try
            {
                var userModel = new UserModel();

                var user = unitOfWork.UserRepository.Get(x => x.LoginId.ToLower() == model.LoginId.ToLower()).FirstOrDefault();

                if (user !=null)
                {
                    using (MD5 md5Hash = MD5.Create())
                    {
                        if (HashPassword.VerifyMd5Hash(md5Hash,model.Password,user.Password))
                        {
                            user = unitOfWork.UserRepository.Get(x => (x.LoginId == model.LoginId && x.Password == user.Password)).FirstOrDefault();

                            if (user != null)
                            {
                                userModel = Mapper.UserMapper.UserDbToUserModel(user);

                            }

                            return userModel;
                        }

                    }
                }

                return userModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return null;

            }

        }

        public int UpdatePassword(int userId, string password)
        {
                   return 0;
        }
    }
}
