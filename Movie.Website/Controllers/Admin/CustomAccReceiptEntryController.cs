using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movie.BLL.Financial; 
using Movie.Model.Financial;
using Movie.BLL.Custom;
using Movie.BLL.Bank;
using Movie.BLL.Ticket;

namespace Movie.Website.Controllers.Admin
{

    public class CustomAccReceiptEntryController : BaseController
    {
        protected readonly CustomAccReceiptEntryBLL bll = new CustomAccReceiptEntryBLL();
        //
        // GET: /Admin/CustomAccReceiptEntry/
        public ActionResult Index()
        {
            return View();
        }


        //
        // GET: /Admin/CustomAccReceiptEntry/AllList
        [HttpGet]
        public JsonResult AllList()
        {
            return Json(bll.GetAllList(), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Admin/CustomAccReceiptEntry/List
        [HttpGet]
        public JsonResult List(int page, int limit)
        {
            return Json(bll.GetPageList(page, limit), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Admin/CustomAccReceiptEntry/Show
        public ActionResult Show(int Id)
        {
            ViewBag.selectTrees = new CustomBLL().GetSelectTrees();
            ViewBag.chargeCardNos = new CustomChargeCardBLL().GetSelectTrees();
            ViewBag.bankAccounts = new BankAccountBLL().GetSelectTrees();
            ViewBag.model = bll.GetModelById(Id);
            return View();
        }

        //
        // GET: //Admin/CustomAccReceiptEntry/Add
        [HttpPost]
        public ActionResult Save(CustomAccReceiptEntryModel model)
        {
            return Json(bll.Save(model), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: //Admin/CustomAccReceiptEntry/Delete
        [HttpPost]
        public ActionResult DeleteById(long[] Ids)
        {
            return Json(bll.DeleteById(Ids), JsonRequestBehavior.AllowGet);
        }

        // GET: /Admin/CustomAccReceiptEntry/IsEnable
        [HttpPost]
        public ActionResult IsEnable(long[] Ids)
        {
            return Json(bll.SetStatus(Ids,1), JsonRequestBehavior.AllowGet);
        }


        // GET: /Admin/CustomAccReceiptEntry/UnEnable
        [HttpPost]
        public ActionResult UnEnable(long[] Ids)
        {
            return Json(bll.SetStatus(Ids, 0), JsonRequestBehavior.AllowGet);
        }

    }
}
