using AutoSolution.Database.DataBaseContext;
using AutoSolution.Services;
using AutoSolution.Services.CommonServices;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var model = _unitOfWork.User.CreateServiceProvider();
            //var ii = _unitOfWork.ServiceCategory.GetAll();


            //foreach(var i in ii)
            //{
            //    ServiceCategoryUtility newobj = new ServiceCategoryUtility();
            //    newobj.serviceCategoryId = i.ServiceCategoryId;
            //    newobj.serviceCategoryName = i.ServiceCategoryName;
            //    model.SelectedServiceCategories.Add(newobj);
            //}
            return View(model);
        }
        [HttpPost]
        public ActionResult ServiceProvider(ServiceProviderViewModel serviceProviderViewModel)
        {


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


                //var consumer = _unitOfWork.User.CreateConsumer(consumerViewModel);
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