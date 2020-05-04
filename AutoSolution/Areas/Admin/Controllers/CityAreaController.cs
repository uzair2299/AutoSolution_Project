using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AutoSolution.Areas.Admin.Controllers
{
   
    public class CityAreaController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new AutoSolutionContext());
        // GET: Admin/CityArea
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddNew()
        {
            var model = _unitOfWork.CityArea.AddNewCityArea();
            return PartialView("_AddNewCityArea", model);
        }

        [HttpPost]
        public ActionResult AddNew(CityAreaViewModel cityAreaViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    CityAreaRepository cityAreaRepository = new CityAreaRepository(new AutoSolutionContext());
                    bool IsExist = cityAreaRepository.isExist(cityAreaViewModel.CityAreaName, cityAreaViewModel.SelectedCity);
                    if (!IsExist)
                    {

                        CityArea cityArea = new CityArea();

                        cityArea.CityAreaName = cityAreaViewModel.CityAreaName;
                        cityArea.CityId = Convert.ToInt32(cityAreaViewModel.SelectedCity);
                        _unitOfWork.CityArea.Add(cityArea);
                        _unitOfWork.Complete();
                        _unitOfWork.Dispose();
                        return RedirectToAction("GetCityArea");

                    }
                    else
                    {
                        return RedirectToAction("GetCityArea");

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }


        public ActionResult GetCityArea(string search, string SelectedCity, int? pageNo)


        {
            try
            {
                if (string.IsNullOrEmpty(search) && string.IsNullOrEmpty(SelectedCity))
                {
                    int PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
                    int TotalCount = _unitOfWork.CityArea.Count();
                    var model = _unitOfWork.CityArea.GetCityArea(PageNo, TotalCount);
                    return PartialView("_GetCityArea", model);
                }
                else
                {
                    int PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
                    int TotalCount = _unitOfWork.CityArea.GetCityAreaCount(search, SelectedCity);
                    var model = _unitOfWork.CityArea.GetCityArea(PageNo, TotalCount, search, SelectedCity);
                    return PartialView("_GetCityArea", model);

                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        public ActionResult Details(string id)
        {

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }


                CityArea cityArea = _unitOfWork.CityArea.GetByID(Convert.ToInt32(id));
                CityAreaViewModel cityAreaViewModel = new CityAreaViewModel();

                cityAreaViewModel.CityAreaName = cityArea.CityAreaName;
                cityAreaViewModel.SelectedCity = cityArea.City.CityName;
                cityAreaViewModel.SelectedProvince = cityArea.City.Province.ProvinceName;

                if (cityAreaViewModel != null)
                {
                    return PartialView("_DetailsCityArea", cityAreaViewModel);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        [HttpGet]
        public ActionResult GetCities(string ProvinceId)
        {
            if (!string.IsNullOrWhiteSpace(ProvinceId))
            {
                IEnumerable<SelectListItem> cities = _unitOfWork.City.GetCities(ProvinceId);
                return Json(cities, JsonRequestBehavior.AllowGet);
            }
            return null;
        }
    }
}