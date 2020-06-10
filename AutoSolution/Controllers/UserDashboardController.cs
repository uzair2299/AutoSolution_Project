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
    public class UserDashboardController : Controller
    {
        // GET: UserDashboard
        private UnitOfWork _unitOfWork = new UnitOfWork(new AutoSolutionContext());
        public ActionResult Index(int id)
        {
            var model = _unitOfWork.User.GetUser(id);
            return View(model);
        }

        public ActionResult ChangePassword()
        {
            ChangePasswordViewModel changePasswordViewModel = new ChangePasswordViewModel(); 
            return PartialView("_ChangePassword",changePasswordViewModel);
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel changePasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                if (Session["UserId"] != null)
                {
                    bool result = false;
                    int id = Convert.ToInt32(Session["UserId"]);
                    var user = _unitOfWork.User.GetByID(id);
                    var PasswordHash = EncryptPassword.PasswordToEncrypt(changePasswordViewModel.CurrentPassword);
                    if (user.Password == PasswordHash)
                    {
                        user.Password = EncryptPassword.PasswordToEncrypt(changePasswordViewModel.NewPassword);
                        _unitOfWork.User.Update(user);
                        _unitOfWork.Complete();
                        _unitOfWork.Dispose();
                        result = true;
                        return Json(new { result }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { result }, JsonRequestBehavior.AllowGet);
                    }
                }
                return PartialView("_ChangePassword", changePasswordViewModel);
            }
         else
            return PartialView("_ChangePassword", changePasswordViewModel);
        }

        public ActionResult GetWishList(int id)
        {
            List<PartsProductsViewModel> partsProductsViewModel = _unitOfWork.PartsProducts.GetWishlist(id);
            return PartialView("_GetWishList",partsProductsViewModel);
        }


    }
}