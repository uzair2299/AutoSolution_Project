using AutoSolution.Database.DataBaseContext;
using AutoSolution.Services;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoSolution.Controllers
{
    public class GetServiceProviderController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new AutoSolutionContext());
        // GET: GetServiceProvider
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetServiceProviders(string id, int? pageNo)
        {
            int PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            int TotalCount = _unitOfWork.User.GetServiceProviderCountWRTId(id);
            ServiceProviderWraperForHome model = _unitOfWork.User.GetServiceProviders(PageNo, TotalCount, id);
           
            return PartialView("_GetServiceProviders", model);
        }
        [HttpGet]
        public ActionResult GetServiceProviderSearch(SelectYourInterest selectYourInterest, int? pageNo, ServiceProviderWraperForHome serviceProviderWraper)
        {
            ModelState.Clear();
            int PageNo, TotalCount;
            if (Request.IsAjaxRequest())
            {
                SelectYourInterest selectYourInterestr = new SelectYourInterest()
                {
                    findYourMechanic = new FindYourMechanicViewModel()
                    {
                        CityAreaID= serviceProviderWraper.FindYourMechanicViewModel.CityAreaID,
                        SelectedCity = serviceProviderWraper.FindYourMechanicViewModel.SelectedCity,
                        SelectedProvince= serviceProviderWraper.FindYourMechanicViewModel.SelectedProvince,
                        SelectedServiceCategory = serviceProviderWraper.FindYourMechanicViewModel.SelectedServiceCategory
                    }
                };

                 PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
                 TotalCount = _unitOfWork.User.GetServiceProviderCountWRTHomeSearch(selectYourInterestr);
                ServiceProviderWraperForHome model = _unitOfWork.User.GetServiceProvidersHomeSearch(PageNo, TotalCount, selectYourInterestr);
                
                return PartialView("_GetServiceProviders", model);
            }
            else
            {
                 PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
                 TotalCount = _unitOfWork.User.GetServiceProviderCountWRTHomeSearch(selectYourInterest);
                ServiceProviderWraperForHome model = _unitOfWork.User.GetServiceProvidersHomeSearch(PageNo, TotalCount, selectYourInterest);
                return View("GetServiceProviderSearch", model);

            }
        }
    }
}



















































































