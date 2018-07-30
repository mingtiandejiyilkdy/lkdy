using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movie.BLL;
using Movie.Website.Controllers.Admin;

namespace Movie.Website.Controllers
{
    public class HomeController : BaseController
    { 
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        } 
    }
}
