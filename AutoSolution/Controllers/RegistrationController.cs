using AutoSolution.Database.DataBaseContext;
using AutoSolution.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoSolution.Controllers
{
    public class RegistrationController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new AutoSolutionContext());
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult create()
        {
            var model = _unitOfWork.User.CreateCustomer();
            return View();
        }
    }
}