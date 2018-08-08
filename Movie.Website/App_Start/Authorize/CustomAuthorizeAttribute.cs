using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movie.Common;
using Movie.Common.Utils;

namespace Movie.Website.App_Start.Authorize
{

    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 是否记录日志
        /// </summary>
        protected bool _log;
        /// <summary>
        /// 备注信息
        /// </summary>
        protected string _message;
        /// <summary>
        /// 控制器名称
        /// </summary>
        protected string controllername;
        /// <summary>
        /// 操作名称
        /// </summary>
        protected string actionname;

        /// <summary>
        /// 无权访问
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
            else
            {
                filterContext.HttpContext.Response.Write("未登录，请重新登录");
            }
            base.HandleUnauthorizedRequest(filterContext);
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            // 过滤不需要验证的页面 start  allowGuestPages.Add("controllerName", "|actionName1|actionName2|");
            // //过滤整个控制器用 allowGuestPages.Add("controllerName", "all");

            Dictionary<string, string> allowGuestPages = new Dictionary<string, string>();
            if (CacheHelper.GetSession("webAllowPages") == null)
            {
                string webAllowPages = Util.WebAllowPages.ToLower();
                string[] pages = Util.SplitString(webAllowPages, ",");
                foreach (string page in pages)
                {
                    string[] subPages = Util.SplitString(page, "/");
                    allowGuestPages.Add(subPages[0].ToString(), subPages[1].ToString());
                }
                CacheHelper.SetSession("webAllowPages", allowGuestPages);
            }
            else
            {
                allowGuestPages = (Dictionary<string, string>)(CacheHelper.GetSession("webAllowPages"));
            }

            string controllername = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower();
            string actionname = filterContext.ActionDescriptor.ActionName.ToLower();
            string allowActions = string.Empty;
            if (allowGuestPages.TryGetValue(controllername, out allowActions))
            {
                allowActions = allowActions.ToLower();
                if (allowActions == "all" || allowActions.Contains("|" + actionname + "|"))
                {
                    return;
                }
            }
            // 过滤不需要验证的页面 end

            // 权限验证 start
            if (AuthorizeCore(filterContext.HttpContext))
            {
                //if (!new BaseUser().HasRight(controllername, actionname))
                //{
                //    string msg = "没有权限";
                //    string strUrl = "/Error?code=-403&msg={0}";
                //    filterContext.HttpContext.Response.Redirect(string.Format(strUrl, HttpUtility.UrlEncode(msg)), true);
                //}
                ////if (_log)
                ////{
                ////    Model.T_UserLog log = new Model.T_UserLog();
                ////    log.UserName = User.LogOnUser.UserName;
                ////    log.ActionModule = controllername;
                ////    log.ActionName = actionname;
                ////    log.ActionTime = DateTime.Now;
                ////    log.ActionIP = filterContext.HttpContext.Request.UserHostAddress;
                ////    log.Remark = _message;
                ////    new BLL.UserLog().Save(log);
                ////}
                filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            }
            else
            {
                HandleUnauthorizedRequest(filterContext);
            }
            // 权限验证 start

            base.OnAuthorization(filterContext);
        }
    }
}
