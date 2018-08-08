using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;  
using Movie.BLL.Merchant;
using Movie.Model.Merchant;

namespace Movie.Website.Controllers.Admin
{

    public class MerchantController : BaseController
    {
        protected readonly MerchantBLL bll = new MerchantBLL();
        protected readonly MerchantTypeBLL MerchantTypeBLL = new MerchantTypeBLL();
        //
        // GET: /Admin/Merchant/
        public ActionResult Index()
        {
            return View();
        }


        //
        // GET: /Admin/Merchant/AllList
        [HttpGet]
        public JsonResult AllList()
        {
            return Json(bll.GetAllList(), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Admin/Merchant/List
        [HttpGet]
        public JsonResult List(int page, int limit)
        {
            return Json(bll.GetPageList(page, limit), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Admin/Merchant/Show
        public ActionResult Show(int Id)
        {
            ViewBag.selectTrees = MerchantTypeBLL.GetSelectTrees();
            ViewBag.model = bll.GetModelById(Id);
            return View();
        }

        //
        // GET: //Admin/Merchant/Add
        [HttpPost]
        public ActionResult Save(MerchantModel model)
        {
            return Json(bll.Save(model), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: //Admin/Merchant/Delete
        [HttpPost]
        public ActionResult DeleteById(long[] Ids)
        {
            return Json(bll.DeleteById(Ids), JsonRequestBehavior.AllowGet);
        }

        // GET: /Admin/Merchant/IsEnable
        [HttpPost]
        public ActionResult IsEnable(long[] Ids)
        {
            return Json(bll.SetStatus(Ids,1), JsonRequestBehavior.AllowGet);
        }


        // GET: /Admin/Merchant/UnEnable
        [HttpPost]
        public ActionResult UnEnable(long[] Ids)
        {
            return Json(bll.SetStatus(Ids, 0), JsonRequestBehavior.AllowGet);
        }

    }
}
