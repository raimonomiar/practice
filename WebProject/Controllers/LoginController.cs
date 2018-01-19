using ApplicationService.Implementation;
using ApplicationService.Interface;
using ApplicationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using WebProject.Models;
using System.Web.Security;

namespace WebProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService loginService;

        private readonly IMenuService menuService;

        public LoginController()
        {
            loginService = new LoginService();

            menuService = new MenuService();
        }
        // GET: Login
        //public ActionResult Index()
        //{
        //    return View();
        //}


        public ActionResult LoginMissingFound() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        [OutputCache(Duration =3600,VaryByParam ="none",Location =System.Web.UI.OutputCacheLocation.Client,NoStore =true)]
        public  ActionResult LoginMissingFound(LoginViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                var userModel = new UserModel
                {
                    LoginId = model.LoginId,
                    Password = model.Password
                };

                var auth = loginService.GetUserDetails(userModel);

                if (auth.UserId>0)
                {

                    var identity = new ClaimsIdentity(new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,auth.Username),
                        new Claim(ClaimTypes.Email, auth.EmailAddress),
                        new Claim(ClaimTypes.Role,auth.RoleName),
                        new Claim("RoleId", auth.RoleId.ToString()),
                        new Claim("OfficeId", auth.Office.Id.ToString()),
                        new Claim("UserId", auth.UserId.ToString())
                    },
                    "ApplicationCookie");

                    var ctx = Request.GetOwinContext();

                    var authManager = ctx.Authentication;

                    authManager.SignIn(identity);

                    Session["UserId"] = auth.UserId;
                    Session["RoleId"] = auth.RoleId;
                    Session["OfficeId"] = auth.Office.Id;

                    return Redirect(GetRedirectUrl(userModel.ReturnUrl));
                }

                ModelState.AddModelError("", "Invalid Credentials");

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }
            return View();

        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) ||!Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("Index", "Dashboard");

            }

            return returnUrl;
        }

        public ActionResult Logout()
        {
            Session.Clear();

            Session.Abandon();

            FormsAuthentication.SignOut();

            var ctx = Request.GetOwinContext();

            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");

            return RedirectToAction("LoginMissingFound");

        }


        //public ActionResult SidebarSecondaryMenuList()
        //{
        //    var roleId = ((ClaimsIdentity)User.Identity).FindFirst("RoleId").Value;

        //    var activeMenus = menuService.GetAllActiveMenus(Convert.ToInt32(roleId));

        //    return View(activeMenus);
        //}

        [ChildActionOnly]
        public ActionResult GetMainMenuList()
        {
            //var roleId = ((ClaimsIdentity)User.Identity).FindFirst("RoleId").Value;

            //var mainMenuList = menuService.GetMainMenuList(Convert.ToInt32(roleId));

            //return View(mainMenuList);

            var roleId = ((ClaimsIdentity)User.Identity).FindFirst("RoleId").Value;



            var mainMenuList = menuService.GetMainMenuList(Convert.ToInt32(roleId));


            //var activeMenus = menuService.GetAllActiveMenus(Convert.ToInt32(roleId));

            foreach (var item in mainMenuList)
            {
                item.ChildMenu = menuService.GetAllActiveMenus(Convert.ToInt32(roleId), item);
            }

            //foreach (var item in menuModel)
            //{
            //    item.ChildMenu = activeMenus;
            //}
            
            return PartialView("_PartialSidebar",mainMenuList);

        }


    }
}