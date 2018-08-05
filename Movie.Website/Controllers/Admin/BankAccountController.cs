using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movie.BLL.Bank;
using Movie.Model.Bank;

namespace Movie.Website.Controllers.Admin
{

    public class BankAccountController : BaseController
    {
        protected readonly BankAccountBLL bll = new BankAccountBLL();
        protected readonly BankBLL bankBLL = new BankBLL();
        //
        // GET: /Admin/BankAccount/
        public ActionResult Index()
        {
            return View();
        }


        //
        // GET: /Admin/BankAccount/AllList
        [HttpGet]
        public JsonResult AllList()
        {
            return Json(bll.GetAllList(), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Admin/BankAccount/List
        [HttpGet]
        public JsonResult List(int page, int limit)
        {
            return Json(bll.GetPageList(page, limit), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Admin/BankAccount/Show
        public ActionResult Show(int Id)
        {

            ViewBag.selectTrees = bankBLL.GetSelectTrees();
            ViewBag.model = bll.GetModelById(Id);
            return View();
        }

        //
        // GET: //Admin/BankAccount/Add
        [HttpPost]
        public ActionResult Save(BankAccountModel model)
        {
            return Json(bll.Save(model), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: //Admin/BankAccount/Delete
        [HttpPost]
        public ActionResult DeleteById(long[] Ids)
        {
            return Json(bll.DeleteById(Ids), JsonRequestBehavior.AllowGet);
        } 

        // GET: /Admin/BankAccount/SetStatus
        [HttpPost]
        public ActionResult IsEnable(long[] Ids)
        {
            return Json(bll.SetStatus(Ids,1), JsonRequestBehavior.AllowGet);
        }


        // GET: /Admin/BankAccount/SetStatus
        [HttpPost]
        public ActionResult UnEnable(long[] Ids)
        {
            return Json(bll.SetStatus(Ids, 0), JsonRequestBehavior.AllowGet);
        }

    }
}
