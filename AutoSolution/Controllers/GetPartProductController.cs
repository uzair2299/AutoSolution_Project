using AutoSolution.Database.DataBaseContext;
using AutoSolution.Services;
using System;
using System.Web.Mvc;

namespace AutoSolution.Controllers
{
    public class GetPartProductController : Controller
    {
        // GET: GetPartProduct
        private UnitOfWork _unitOfWork = new UnitOfWork(new AutoSolutionContext());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPartsProducts(string id, int? pageNo)
        {
            int Id = Convert.ToInt32(id);
            int PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            int TotalCount = _unitOfWork.PartsProducts.GetPartProductCountWRTCategory(id);
            var model = _unitOfWork.PartsProducts.GetPartsProducts(PageNo, TotalCount, Id);
            return PartialView("_GetPartsProducts", model);
        }


        public ActionResult PartProductDetail(String id="1")
        {
            var model = _unitOfWork.PartsProducts.PartProductDetail(id);
            return View(model);
        }
    }
}