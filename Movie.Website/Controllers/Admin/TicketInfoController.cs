using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;   
using Movie.Model.Ticket;
using Movie.BLL.Ticket;

namespace Movie.Website.Controllers.Admin
{

    public class TicketInfoController : BaseController
    {
        protected readonly TicketBLL bll = new TicketBLL();
        //
        // GET: /Admin/TicketInfo/
        public ActionResult Index()
        {
            return View();
        }


        //
        // GET: /Admin/TicketInfo/AllList
        [HttpGet]
        public JsonResult AllList()
        {
            return Json(bll.GetAllList(), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Admin/TicketInfo/List
        [HttpGet]
        public JsonResult List(int page, int limit)
        {
            return Json(bll.GetPageList(page, limit), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Admin/TicketInfo/Show
        public ActionResult Show(int Id)
        {
            ViewBag.selectTrees = new TicketTypeBLL().GetSelectTrees();
            ViewBag.model = bll.GetModelById(Id);
            return View();
        }

        //
        // GET: //Admin/TicketInfo/Add
        [HttpPost]
        public ActionResult Save(TicketInfo model)
        {
            return Json(bll.Save(model), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: //Admin/TicketInfo/Delete
        [HttpPost]
        public ActionResult DeleteById(long[] Ids)
        {
            return Json(bll.DeleteById(Ids), JsonRequestBehavior.AllowGet);
        }

        // GET: /Admin/TicketInfo/IsEnable
        [HttpPost]
        public ActionResult IsEnable(long[] Ids)
        {
            return Json(bll.SetStatus(Ids,1), JsonRequestBehavior.AllowGet);
        }


        // GET: /Admin/TicketInfo/UnEnable
        [HttpPost]
        public ActionResult UnEnable(long[] Ids)
        {
            return Json(bll.SetStatus(Ids, 0), JsonRequestBehavior.AllowGet);
        }

    }
}
