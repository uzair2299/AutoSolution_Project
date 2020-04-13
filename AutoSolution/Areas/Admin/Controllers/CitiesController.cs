using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services;
using AutoSolution.Services.IUnitOfWork;
using AutoSolution.Services.Repo;
using AutoSolution.Services.ViewModel;
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
        [HttpGet]
        public ActionResult Index()
        {
            var Provinces = _unitOfWork.Province.GetProvinces();
            CityProvinceViewModel cityProvinceViewModel = new CityProvinceViewModel();
            cityProvinceViewModel.ProvincesList = Provinces;
            return View(cityProvinceViewModel);
        }

        public ActionResult CitiesTable(CityProvinceViewModel cityProvinceViewModel, int? pageNo)
        {
            try
            {
                int PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
                if (cityProvinceViewModel.SelectedProvince == null)
                {
                    AutoSolutionContext autoSolution = new AutoSolutionContext();

                    var model = autoSolution.Cities.OrderBy(x => x.CityName).Skip((PageNo - 1) * 10).Take(10).ToList();
                    //var model = _unitOfWork.City.GetAll();
                    int TotalCount = _unitOfWork.City.Count();
                    CityProvinceViewModel cityProvinceView = new CityProvinceViewModel();
                    cityProvinceView.CitiesList = model;
                    cityProvinceView.Pager = new Pager(TotalCount, pageNo, 10);
                    return PartialView("_CitiesTable", cityProvinceView);

                }
                else
                {
                    int ProID = Convert.ToInt32(cityProvinceViewModel.SelectedProvince);
                    CityRepository cityRepository = new CityRepository(new AutoSolutionContext());
                    var cities = _unitOfWork.City.Get(x => x.ProvinceId == ProID);
                    CityProvinceViewModel cityProvinceViewModel1 = new CityProvinceViewModel();
                    cityProvinceViewModel1.CitiesList = cities.ToList();
                    return PartialView("_CitiesTable", cityProvinceViewModel1);
                }

            }
            catch (Exception)
            {

                return View("Error");
            }
            
        }
    }
}