using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoSolution.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new AutoSolutionContext());
        // GET: Admin/Categories
        public ActionResult Index()
        {
            var model = _unitOfWork.ServiceCategory.GetAll();
            return View(model);
        }

        public ActionResult AddNewPartialView()
        {
            return PartialView("_AddNewPartialView",new ServiceCategory());
        }
        //[HttpPost]
        public ActionResult AddServiceCategory(ServiceCategory serviceCategory)
        {
            return View();
        }

        public JsonResult DeleteCategory(int Id)
        {

            _unitOfWork.ServiceCategory.Remove(Id);
            bool result = false;
            

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}