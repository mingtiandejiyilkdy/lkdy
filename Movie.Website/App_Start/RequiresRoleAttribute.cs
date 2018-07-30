using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Movie.Website.App_Start
{
    public class RequiresRoleAttribute : ActionFilterAttribute
    {
        public string Role { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!string.IsNullOrEmpty(Role))
            {
                if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    string returnUrl = filterContext.HttpContext.Request.Url.AbsolutePath;
                    string redirectUrl = string.Format("?ReturnUrl={0}", returnUrl);
                    string loginUrl = FormsAuthentication.LoginUrl + redirectUrl;
                    filterContext.HttpContext.Response.Redirect(loginUrl, true);
                }
                else
                {
                    bool isAuthenticated = filterContext.HttpContext.User.IsInRole(Role);
                    if (!isAuthenticated)
                    {
                        throw new UnauthorizedAccessException("You have no right to view the page!");
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("No Role Specified!");
            }
        }
    }    
}