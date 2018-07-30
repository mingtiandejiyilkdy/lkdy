using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;  
using Movie.BLL.Cinema;
using Movie.Model.Cinema;

namespace Movie.Website.Controllers.Admin
{

    public class CinemaController : BaseController
    {
        protected readonly CinemaBLL bll = new CinemaBLL();
        //
        // GET: /Admin/Cinema/
        public ActionResult Index()
        {
            return View();
        }


        //
        // GET: /Admin/Cinema/AllList
        [HttpGet]
        public JsonResult AllList()
        {
            return Json(bll.GetAllList(), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Admin/Cinema/List
        [HttpGet]
        public JsonResult List(int page, int limit)
        {
            return Json(bll.GetPageList(page, limit), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Admin/Cinema/Show
        public ActionResult Show(int Id)
        {
            ViewBag.model = bll.GetModelById(Id);
            return View();
        }

        //
        // GET: //Admin/Cinema/Add
        [HttpPost]
        public ActionResult Save(CinemaModel model)
        {
            return Json(bll.Save(model), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: //Admin/Cinema/Delete
        [HttpPost]
        public ActionResult DeleteById(long[] Ids)
        {
            return Json(bll.DeleteById(Ids), JsonRequestBehavior.AllowGet);
        }

        // GET: /Admin/Cinema/IsEnable
        [HttpPost]
        public ActionResult IsEnable(long[] Ids)
        {
            return Json(bll.SetStatus(Ids,1), JsonRequestBehavior.AllowGet);
        }


        // GET: /Admin/Cinema/UnEnable
        [HttpPost]
        public ActionResult UnEnable(long[] Ids)
        {
            return Json(bll.SetStatus(Ids, 0), JsonRequestBehavior.AllowGet);
        }

    }
}
