using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movie.BLL;

namespace Movie.Website.Controllers
{
    public class AdminController : Controller
    {

        protected LoginBLL _loginBLL = new LoginBLL();
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        } 
    }
}
