using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;   
using Movie.Model.Tenant;
using Movie.BLL.Tenant;

namespace Movie.Website.Controllers.Admin
{

    public class TenantController : BaseController
    {
        protected readonly TenantBLL bll = new TenantBLL();
        //
        // GET: /Admin/Tenant/
        public ActionResult Index()
        {
            return View();
        }


        //
        // GET: /Admin/Tenant/AllList
        [HttpGet]
        public JsonResult AllList()
        {
            return Json(bll.GetAllList(), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Admin/Tenant/List
        [HttpGet]
        public JsonResult List(int page, int limit)
        {
            return Json(bll.GetPageList(page, limit), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Admin/Tenant/Show
        public ActionResult Show(int Id)
        {
            ViewBag.model = bll.GetModelById(Id);
            return View();
        }

        //
        // GET: //Admin/Tenant/Add
        [HttpPost]
        public ActionResult Save(TenantModel model)
        {
            return Json(bll.Save(model), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: //Admin/Tenant/Delete
        [HttpPost]
        public ActionResult DeleteById(long[] Ids)
        {
            return Json(bll.DeleteById(Ids), JsonRequestBehavior.AllowGet);
        }

        // GET: /Admin/Tenant/IsEnable
        [HttpPost]
        public ActionResult IsEnable(long[] Ids)
        {
            return Json(bll.SetStatus(Ids,1), JsonRequestBehavior.AllowGet);
        }


        // GET: /Admin/Tenant/UnEnable
        [HttpPost]
        public ActionResult UnEnable(long[] Ids)
        {
            return Json(bll.SetStatus(Ids, 0), JsonRequestBehavior.AllowGet);
        }

    }
}
