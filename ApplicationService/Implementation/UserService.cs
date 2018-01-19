using ApplicationService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationService.Models;
using ApplicationRepository.UnitOfWork;
using ApplicationRepository;
using System.Data.Entity;
using System.Transactions;

namespace ApplicationService.Implementation
{
    public class UserService : IUserService
    {

        private readonly IUnitOfWork unitOfWork;

        private readonly practiceEntities DB;

        public UserService(IUnitOfWork _unitOfWork = null)
        {
            unitOfWork = _unitOfWork ?? new UnitOfWork();
            DB = new practiceEntities();
        }
        public void AddUser(UserModel userModel)
        {

            User user = Mapper.UserMapper.UserModelToUserDb(userModel);

            unitOfWork.UserRepository.Create(user);
        }

        public void Delete(object id)
        {
            if (id !=null)
            {
                unitOfWork.UserRepository.Delete(id);
            }
        }

        public List<UserModel> GetAllUser()
        {
            //List<User> users = unitOfWork.UserRepository.All().ToList();

            var users = DB.Users
                .Include(x => x.Role)
                .Select(x => new UserModel
                {
                    UserId = x.UserId,
                    Username = x.Username,
                    RoleName = x.Role.Name,
                    IsActive = x.IsActive
                })
                .ToList();


            return users;
        }

        public UserModel getSingleUser(int? id)
        {
            var user = DB.Users.
                Where(x => x.UserId == id)
                .Include(x => x.Role)
                .Select(x => new UserModel
                {
                    UserId = x.UserId,
                    LoginId = x.LoginId,
                    Username = x.Username,
                    EmailAddress = x.EmailAddress,
                    RoleName = x.Role.Name,
                    RoleId = x.RoleId,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate,
                    IsActive = x.IsActive
                }).SingleOrDefault();

            return user;
        }

        public UserModel GetEmptyUserModel() => new UserModel();

  

        public UserModel GetUser(int? id)
        {
            User user = unitOfWork.UserRepository.GetById(id);

            return Mapper.UserMapper.UserDbToUserModel(user);
        }

        

        public void UpdateUser(UserModel userModel)
        {
            User user = Mapper.UserMapper.UserModelToUserDb(userModel);

            unitOfWork.UserRepository.Update(user);
        }

        public void UpdateUserRecord(UserModel model)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                User result = DB.Users.FirstOrDefault(u => u.UserId == model.UserId);

                if (result !=null)
                {
                    result.RoleId = model.RoleId;
                    result.DesgId = model.DesignationId;
                    result.OfficeId = model.OfficeId;
                    result.Username = model.Username ?? result.Username;
                    result.LoginId = model.LoginId ?? result.LoginId;
                    result.UpdatedDate = model.UpdatedDate;
                    result.IsActive = model.IsActive;
                    result.EmailAddress = model.EmailAddress;
                    
                }

                DB.Entry(result).CurrentValues.SetValues(result);
                DB.SaveChanges();
                ts.Complete();
            }
        }
    }
}
