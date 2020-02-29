using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoSolution.Areas.Admin.Controllers
{
    public class CitiesController : Controller
    {
        // GET: Admin/Cities
        public ActionResult Index()
        {
            return View();
        }
    }
}