﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;


namespace Movie.Common.Filter
{
    /// <summary>
    /// 这个过滤器类继承ActionFilterAttribute
    /// </summary>
    public class LoginFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 改写onactionexecuting(在controller action执行之前调用)，去判断请求中是不是存了session。使用场景：如何验证登录等。
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["UserName"] == null)
            {
                filterContext.HttpContext.Response.Redirect("/Login/");                
            }//这种是通过返回一段js代码来实现跳转登录页面
            //if (filterContext.HttpContext.Session["UserName"] == null)
            //{
            //    filterContext.HttpContext.Response.Redirect("/Users/Login");
            //}//这种就是直接通过过滤器上下文的的http上下文请求来进行重置链接
        }

        /// <summary>
        /// 在Action方法调用后，result方法调用前执行，使用场景：异常处理。
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //  base.OnActionExecuted(filterContext);
        }

        /// <summary>
        /// 在result执行前发生(在view 呈现前)，使用场景：设置客户端缓存，服务器端压缩.
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //base.OnResultExecuting(filterContext);
        }
        /// <summary>
        /// 在result执行后发生，使用场景：异常处理，页面尾部输出调试信息。
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //  base.OnResultExecuted(filterContext);
        }
    }
}

