using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoSolution.Controllers
{
    public class PlaceOrderController : Controller
    {
        // GET: PlaceOrder
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                return View("Shipment");
            }
            else
            {
                return View("Check");
            }
            
        }

        [HttpPost]
        public ActionResult shipment()
        {
            return View();
        }

    }
}