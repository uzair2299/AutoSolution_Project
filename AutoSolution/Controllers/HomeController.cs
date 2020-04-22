using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoSolution.Controllers
{
    
    public class HomeController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new AutoSolutionContext());

        public ActionResult Index()
        {
            //HomeViewModel homeViewModel = new HomeViewModel();
            
            return View();
        }

        public ActionResult GetServiceCategories()
        {
            var model = _unitOfWork.ServiceCategory.GetAll();
            return PartialView("_GetServiceCategories",model);
        }
      
        

        public ActionResult check()
        {
            return View();
        }
    }
}