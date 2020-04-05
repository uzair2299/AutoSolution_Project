using AutoSolution.Database.DataBaseContext;
using AutoSolution.Services;
using AutoSolution.Services.CommonServices;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AutoSolution.Controllers
{
    public class RegistrationController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new AutoSolutionContext());
        // GET: Registration
        public ActionResult ServiceProvider()
        {
            ServiceProviderViewModel model = _unitOfWork.User.CreateServiceProvider();
            return View(model);
        }
        [HttpPost]
        public ActionResult ServiceProvider(ServiceProviderViewModel serviceProviderViewModel)
        {
            ServiceProviderViewModel model = _unitOfWork.User.CreateServiceProvider()
            if (ModelState.IsValid)
            {
                UserRepository userRepository = new UserRepository(new AutoSolutionContext());
                var serviceProvider = userRepository.CreateServiceProvider(serviceProviderViewModel);
                var cb = _unitOfWork.User.Add(serviceProvider);
                int i = _unitOfWork.Complete();
            }
            return View(model);
        }

        public ActionResult Consumer()
        {
            var model = _unitOfWork.User.CreateConsumer();
            return View(model);
        }

        [HttpPost]
        public ActionResult Consumer(ConsumerViewModel consumerViewModel)
        {
            var model = _unitOfWork.User.CreateConsumer();
            //CityRepository cityRepository = new CityRepository(new AutoSolutionContext());
            //ProvinceRepository provinceRepository = new ProvinceRepository(new AutoSolutionContext());
            //var cities = cityRepository.GetCities();
            //var provinces = provinceRepository.GetProvinces();
            //CityProvinceCategoryViewModel cityProvinceCategoryViewModel = new CityProvinceCategoryViewModel();
            //cityProvinceCategoryViewModel.CitiesList = cities;
            //cityProvinceCategoryViewModel.ProvincesList = provinces;
            if (ModelState.IsValid)
            {
                UserRepository userRepository = new UserRepository( new AutoSolutionContext());
                var consumer = userRepository.CreateConsumer(consumerViewModel);
                var cb = _unitOfWork.User.Add(consumer);
               int i = _unitOfWork.Complete();
            }
                return View(model);
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