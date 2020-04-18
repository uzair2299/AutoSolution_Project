using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoSolution.Areas.Admin.Controllers
{
    public class VehicleModelController : Controller
    {
        // GET: Admin/VehicleModel
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddNew()
        {
            return PartialView("_AddNew");
        }
    }
}