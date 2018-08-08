using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;   
using Movie.Model.Merchant;
using Movie.BLL.Merchant;

namespace Movie.Website.Controllers.Admin
{

    public class MerchantTypeController : BaseController
    {
        protected readonly MerchantTypeBLL bll = new MerchantTypeBLL();
        //
        // GET: /Admin/MerchantType/
        public ActionResult Index()
        {
            return View();
        }


        //
        // GET: /Admin/MerchantType/AllList
        [HttpGet]
        public JsonResult AllList()
        {
            return Json(bll.GetAllList(), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Admin/MerchantType/List
        [HttpGet]
        public JsonResult List(int page, int limit)
        {
            return Json(bll.GetPageList(page, limit), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Admin/MerchantType/Show
        public ActionResult Show(int Id)
        {
            ViewBag.model = bll.GetModelById(Id);
            return View();
        }

        //
        // GET: //Admin/MerchantType/Add
        [HttpPost]
        public ActionResult Save(MerchantTypeModel model)
        {
            return Json(bll.Save(model), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: //Admin/MerchantType/Delete
        [HttpPost]
        public ActionResult DeleteById(long[] Ids)
        {
            return Json(bll.DeleteById(Ids), JsonRequestBehavior.AllowGet);
        }

        // GET: /Admin/MerchantType/IsEnable
        [HttpPost]
        public ActionResult IsEnable(long[] Ids)
        {
            return Json(bll.SetStatus(Ids,1), JsonRequestBehavior.AllowGet);
        }


        // GET: /Admin/MerchantType/UnEnable
        [HttpPost]
        public ActionResult UnEnable(long[] Ids)
        {
            return Json(bll.SetStatus(Ids, 0), JsonRequestBehavior.AllowGet);
        }

    }
}
