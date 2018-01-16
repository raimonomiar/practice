using ApplicationRepository.UnitOfWork;
using ApplicationService.GlobalSelectList;
using ApplicationService.Helper;
using ApplicationService.Implementation;
using ApplicationService.Interface;
using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace WebProject.Controllers.Setup
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        private readonly IUnitOfWork unitOfWork;

        private readonly IDynamicSelectList dynamicList;
        public UserController()
        {
            userService = new UserService();

            unitOfWork = new UnitOfWork();

            dynamicList = new DynamicSelectList();

        }

        // GET: User
        public ActionResult Index()
        {
            var model = userService.GetEmptyUserModel();

            model.UserList = userService.GetAllUser();

            return View(@"~\Views\Setup\User\Index.cshtml", model);
        }

        public ActionResult Create()
        {
            UserModel model = userService.GetEmptyUserModel();

            model.dRoleList = dynamicList.GetRolesSelectList();

            return View(@"~\Views\Setup\User\Create.cshtml",model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserModel model)
        {
            try
            {
                if (unitOfWork.UserRepository.Get(x => x.LoginId == model.LoginId).Any())
                {
                    ModelState.AddModelError("Invalid Username","Username Exists!!!");
                }

                if (ModelState.IsValid)
                {
                    model.CreatedDate = DateTime.Now;

                    model.Password = HashPassword.GetMd5Hash(MD5.Create(), model.Password);

                    userService.AddUser(model);

                    TempData["Success"] = "New User Added !!";

                    return RedirectToAction("Index");
                }

                model.dRoleList = dynamicList.GetRolesSelectList();

                return View(@"~\Views\Setup\User\Create.cshtml", model);
            }
            catch (DbEntityValidationException e)
            {

                TempData["Danger"] = e.Message;
            }
            return View(@"~\Views\Setup\User\Create.cshtml", model);

        }

        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = userService.GetUser(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            user.dRoleList = dynamicList.GetRolesSelectList();

            return View(@"~\Views\Setup\User\Update.cshtml", user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(UserModel model)
        {
            try
            {
                ModelState["LoginId"].Errors.Clear();

                ModelState["Password"].Errors.Clear();

                ModelState["ConfirmPassword"].Errors.Clear();

                if (ModelState.IsValid)
                {
                    model.UpdatedDate = DateTime.Now;

                    userService.UpdateUserRecord(model);

                    TempData["Success"] = "User Updated !!";

                    return RedirectToAction("Index");

                }

                TempData["Danger"] = "Form Error";
                model.dRoleList = dynamicList.GetRolesSelectList();
                return View(@"~\Views\Setup\User\Update.cshtml", model);

            }
            catch (Exception e)
            {

                TempData["Danger"] = e.Message;
            }

            return RedirectToAction("Update",model);

        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var getUser = userService.getSingleUser(id);

            return View(@"~\Views\Setup\User\Detail.cshtml",getUser);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                userService.Delete(id);

                TempData["Success"] = "User Deleted !!!";

            }
            catch (Exception e)
            {
                TempData["Danger"] = e.Message;
            }

            return RedirectToAction("Index");


        }
        public JsonResult IsUsernameAvailable(string LoginId)
        {
            return Json(!unitOfWork.UserRepository
                .Get(x => x.LoginId == LoginId).Any(),
                JsonRequestBehavior.AllowGet);

        }
    }
}