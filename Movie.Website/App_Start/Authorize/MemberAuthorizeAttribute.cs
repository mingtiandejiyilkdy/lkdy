using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Movie.Website.Authorize
{
    public class MemberAuthorizeAttribute : CustomAuthorizeAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="log">是否记录日志</param>
        /// <param name="message">备注</param>
        public MemberAuthorizeAttribute(bool log = false, string message = "")
        {
            base._log = log;
            base._message = message;
        }

        /// <summary>
        /// 权限验证
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            if (HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            //if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
