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
      
        public ActionResult SelectYourInterest()
        {
            FindYourMechanic findYourMechanic = new FindYourMechanic()
            {
                ProvinceList = _unitOfWork.Province.GetProvincesForHome(),
                CityList = _unitOfWork.City.GetCitiesForHome(),
                ServiceCategoryList = _unitOfWork.ServiceCategory.GetServiceCategoryDropDown()
            };
            return PartialView("_SelectYourInterest",findYourMechanic);
        }

        public ActionResult check()
        {
            return View();
        }

        public JsonResult GetCityArea(string Prefix,string SelectedCityId)
        { int CityID = Convert.ToInt32(SelectedCityId);
            AutoSolutionContext autoSolutionContext = new AutoSolutionContext();
            var ServiceCategory = (from ca in autoSolutionContext.CityAreas
                                   where ca.CityAreaName.StartsWith(Prefix) && ca.CityId==CityID
                                   select new
                                   {
                                       id=ca.CityAreaID,
                                       label = ca.CityAreaName,
                                       //val = ca.CityAreaName
                                   }).ToList();
            return Json(ServiceCategory, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetCities(string ProvinceId)
        {
            if (!string.IsNullOrWhiteSpace(ProvinceId))
            {
                IEnumerable<SelectListItem> cities = _unitOfWork.City.GetCitiesForHome(ProvinceId);
                return Json(cities, JsonRequestBehavior.AllowGet);
            }
            return null;
        }
        //public JsonResult GetServiceCategory(string Prefix)
        //{
        //    AutoSolutionContext autoSolutionContext = new AutoSolutionContext();
        //    var ServiceCategory = (from sc in autoSolutionContext.ServiceCategories
        //                           where sc.ServiceCategoryName.StartsWith(Prefix)
        //                           select new
        //                           {
        //                               label = sc.ServiceCategoryName,
        //                               val = sc.ServiceCategoryId
        //                           }).ToList();
        //    return Json(ServiceCategory, JsonRequestBehavior.AllowGet);
        //}
    }
}
