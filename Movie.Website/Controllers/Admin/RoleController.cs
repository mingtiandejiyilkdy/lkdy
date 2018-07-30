using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movie.BLL;
using Movie.Model;
using Movie.Common.Utils;

namespace Movie.Website.Controllers.Admin
{

    public class RoleController : BaseController
    {
        protected readonly AdminRoleBLL bll = new AdminRoleBLL();
        protected readonly AdminAccountBLL accountbll = new AdminAccountBLL();
        //
        // GET: /Admin/Role/
        public ActionResult Index()
        {
            return View();
        }


        //
        // GET: /Admin/Role/AllList
        [HttpGet]
        public JsonResult AllList()
        {
            return Json(bll.GetAllList(), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Admin/Role/List
        [HttpGet]
        public JsonResult List(int page, int limit)
        {
            return Json(bll.GetPageList(page, limit), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Admin/Role/Show
        public ActionResult Show(int Id)
        {
            ViewBag.model = bll.GetModelById(Id);
            return View();
        }

        //
        // GET: /Admin/Role/Add
        [HttpPost]
        public ActionResult Save(AdminRole model, int[] itemIds)
        {
            model.MenuIds = string.Join(",", itemIds);
            return Json(bll.Save(model), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /AccountAdmin/Delete
        [HttpPost]
        public ActionResult DeleteById(int Id)
        {
            return Json(bll.DeleteById(Id), JsonRequestBehavior.AllowGet);
        }



        // GET: /Admin/Role/SetStatus
        [HttpPost]
        public ActionResult SetStatus(int Id, int status)
        {
            return Json(bll.SetStatus(Id, status), JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// 分配角色
        /// </summary>
        /// <returns></returns>
        // GET: /Admin/Role/SetRole
        public ActionResult SetRole(int Id)
        {
            AdminAccount account = accountbll.GetModelById(Id);
            ViewBag.model = account;
            return View();
        }

        //
        // GET: /Admin/Role/AllRoleList
        [HttpGet]
        public JsonResult GetRoleTreeSelect(int Id)
        {
            return Json(bll.GetRoleTreeSelect(Id), JsonRequestBehavior.AllowGet);
        }


        //
        // GET: /Admin/Role/Add
        [HttpPost]
        public ActionResult AccountRoleSave(AdminAccount model, int[] itemIds)
        {
            return Json(bll.SaveAccountRole(model, itemIds), JsonRequestBehavior.AllowGet);
        }
    }
}
