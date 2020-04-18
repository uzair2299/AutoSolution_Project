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
    public class SignInController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new AutoSolutionContext());
        // GET: SignIn
        public ActionResult index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult index(SignInViewModel signInViewModel)
        {
            string message = "";
            try
            {
                if (signInViewModel != null)
                {
                    var PasswordHash = EncryptPassword.PasswordToEncrypt(signInViewModel.Password);
                    var model = _unitOfWork.User.Get(x => x.Email == signInViewModel.Email && x.Password == PasswordHash).FirstOrDefault();
                    if (model != null)
                    {
                        if (model.IsConfrimEmail != true)
                        {
                            message = "Please verify your email first";
                            return View();
                        }
                        else
                        {
                            int timeout = signInViewModel.RememberMe ? 525600 : 20;
                            //cookies
                            return RedirectToAction("Index", "Home");
                        }

                    }
                    else
                    {
                        message = "Please enter a valid email address or password";
                    }
                    ViewBag.Message = message;

                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }

        //public ActionResult _UserSignIn()
        //{
        //    var model = _unitOfWork.User.GetSignInViewModel();
        //    return PartialView(model);
        //}


        //[HttpPost]
        //public ActionResult UserSignIn(SignInViewModel signInViewModel)
        //{
        //    string message = "";
        //    if (signInViewModel != null)
        //    {
        //        var PasswordHash = EncryptPassword.PasswordToEncrypt(signInViewModel.Password);
        //        var model = _unitOfWork.User.Get(x => x.Email == signInViewModel.Email && x.Password == PasswordHash).FirstOrDefault();
        //        if (model != null)
        //        {
        //            if (model.IsConfrimEmail != true)
        //            {
        //                message = "Please verify your email first";
        //                return View();
        //            }
        //            else
        //            {
        //                int timeout = signInViewModel.RememberMe ? 525600 : 20;
        //                //cookies
        //                return RedirectToAction("Index", "Home");
        //            }

        //        }
        //        else
        //        {
        //            message = "Please enter a valid email address or password";
        //        }
        //        ViewBag.Message = message;
            
        //    }//need some modifications
        //    return RedirectToAction("Index", "Home");
        //}

       
    }
}