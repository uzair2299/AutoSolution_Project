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
    public class PartsProductsCategoriesController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new AutoSolutionContext());
        // GET: Admin/PartsProductsCategories
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddNew()
        {
            return PartialView("_AddNew");
        }

        [HttpPost]
        public ActionResult AddNew(PartsProductsCategoryViewModel partsProductCategoryViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PartsProductsCategoryRepository partsProductsCategoryRepository = new PartsProductsCategoryRepository(new AutoSolutionContext());
                    bool IsExist = partsProductsCategoryRepository.isExist(partsProductCategoryViewModel.PartsProductsCategoryName);
                    if (!IsExist)
                    {
                        PartsProductsCategory partsProductsCategory = new PartsProductsCategory();
                        partsProductsCategory.PartsProductsCategoryName = partsProductCategoryViewModel.PartsProductsCategoryName;
                        _unitOfWork.PartsProductsCategory.Add(partsProductsCategory);
                        _unitOfWork.Complete();
                        _unitOfWork.Dispose();
                        return RedirectToAction("GetPartsProductsCategory");
                    }
                    else
                    {
                        return RedirectToAction("GetPartsProductsCategory");

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }


        public ActionResult GetPartsProductsCategory(string search, int? pageNo)
        {
            try
            {
                if (string.IsNullOrEmpty(search))
                {
                    int PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
                    int TotalCount = _unitOfWork.PartsProductsCategory.Count();
                    var model = _unitOfWork.PartsProductsCategory.GetPartsProductsCategory(PageNo, TotalCount);
                    return PartialView("_GetPartsProductsCategory", model);
                }
                else
                {
                    int PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
                    int TotalCount = _unitOfWork.PartsProductsCategory.GetPartsProductsCategoryCount(search);
                    var model = _unitOfWork.PartsProductsCategory.GetPartsProductsCategory(PageNo, TotalCount, search);
                    return PartialView("_GetPartsProductsCategory", model);
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

                var item = _unitOfWork.PartsProductsCategory.GetByID(Convert.ToInt32(id));
                PartsProductsCategoryViewModel partsProductsCategoryViewModel = new PartsProductsCategoryViewModel();
                partsProductsCategoryViewModel.PartsProductsCategoryId= item.PartsProductsCategoryId;
                partsProductsCategoryViewModel.PartsProductsCategoryName = item.PartsProductsCategoryName;
                
                if (partsProductsCategoryViewModel != null)
                {
                    return PartialView("_EditPartsProductsCategory", partsProductsCategoryViewModel);
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
        public ActionResult Edit(PartsProductsCategoryViewModel partsProductsCategoryViewModel)
        {
            try
            {

                if (partsProductsCategoryViewModel == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                PartsProductsCategory partsProductsCategory = new PartsProductsCategory();
                partsProductsCategory.PartsProductsCategoryId = partsProductsCategoryViewModel.PartsProductsCategoryId;
                partsProductsCategory.PartsProductsCategoryName = partsProductsCategoryViewModel.PartsProductsCategoryName;
                _unitOfWork.PartsProductsCategory.Update(partsProductsCategory);
                _unitOfWork.Complete();
                _unitOfWork.Dispose();

            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("GetPartsProductsCategory");
        }

        public ActionResult Details(string id)
        {

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var item = _unitOfWork.PartsProductsCategory.GetByID(Convert.ToInt32(id));
                PartsProductsCategoryViewModel partsProductsCategoryViewModel = new PartsProductsCategoryViewModel();
                partsProductsCategoryViewModel.PartsProductsCategoryName = item.PartsProductsCategoryName;
                
                

                if (partsProductsCategoryViewModel != null)
                {
                    return PartialView("_DetailsPartsProductsCategory", partsProductsCategoryViewModel);
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