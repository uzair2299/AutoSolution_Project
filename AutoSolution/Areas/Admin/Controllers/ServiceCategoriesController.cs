using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AutoSolution.Areas.Admin.Controllers
{
    public class ServiceCategoriesController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new AutoSolutionContext());
        // GET: Admin/Categories
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddNew()
        {
            return PartialView("_AddNew");
        }

        [HttpPost]
        public ActionResult AddNew(ServiceCategoryViewModel serviceCategoryViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ServiceCategoryRepository ServiceCategoryRepository = new ServiceCategoryRepository(new AutoSolutionContext());
                    bool IsExist = ServiceCategoryRepository.isExist(serviceCategoryViewModel.ServiceCategoryName);
                    if (!IsExist)
                    {
                        ServiceCategory serviceCategory = new ServiceCategory();
                        serviceCategory.ServiceCategoryName = serviceCategoryViewModel.ServiceCategoryName;
                        serviceCategory.ServiceCategoryCode = serviceCategoryViewModel.ServiceCategoryCode;
                        serviceCategory.Description = serviceCategoryViewModel.Description;
                        



                        _unitOfWork.ServiceCategory.Add(serviceCategory);
                        _unitOfWork.Complete();
                        _unitOfWork.Dispose();
                        return RedirectToAction("GetServiceCategory");

                    }
                    else
                    {
                        return RedirectToAction("GetServiceCategory");

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }

        public ActionResult GetServiceCategory(string search,int? pageNo)
        {
            try
            {
                if (string.IsNullOrEmpty(search))
                {
                    int PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
                    int TotalCount = _unitOfWork.ServiceCategory.Count();
                    var model = _unitOfWork.ServiceCategory.GetServiceCategory(PageNo, TotalCount);
                    return PartialView("_GetServiceCategory", model);

                }
                else
                {
                    int PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
                    int TotalCount = _unitOfWork.ServiceCategory.GetServiceCategoryCount(search);
                    var model = _unitOfWork.ServiceCategory.GetServiceCategory(PageNo, TotalCount, search);
                    return PartialView("_GetServiceCategory", model);

                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        public ActionResult Edit(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var item = _unitOfWork.ServiceCategory.GetByID(Convert.ToInt32(id));
                ServiceCategoryViewModel serviceCategoryViewModel = new ServiceCategoryViewModel();
                serviceCategoryViewModel.ServiceCategoryId = item.ServiceCategoryId;
                serviceCategoryViewModel.ServiceCategoryName = item.ServiceCategoryName;
                serviceCategoryViewModel.ServiceCategoryCode = item.ServiceCategoryCode;
                serviceCategoryViewModel.Description = item.Description;
                if (serviceCategoryViewModel != null)
                {
                    return PartialView("_EditServiceCategory", serviceCategoryViewModel);
                }
                else
                    return HttpNotFound();
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPost]
        public ActionResult Edit(ServiceCategoryViewModel serviceCategoryViewModel)
        {
            try
            {

                if (serviceCategoryViewModel == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                ServiceCategory serviceCategory = new ServiceCategory();
                serviceCategory.ServiceCategoryId = serviceCategoryViewModel.ServiceCategoryId;
                serviceCategory.ServiceCategoryName = serviceCategoryViewModel.ServiceCategoryName;
                serviceCategory.ServiceCategoryCode = serviceCategoryViewModel.ServiceCategoryCode;
                serviceCategory.Description = serviceCategoryViewModel.Description;
                _unitOfWork.ServiceCategory.Update(serviceCategory);
                _unitOfWork.Complete();
                _unitOfWork.Dispose();

            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("GetServiceCategory");
        }


        public ActionResult Details(string id)
        {

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var item = _unitOfWork.ServiceCategory.GetByID(Convert.ToInt32(id));
                ServiceCategoryViewModel serviceCategoryViewModel = new ServiceCategoryViewModel();
                serviceCategoryViewModel.ServiceCategoryId = item.ServiceCategoryId;
                serviceCategoryViewModel.ServiceCategoryName = item.ServiceCategoryName;
                serviceCategoryViewModel.Description = item.Description;


                if (serviceCategoryViewModel != null)
                {
                    return PartialView("_DetailsServiceCategory", serviceCategoryViewModel);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            catch (Exception)
            {

                throw;
            }


        }


    }
}