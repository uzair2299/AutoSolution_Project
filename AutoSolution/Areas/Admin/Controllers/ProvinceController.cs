using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoSolution.Areas.Admin.Controllers
{
    public class ProvinceController : Controller
    {
        // GET: Admin/Province
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult addNew()
        {
            return View();
        }
    }
}