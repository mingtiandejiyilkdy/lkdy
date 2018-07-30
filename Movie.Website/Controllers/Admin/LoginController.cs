using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Movie.BLL;
using Movie.Model;
using Movie.Common.Utils;
using System.Web.Script.Serialization;
using Movie.ViewModel;

namespace Movie.Website.Controllers
{
    public class LoginController : Controller
    {
        protected readonly AdminAccountBLL bll = new AdminAccountBLL();
        //
        // GET: /Admin/Login/

        public ActionResult Index()
        {
            return View();
        }
         
        [HttpPost]
        public ActionResult LoginIn(string username, string password, string rememberMe, string returnUrl)
        {
            JsonRsp json = new JsonRsp { success = false };
            if (!ModelState.IsValid)
            {
                return Json(json, JsonRequestBehavior.AllowGet); 
            }

            bool status = Request.IsAuthenticated;


            json = bll.Login(username, password);
            if (!json.success) {
                return Json(json, JsonRequestBehavior.AllowGet); 
            }

            //4. 用户描述用户基本信息
            AccountViewModel userInfo = new AccountViewModel()
            {
                ID = json.code,
                AccountName = json.retmsg, 
            };

            //2.用它来序列化要对象
            JavaScriptSerializer serial = new JavaScriptSerializer();
            //5. 生成初始化凭据
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                1,
                username,
                DateTime.Now,
                DateTime.Now.AddMinutes(30),
                false,
                serial.Serialize(userInfo)
                );
            //6. 加密
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            //7. 响应到客户端
            System.Web.HttpCookie authCookie = new System.Web.HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);
            //8. 返回首页， 也可以跳回 RetureUrl

            if (!String.IsNullOrEmpty(returnUrl))
                json.retmsg = returnUrl;
            else
                json.retmsg = "/Admin/Home/"; 
            return Json(json, JsonRequestBehavior.AllowGet); 
            //if (!String.IsNullOrEmpty(returnUrl)) return Redirect(returnUrl);
            //else return RedirectToAction("Home", "Admin"); 
        }

        /// <summary>
        /// 注销方法,退出登录
        /// </summary>
        public void LogOut()
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}
