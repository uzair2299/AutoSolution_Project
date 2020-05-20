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
    //[AllowAnonymous]
    public class HomeController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new AutoSolutionContext());

        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult GetServiceCategories()
        {
            var model = _unitOfWork.ServiceCategory.GetAll();
            return PartialView("_GetServiceCategories",model);
        }

        //public ActionResult GetServiceProvider(string id, int? pageNo)
        //{
        //    int PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
        //    var model = _unitOfWork.User.GetServiceProviders(PageNo, 50, id);
        //    return View();
        //}
        public ActionResult GetPartsProductForHome()
        {
           OuterMostPartsViewModel model = _unitOfWork.PartsProducts.GetPartsProductForHome();
            return PartialView("_GetPartsProduct",model);
        }
        public ActionResult GetPartsProductList(string id)
        {
           
            return View();
        }
        //[Authorize(Roles = "Admin")]
        public ActionResult SelectYourInterest()
        {
            SelectYourInterest selectYourInterest = new SelectYourInterest();
            selectYourInterest.findYourMechanic.ProvinceList = _unitOfWork.Province.GetProvincesForHome();
            selectYourInterest.findYourMechanic.CityList = _unitOfWork.City.GetCitiesForHome();
            selectYourInterest.findYourMechanic.ServiceCategoryList = _unitOfWork.ServiceCategory.GetServiceCategoryDropDown();
            selectYourInterest.FindYourPart.VehicleManufacturersList = _unitOfWork.VehicleModel.GetVehicleManufacturerDropDownForHome();
            selectYourInterest.FindYourPart.VehicleModelsList = _unitOfWork.VehicleModel.GetVehicleModelDropDownEmptyForHome();
            return PartialView("_SelectYourInterest", selectYourInterest);
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

        [HttpGet]
        public ActionResult GetModels(string selectedManufacturerId)
        {
            if (!string.IsNullOrWhiteSpace(selectedManufacturerId))
            {
                IEnumerable<SelectListItem> Moldels = _unitOfWork.VehicleModel.GetVehicleModelDropDownForHome(selectedManufacturerId);
                return Json(Moldels, JsonRequestBehavior.AllowGet);
            }
            return null;
        }


        //public ActionResult AutoSolutionCart()
        //{
        //    return PartialView("_AutoSolutionCart");
        //}
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



    



















