using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movie.BLL;
using Movie.Model;
using Newtonsoft.Json; 

namespace Movie.Website.Controllers
{
    public class AccountAdminController : Controller
    {
        protected readonly AdminAccountBLL _adminAccountBLL = new AdminAccountBLL();

        //
        // GET: /AccountAdmin/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /AccountAdmin/
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }


        //
        // GET: /AccountAdmin/Add
        [HttpPost]
        public ActionResult Add(AdminAccount account)
        {
            var data = new
            {
                success=true,
                code = 0,
                data =  _adminAccountBLL.Add(account),
                count = 100,
                msg = "",
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /AccountAdmin/List
        [HttpGet]
        public JsonResult List(int page, int limit)
        {
            var data = new
            {
                success = true,
                code = 0,
                data = _adminAccountBLL.GetPageList(page, limit),
                count = 100,
                msg = "",
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        // GET: /AccountAdmin/SetAccountStatus
        [HttpPost]
        public ActionResult SetStatus(int Id, int accountStatus)
        {
            var data = new Object();
            data = new
            {
                code = 0,
                data = _adminAccountBLL.SetStatus(Id, accountStatus),
                count = 100,
                msg = "",
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}
