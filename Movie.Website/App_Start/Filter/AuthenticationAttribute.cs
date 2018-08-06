using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Movie.ViewModel;
using System.Web.Script.Serialization;
using Movie.Model.Tenant;
using Movie.Common;
using Movie.BLL.Tenant;

namespace Movie.Website.App_Start.Filter
{
    /// <summary>
    /// 登录身份验证
    /// </summary>
    public class AuthenticationAttribute : ActionFilterAttribute
    {
        protected readonly TenantBLL tenantBLL = new TenantBLL();
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

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //获取当前域名
            string host = filterContext.HttpContext.Request.Url.Host;
            long tenantId = 0;
            TenantModel tenant = tenantBLL.GetAllModelList().Find(o => o.TenantDomain.ToLower() == host.ToLower());
            if (tenant != null)
            {
                tenantId = tenant.ID;
            } 

            //获取当前控制器信息
            string controllername = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower();
            string actionname = filterContext.ActionDescriptor.ActionName.ToLower();
            string allowActions = string.Empty;
          

            if (!filterContext.RequestContext.HttpContext.Request.IsAuthenticated)
            {
                //未登录的时候，此处加了一个判断，判断同步请求还是一部请求
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    //异步请求，返回JSON数据
                    filterContext.Result = new JsonResult
                    {
                        Data = new
                        {
                            Status = -1,
                            Message = "登录已过期，请刷新页面后操作!"
                        },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else
                {
                    //非异步请求，则跳转登录页
                    FormsAuthentication.RedirectToLoginPage();//重定向会登录页
                }
            }
            else
            {
                //1.登录状态获取用户信息（自定义保存的用户）
                var cookie = filterContext.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];

                //2.使用 FormsAuthentication 解密用户凭据
                var ticket = FormsAuthentication.Decrypt(cookie.Value);
                AccountViewModel loginUser = new AccountViewModel();

                //3. 直接解析到用户模型里去，有没有很神奇
                loginUser = new JavaScriptSerializer().Deserialize<AccountViewModel>(ticket.UserData);

                //4. 将要使用的数据放到ViewData 里，方便页面使用
                filterContext.Controller.ViewData["UserName"] = loginUser.AccountName;
                //filterContext.Controller.ViewData["Portrait"] = loginUser.Portrait;
                filterContext.Controller.ViewData["UserID"] = loginUser.ID;
            }
            // 别忘了这一句。
            base.OnActionExecuting(filterContext);
        }
    }
}