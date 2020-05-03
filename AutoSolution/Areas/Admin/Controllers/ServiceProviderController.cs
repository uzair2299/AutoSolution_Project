using AutoSolution.Database.DataBaseContext;
using AutoSolution.Services;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoSolution.Areas.Admin.Controllers
{
    public class ServiceProviderController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new AutoSolutionContext());
        // GET: Admin/ServiceProvider
        public ActionResult Index()
        
        {
            //ServiceProviderViewModel serviceProviderViewModel = new ServiceProviderViewModel();
            //UserRepository userRepository = new UserRepository(new AutoSolutionContext());
           // serviceProviderViewModel = userRepository.GetServiceProviders();
            
            return View();
        }

        public ActionResult GetServiceProvider(string search, int? pageNo)
        {
            try
            {
                if (string.IsNullOrEmpty(search))
                {
                    int PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
                    int TotalCount = _unitOfWork.User.GetServiceProvidersCount();
                    AdminSide model = _unitOfWork.User.GetServiceProviders(PageNo, TotalCount);
                    return PartialView("_GetServiceProvider", model);
                }
                //else
                //{
                //    int PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
                //    int TotalCount = _unitOfWork.PartsProductsCategory.GetPartsProductsCategoryCount(search);
                //    var model = _unitOfWork.PartsProductsCategory.GetPartsProductsCategory(PageNo, TotalCount, search);
                //    return PartialView("_GetPartsProductsCategory", model);
                //}
            }
            catch (Exception)
            {

                throw;
            }




            return PartialView("_GetServiceProvider");
        }
    }
}