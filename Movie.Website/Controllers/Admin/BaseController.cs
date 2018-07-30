using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movie.ViewModel;
using Movie.BLL;
using Movie.Website.App_Start.Filter;

namespace Movie.Website.Controllers.Admin
{
    [Authentication]
    public class BaseController : Controller
    {
        public LayoutViewModel layoutViewModel=new LayoutViewModel();

        //
        // GET: /Base/

        public BaseController()
        {
            layoutViewModel.menuList = new AdminRoleBLL().GetMenuListByAccountId(1, 1); 
            ViewBag.Title = "主页";
            ViewBag.TopMenuModel = layoutViewModel;
        }

    }
}
