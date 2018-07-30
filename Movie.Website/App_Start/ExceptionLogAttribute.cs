using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie.Website.App_Start
{
    public class ExceptionLogAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            //写错误日志记录
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string message = string.Format("异常页面：{0}\r\n引发异常源：{1}\r\n消息类型：{2}\r\n消息内容：{3}\r\n引发异常的方法：{4}\r\n堆栈信息：{5}"
                , url
               , filterContext.Exception.Source
                , filterContext.Exception.GetType().Name
                , filterContext.Exception.Message
                 , filterContext.Exception.TargetSite,
                 filterContext.Exception.StackTrace
                 );
            if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
            {
                //SuiBao.Utility.LogHelper.Exception(message);
                var reqWith = filterContext.RequestContext.HttpContext.Request.Params["X-Requested-With"];
                //还有一种判断办法，根据报文头里的accept类型，参考权限验证里面
                if (!string.IsNullOrEmpty(reqWith) && reqWith == "XMLHttpRequest")
                {
                    filterContext.Result = new JavaScriptResult() { Script = "$tools.dangerTip( '系统错误，请稍候再试！');" };
                }
                else
                {
                    filterContext.Result = new JsonResult() { Data = new { Success = false, Msg = "系统错误，请稍候再试！" } };
                }
            }
            else
            {
                //SuiBao.Utility.LogHelper.Exception(message);
                //根据状态码处理
                int statusCode = new HttpException(null, filterContext.Exception).GetHttpCode();
                if (statusCode == 500)
                {
                    filterContext.Result = new RedirectResult("/Error/Http_500");
                    filterContext.HttpContext.Response.StatusCode = 500;
                }
                else if (statusCode == 404)
                {
                    filterContext.Result = new RedirectResult("/Error/Http_404");
                    filterContext.HttpContext.Response.StatusCode = 404;
                }
            }
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

        }
    }
}