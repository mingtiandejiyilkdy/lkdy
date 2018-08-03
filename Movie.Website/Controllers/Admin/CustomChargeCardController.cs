using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;   
using Movie.Model.Ticket;
using Movie.BLL.Ticket;
using Movie.Model.ChargeCard;
using Movie.BLL.Contract;
using Movie.BLL.Financial;
using Movie.Model.Contract;
using Movie.ViewModel.Contract;

namespace Movie.Website.Controllers.Admin
{

    public class CustomChargeCardController : BaseController
    {
        protected readonly CustomChargeCardBLL bll = new CustomChargeCardBLL();
        protected readonly CustomFinancialBLL customFinancialBLL = new CustomFinancialBLL();
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
            ContractViewModel contractViewModel = contractBLL.GetViewModelById(contractId);
            ViewBag.selectTrees = ticketTypeBLL.GetSelectTrees();
            ViewBag.ticketBatchs = ticketBatchBLL.GetAllList().data;
            ViewBag.contractViewModel = contractViewModel;
            return View();
        }

        //
        // GET: //Admin/Cinema/Add
        [HttpPost]
        public ActionResult Save(CustomChargeCardsModel model)
        {
            return Json(bll.Save(model), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: //Admin/Cinema/Add
        [HttpPost]
        public ActionResult GetBlance(long customId,int moneyType)
        {
            return Json(customFinancialBLL.GetList(customId, moneyType), JsonRequestBehavior.AllowGet);
        }
    }
}
