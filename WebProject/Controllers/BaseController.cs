using ApplicationService.Implementation;
using ApplicationService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebProject.Controllers
{
    public abstract class BaseController : Controller
    {
        public ICommonService CommonService { get; set; }

        public BaseController()
        {
            CommonService = new CommonService();
        }

        protected override void Initialize(RequestContext requestContext)
        {
            try
            {
                base.Initialize(requestContext);

                ViewBag.UserId = Session["UserId"];
                ViewBag.RoleId = Session["RoleId"];

                if (Session["OfficeId"] !=null && (int)Session["OfficeId"] !=0)
                {
                    ViewBag.OfficeName = CommonService.GetOfficeNameById(Convert.ToInt32(Session["OfficeId"]));

                    Session["OfficeName"] = ViewBag.OfficeName;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var context = System.Web.HttpContext.Current;

            var roleId = Convert.ToInt32(Session["RoleId"]);

            var session = filterContext.HttpContext.Session;

            if (((context.Session["RoleId"] == null) && (!session.IsNewSession))||(session.IsNewSession))
            {
                var url = new UrlHelper(filterContext.RequestContext);

                var loginUrl = url.Content("~/Login/LoginMissingFound");

                filterContext.HttpContext.Response.Redirect(loginUrl, true);


            }

            string controllerName = System.Web.HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString().ToLower();

            string actionName = System.Web.HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString().ToLower();

            var menuId = CommonService.GetMenuId(controllerName);

            var roleAccess = CommonService.GetRoleAccessByMenuIdAndRoleId(menuId, roleId);

            ViewBag.ParentMenuName = "";

            ViewBag.ParentMenuLink = "";

            ViewBag.ParentMenuController = "";

            ViewBag.ActionName = "";

            if (menuId > 0)
            {
                var menuDetails = CommonService.GetMenuById(menuId);

                if(menuDetails.ParentId>0)
                {
                    var parentDetails = CommonService.GetMenuById(Convert.ToInt32(menuDetails.ParentId));

                    if (parentDetails !=null)
                    {

                        ViewBag.ParentMenuName = parentDetails.Name;

                        ViewBag.ParentMenuLink = parentDetails.MenuLink;

                        ViewBag.ParentMenuController = parentDetails.Controller;
                    }
                }
              
            }

            else
            {
                ViewBag.ControllerName = "";
            }

            if (roleId != 1002)
            {
                if (roleAccess!=null)
                {
                    switch (actionName)
                    {
                        case "create":
                            if (roleAccess.AllowAdd !=true)
                            {
                                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "UnAuthorized", controller = "Dashboard" }));

                            }
                            break;
                        case "edit":
                            if (roleAccess.AllowEdit != true)
                            {
                                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "UnAuthorized", controller = "Dashboard" }));

                            }
                            break;
                        case "delete":
                            if (roleAccess.AllowDelete != true)
                            {
                                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "UnAuthorized", controller = "Dashboard" }));

                            }
                            break;
                        case "index":
                            if (roleAccess.AllowView != true)
                            {
                                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "UnAuthorized", controller = "Dashboard" }));

                            }
                            break;

                        default:
                            break;

                    }
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "UnAuthorized", controller = "Dashboard" }));

                }
            }

        }


    }    
}