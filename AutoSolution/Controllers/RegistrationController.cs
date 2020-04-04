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
            AutoSolutionContext autoSolutionContext = new AutoSolutionContext();
            var ServiceCategories = autoSolutionContext.ServiceCategories.ToList();
            List<ServiceCategoryUtility> ServiceCategoryUtilities = new List<ServiceCategoryUtility>();
            foreach (var item in ServiceCategories)
            {
                ServiceCategoryUtility serviceCategoryUtility = new ServiceCategoryUtility();
                serviceCategoryUtility.ServiceCategoryUtilityId = item.ServiceCategoryId;
                serviceCategoryUtility.ServiceCategoryUtilityName = item.ServiceCategoryName;
                serviceCategoryUtility.IsChecked = false;
                ServiceCategoryUtilities.Add(serviceCategoryUtility);
            }

            model.ServiceCategoriesList = ServiceCategoryUtilities;


            return View(model);
        }
        [HttpPost]
        public ActionResult ServiceProvider(ServiceProviderViewModel serviceProviderViewModel)
        {
            var model = _unitOfWork.User.CreateServiceProvider();
            return View();
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


        public ActionResult chkboc()
        {
            AutoSolutionContext autoSolutionContext = new AutoSolutionContext();
            var service = autoSolutionContext.ServiceCategories.ToList();
            ChkMV chkMV = new ChkMV();
            List<ServiceCategoryUtility> scu = new List<ServiceCategoryUtility>();
            foreach (var item in service)
            {
                ServiceCategoryUtility serviceCategoryUtility = new ServiceCategoryUtility();
                serviceCategoryUtility.ServiceCategoryUtilityId = item.ServiceCategoryId;
                serviceCategoryUtility.ServiceCategoryUtilityName = item.ServiceCategoryName;
                serviceCategoryUtility.IsChecked = false;
                scu.Add(serviceCategoryUtility);
            }

            chkMV.ServiceCategoriesList = scu;
            return View(chkMV);
        }

        [HttpPost]
        public ActionResult chkboc(ChkMV chkMV)
        {
            var selectedFeatureIds = new List<int>();
            foreach (var option in chkMV.ServiceCategoriesList)
            {
                if (option.IsChecked)
                {
                    selectedFeatureIds.Add(option.ServiceCategoryUtilityId);
                }
            }
            return View();
        }
    }
}