using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WareHouseSoftw.DAL.Context;

namespace WareHouseSoftw.UI.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
       public ProjectContext db;
        public BaseController()
        {
            db = new ProjectContext();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}