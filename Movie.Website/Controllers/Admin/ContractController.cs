using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;   
using Movie.Model.Contract;
using Movie.BLL.Contract;
using Movie.BLL.Custom;

namespace Movie.Website.Controllers.Admin
{

    public class ContractController : BaseController
    {
        protected readonly ContractBLL bll = new ContractBLL();
        //
        // GET: /Admin/Contract/
        public ActionResult Index()
        {
            return View();
        }


        //
        // GET: /Admin/Contract/AllList
        [HttpGet]
        public JsonResult AllList()
        {
            return Json(bll.GetAllList(), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Admin/Contract/List
        [HttpGet]
        public JsonResult List(int page, int limit)
        {
            return Json(bll.GetPageList(page, limit), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Admin/Contract/Show
        public ActionResult Show(int Id)
        {
            ViewBag.selectTrees = new CustomBLL().GetSelectTrees();
            ViewBag.model = bll.GetModelById(Id);
            return View();
        }

        //
        // GET: //Admin/Contract/Add
        [HttpPost]
        public ActionResult Save(ContractModel model)
        {
            return Json(bll.Save(model), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: //Admin/Contract/Delete
        [HttpPost]
        public ActionResult DeleteById(long[] Ids)
        {
            return Json(bll.DeleteById(Ids), JsonRequestBehavior.AllowGet);
        }

        // GET: /Admin/Contract/IsEnable
        [HttpPost]
        public ActionResult IsEnable(long[] Ids)
        {
            return Json(bll.SetStatus(Ids,1), JsonRequestBehavior.AllowGet);
        }


        // GET: /Admin/Contract/UnEnable
        [HttpPost]
        public ActionResult UnEnable(long[] Ids)
        {
            return Json(bll.SetStatus(Ids, 0), JsonRequestBehavior.AllowGet);
        }

    }
}
