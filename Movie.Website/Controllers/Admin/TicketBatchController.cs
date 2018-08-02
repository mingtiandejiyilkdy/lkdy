using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;   
using Movie.Model.Ticket;
using Movie.BLL.Ticket;

namespace Movie.Website.Controllers.Admin
{

    public class TicketBatchController : BaseController
    {
        protected readonly TicketBatchBLL bll = new TicketBatchBLL();
        protected readonly TicketTypeBLL ticketTypeBLL = new TicketTypeBLL();
        //
        // GET: /Admin/TicketBatch/
        public ActionResult Index()
        {
            return View();
        }


        //
        // GET: /Admin/TicketBatch/AllList
        [HttpGet]
        public JsonResult AllList()
        {
            return Json(bll.GetAllList(), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Admin/TicketBatch/List
        [HttpGet]
        public JsonResult List(int page, int limit)
        {
            return Json(bll.GetPageList(page, limit), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Admin/TicketBatch/Show
        public ActionResult Show(int Id)
        {
            ViewBag.selectTrees = ticketTypeBLL.GetSelectTrees();
            ViewBag.model = bll.GetModelById(Id);
            return View();
        }

        //
        // GET: //Admin/TicketBatch/Add
        [HttpPost]
        public ActionResult Save(TicketBatchModel model)
        {
            return Json(bll.Save(model), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: //Admin/TicketBatch/Delete
        [HttpPost]
        public ActionResult DeleteById(long[] Ids)
        {
            return Json(bll.DeleteById(Ids), JsonRequestBehavior.AllowGet);
        }

        // GET: /Admin/TicketBatch/IsEnable
        [HttpPost]
        public ActionResult IsEnable(long[] Ids)
        {
            return Json(bll.SetStatus(Ids,1), JsonRequestBehavior.AllowGet);
        }


        // GET: /Admin/TicketBatch/UnEnable
        [HttpPost]
        public ActionResult UnEnable(long[] Ids)
        {
            return Json(bll.SetStatus(Ids, 0), JsonRequestBehavior.AllowGet);
        }

    }
}
