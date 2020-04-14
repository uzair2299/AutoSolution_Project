using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services;
using AutoSolution.Services.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoSolution.Areas.Admin.Controllers
{
    public class ProvinceController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new AutoSolutionContext());

        // GET: Admin/Province
        public ActionResult Index()
        {
            var model = _unitOfWork.Province.GetAll();
            return View(model);
        }

        public ActionResult dropProvince()
        {
            var model = _unitOfWork.Province.GetAll();
            ViewBag.Prolist = new SelectList(model, "ProvinceId", "ProvinceName");
            return View();
        }

        public JsonResult getCity(int provinceId)
        {
            
            var CitiesList = _unitOfWork.City.GetCityWithRespectToProvince(provinceId);
            return Json(CitiesList, JsonRequestBehavior.AllowGet);

        }

        
        

       


    }
}