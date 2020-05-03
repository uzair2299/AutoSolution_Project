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
            return View(model);
        }



        [HttpPost]
        public ActionResult ServiceProvider(ServiceProviderViewModel serviceProviderViewModel)
        {
            ServiceProviderViewModel model = _unitOfWork.User.CreateServiceProvider();
            if (ModelState.IsValid)
            {
                UserRepository userRepository = new UserRepository(new AutoSolutionContext());
                var serviceProvider = userRepository.CreateServiceProvider(serviceProviderViewModel);
                var AddedServiceProvider = _unitOfWork.User.Add(serviceProvider);
                int i = _unitOfWork.Complete();
                var activationCode = AddedServiceProvider.ActivetionCode;
                var VerificationLink = "/Registration/UserVerification/" + activationCode;
                var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, VerificationLink);
                UserEmailUtility.SendEmailToUser(AddedServiceProvider.Email, link);
                return RedirectToAction("ServiceProvider");
            }
            return View(model);
        }


        //[Authorize(Roles ="User")]
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Consumer()
        {
            var model = _unitOfWork.User.CreateConsumer();
            return View(model);
        }


        [AllowAnonymous]
        [HttpPost]
        //[Authorize(Roles = "User")]

        public ActionResult Consumer(ConsumerViewModel consumerViewModel)
        {
            var model = _unitOfWork.User.CreateConsumer();
            if (ModelState.IsValid)
            {
                UserRepository userRepository = new UserRepository(new AutoSolutionContext());
                var consumer = userRepository.CreateConsumer(consumerViewModel);
                var AddedComsumer = _unitOfWork.User.Add(consumer);
                int i = _unitOfWork.Complete();
                var activationCode = AddedComsumer.ActivetionCode;
                var VerificationLink = "/Registration/UserVerification/" + activationCode;
                var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, VerificationLink);
                UserEmailUtility.SendEmailToUser(AddedComsumer.Email, link);
                return RedirectToAction("Consumer");
            }
            else
            {
                return RedirectToAction("Consumer");
            }


        }



        public ActionResult UserVerification(string id)
        {
            var IsVerify = _unitOfWork.User.Get(u => u.ActivetionCode == new Guid(id)).FirstOrDefault();
            if (IsVerify != null)
            {
                IsVerify.IsConfrimEmail = true;

                IsVerify.IsActive = true;
                _unitOfWork.Complete();
                ViewBag.Message = "Email Verification completed";
                ViewBag.body = "Please Click Here To";
            }
            else
            {
                ViewBag.Message = "Invalid Request...Email not verify";
            }

            return View();
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



        [HttpPost]
        public JsonResult IsAlreadySigned(string Email)
        {

            try
            {
                return Json(!IsEmailExists(Email), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }



        public bool IsEmailExists(string eMail)
        {


            var IsCheck = _unitOfWork.User.Get(email => email.Email == eMail).FirstOrDefault();
            return IsCheck != null;
        }



    }

}


                                                                                                                                                                                                                                                                                    


