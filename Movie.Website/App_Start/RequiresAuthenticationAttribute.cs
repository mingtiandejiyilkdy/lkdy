using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using System.Web.Mvc;
using System.Web.Security;

namespace Movie.Website.App_Start
{
    public class RequiresAuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                string returnUrl = filterContext.HttpContext.Request.Url.AbsolutePath;
                string redirectUrl = string.Format("?ReturnUrl={0}", returnUrl);
                string loginUrl = FormsAuthentication.LoginUrl + redirectUrl;
                filterContext.HttpContext.Response.Redirect(loginUrl, true);
            }
        }
    }   
}