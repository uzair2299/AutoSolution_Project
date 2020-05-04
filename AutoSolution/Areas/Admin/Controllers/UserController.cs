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
    public class UserController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new AutoSolutionContext());
        // GET: Admin/User
        public ActionResult Index()
        {
            ViewBag.count = _unitOfWork.User.GetUsersCount();
            return View();
        }

        public ActionResult GetUser(string search, int? pageNo)
        {
            try
            {
                if (string.IsNullOrEmpty(search))
                {
                    int PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
                    int TotalCount = _unitOfWork.User.GetUsersCount();
                    ConsumerWraper model = _unitOfWork.User.GetUsers(PageNo, TotalCount);
                    return PartialView("_GetUser", model);
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




            return PartialView("_GetUser");
        }

    }
}