using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;   
using Movie.Model.Ticket;
using Movie.BLL.Ticket;
using Movie.Model.ChargeCard;
using Movie.BLL.Contract;

namespace Movie.Website.Controllers.Admin
{

    public class CustomChargeCardController : BaseController
    {
        protected readonly CustomChargeCardBLL bll = new CustomChargeCardBLL();
        protected readonly TicketTypeBLL ticketTypeBLL = new TicketTypeBLL();
        protected readonly ContractBLL contractBLL = new ContractBLL();
        protected readonly TicketBatchBLL ticketBatchBLL = new TicketBatchBLL();

        // GET: /Admin/CustomChargeCard/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Admin/CustomChargeCard/List
        [HttpGet]
        public JsonResult GetPageList()
        {
            return Json(bll.GetPageList(0,0,false), JsonRequestBehavior.AllowGet);
        }
         
        //
        // GET: /Admin/CustomChargeCard/AddFromContract
        public ActionResult AddFromContract(int contractId)
        {
            ViewBag.contractId = contractId;
            ViewBag.selectTrees = ticketTypeBLL.GetSelectTrees();
            ViewBag.ticketBatchs = ticketBatchBLL.GetAllList().data;
            ViewBag.contractViewModel = contractBLL.GetViewModelById(contractId);
            return View();
        }
         
        //
        // GET: //Admin/Cinema/Add
        [HttpPost]
        public ActionResult Save(CustomChargeCardsModel model)
        {
            return Json(bll.Save(model), JsonRequestBehavior.AllowGet);
        }
    }
}
