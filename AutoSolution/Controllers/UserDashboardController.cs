using AutoSolution.Database.DataBaseContext;
using AutoSolution.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoSolution.Controllers
{
    public class UserDashboardController : Controller
    {
        // GET: UserDashboard
        private UnitOfWork _unitOfWork = new UnitOfWork(new AutoSolutionContext());
        public ActionResult Index(int id)
        {
            var model = _unitOfWork.User.GetUser(id);
            return View(model);
        }

        public ActionResult ChangePassword()
        {
            return PartialView("_ChangePassword");
        }
    }
}