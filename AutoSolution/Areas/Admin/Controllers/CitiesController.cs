using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services;
using AutoSolution.Services.IUnitOfWork;
using AutoSolution.Services.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoSolution.Areas.Admin.Controllers
{
    public class CitiesController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new AutoSolutionContext());

        // GET: Admin/Cities
        public ActionResult Index()
        {
            var model = _unitOfWork.City.GetAll();
               return View(model);
            
        }

        public ActionResult ViewCities()
        {
            
            return View();
        }
    }
}