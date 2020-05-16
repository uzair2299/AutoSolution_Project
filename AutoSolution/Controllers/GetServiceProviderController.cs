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

        public ActionResult GetServiceProviders(string id, int? pageNo)
        {
            int PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            int TotalCount = _unitOfWork.User.GetServiceProviderCountWRTId(id);
            ServiceProviderWraperForHome model = _unitOfWork.User.GetServiceProviders(PageNo, TotalCount, id);
            return PartialView("_GetServiceProviders", model);
        }
        
    }
}

                                                                                                                                                                                                                                                                                                                                                                                                                                                         













































































































































