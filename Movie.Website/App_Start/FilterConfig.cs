using System.Web;
using System.Web.Mvc;
using Movie.Website.App_Start;

namespace Movie.Website
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            ////登录验证
            //filters.Add(new AuthorizeDiy());
            ////异常处理
            //filters.Add(new ExceptionLogAttribute());
        }
    }
}