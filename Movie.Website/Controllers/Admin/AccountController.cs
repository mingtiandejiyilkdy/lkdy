using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movie.BLL;
using Movie.Model;

namespace Movie.Website.Controllers.Admin
{

    public class AccountController : BaseController
    {
        protected readonly AdminAccountBLL bll = new AdminAccountBLL();
        //
        // GET: /Admin/Account/
        public ActionResult Index()
        {
            return View();
        }


        //
        // GET: /Admin/Account/AllList
        [HttpGet]
        public JsonResult AllList()
        {
            return Json(bll.GetAllList(), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Admin/Account/List
        [HttpGet]
        public JsonResult List(int page, int limit)
        {
            return Json(bll.GetPageList(page, limit), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Admin/Account/Show
        public ActionResult Show(int Id)
        {
            ViewBag.model = bll.GetModelById(Id);
            return View();
        }

        //
        // GET: /AccountAdmin/Add
        [HttpPost]
        public ActionResult Save(AdminAccount model)
        {
            return Json(bll.Save(model), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /AccountAdmin/Delete
        [HttpPost]
        public ActionResult DeleteById(int Id)
        {
            return Json(bll.DeleteById(Id), JsonRequestBehavior.AllowGet);
        }



        // GET: /Admin/Account/SetStatus
        [HttpPost]
        public ActionResult SetStatus(int Id, int status)
        {
            return Json(bll.SetStatus(Id, status), JsonRequestBehavior.AllowGet);
        }

    }
}
