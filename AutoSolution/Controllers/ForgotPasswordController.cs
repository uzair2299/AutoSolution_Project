using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services;
using AutoSolution.Services.CommonServices;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoSolution.Controllers
{
    public class ForgotPasswordController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new AutoSolutionContext());
        // GET: ForgotPassword
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(ForgotPassword forgotPassword)
        {
            var IsExist = IsEmailExist(forgotPassword.EmailId);
            if (!IsExist)
            {
                ModelState.AddModelError("EmailNotExists", "This email is not exists");
                return View();
            }
            else
            {
                User user = _unitOfWork.User.Get(x => x.Email == forgotPassword.EmailId).FirstOrDefault();
                
                string OTP_Password = EncryptPassword.OPTPassword();
                user.ActivetionCode = Guid.NewGuid();
                user.OTP = OTP_Password;

                UserRepository userRepository = new UserRepository(new AutoSolutionContext());
                var email = user.Email;
                var activationCode = user.ActivetionCode;
                var VerificationLink = "/ForgotPassword/ChangePassword/" + activationCode;
                var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, VerificationLink);
                UserEmailUtility.ForgetPasswordEmailToUser(email, link, OTP_Password);
                return View();
            }
        }

        public ActionResult ChangePassword(string id)
        {
            var isExist = _unitOfWork.User.Get(u => u.ActivetionCode == new Guid(id)).FirstOrDefault();
            if (isExist != null)
            {
                if(isExist.IsActive && isExist.IsConfrimEmail)
                {
                    //
                }
            }
            else
            {
                //
            }
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePassword changePassword)
        {
            if(ModelState.IsValid)
            {

            }

            return View();
        }

        public bool IsEmailExist(string eMail)
        {
            var IsCheck = _unitOfWork.User.Get(email => email.Email == eMail).FirstOrDefault();
            return IsCheck != null;
        }

    }
}