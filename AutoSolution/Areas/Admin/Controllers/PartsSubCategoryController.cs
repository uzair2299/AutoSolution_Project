using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services;
using AutoSolution.Services.ViewModel;
using System;
using System.Net;
using System.Web.Mvc;

namespace AutoSolution.Areas.Admin.Controllers
{
    public class PartsSubCategoryController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new AutoSolutionContext());
        // GET: Admin/PartsSubCategory
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddNew()
        {
            var model = _unitOfWork.PartsSubCategory.AddNewPartsSubCategory();
            return PartialView("_AddNewPartsSubCategory", model);
        }

        [HttpPost]
        public ActionResult AddNew(PartsSubCategoryViewModel partsSubCategoryViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string str = partsSubCategoryViewModel.PartsProductsSubCategoryName;
                    PartsSubCategoryRepository partsSubCategoryRepository = new PartsSubCategoryRepository(new AutoSolutionContext());
                    bool IsExist = partsSubCategoryRepository.isExist(partsSubCategoryViewModel.PartsProductsSubCategoryName);
                    if (!IsExist)
                    {
                        PartsProductsSubCategory partsProductsSubCategory = new PartsProductsSubCategory();
                        partsProductsSubCategory.PartsProductsSubCategoryName = partsSubCategoryViewModel.PartsProductsSubCategoryName;
                        partsProductsSubCategory.PartsProductsCategoryId = Convert.ToInt32(partsSubCategoryViewModel.SelectedPartsProductsCategory);
                        _unitOfWork.PartsSubCategory.Add(partsProductsSubCategory);
                        _unitOfWork.Complete();
                        _unitOfWork.Dispose();
                        return RedirectToAction("GetPartsProductSubCategory");

                    }
                    else
                    {
                        return RedirectToAction("GetPartsProductSubCategory");

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }

        public ActionResult GetPartsProductSubCategory(string search, string SelectedPartsProductsCategory, int? pageNo)


        {
            try
            {
                if (string.IsNullOrEmpty(search))
                {
                    int PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
                    int TotalCount = _unitOfWork.PartsSubCategory.Count();
                    var model = _unitOfWork.PartsSubCategory.GetPartsSubCategory(PageNo, TotalCount);
                    return PartialView("_GetPartsSubCategory", model);

                }
                else
                {
                    int PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
                    int TotalCount = _unitOfWork.PartsSubCategory.GetPartsSubCategoryCount(search, SelectedPartsProductsCategory);
                    var model = _unitOfWork.PartsSubCategory.GetPartsSubCategory(PageNo, TotalCount, search, SelectedPartsProductsCategory);
                    return PartialView("_GetPartsSubCategory", model);

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

                var item = _unitOfWork.PartsSubCategory.GetByID(Convert.ToInt32(id));
                PartsSubCategoryViewModel partsSubCategoryViewModel = new PartsSubCategoryViewModel();
                PartsSubCategoryRepository partsSubCategoryRepository = new PartsSubCategoryRepository(new AutoSolutionContext());
                partsSubCategoryViewModel.PartsProductsSubCategoryId = item.PartsProductsSubCategoryId;
                partsSubCategoryViewModel.PartsProductsSubCategoryName = item.PartsProductsSubCategoryName;
                partsSubCategoryViewModel.SelectedPartsProductsCategory = item.PartsProductsCategoryId.ToString();
                partsSubCategoryViewModel.PartsProductsCategoryList = partsSubCategoryRepository.GetPartsProductCategoryDropDown();

                if (partsSubCategoryViewModel != null)
                {
                    return PartialView("_EditPartsSubCategory", partsSubCategoryViewModel);
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
        public ActionResult Edit(PartsSubCategoryViewModel partsSubCategoryViewModel)
        {
            try
            {

                if (partsSubCategoryViewModel == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                PartsProductsSubCategory partsProductsSubCategory = new PartsProductsSubCategory();
                partsProductsSubCategory.PartsProductsSubCategoryId = partsSubCategoryViewModel.PartsProductsSubCategoryId;
                partsProductsSubCategory.PartsProductsSubCategoryName = partsSubCategoryViewModel.PartsProductsSubCategoryName;
                partsProductsSubCategory.PartsProductsCategoryId = Convert.ToInt32(partsSubCategoryViewModel.SelectedPartsProductsCategory);
                _unitOfWork.PartsSubCategory.Update(partsProductsSubCategory);
                _unitOfWork.Complete();
                _unitOfWork.Dispose();

            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("GetPartsProductSubCategory");
        }


        public ActionResult Details(string id)
        {

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                PartsProductsSubCategory partsProductsSubCategory = new PartsProductsSubCategory();
                PartsSubCategoryViewModel partsSubCategoryViewModel = new PartsSubCategoryViewModel();
                partsProductsSubCategory = _unitOfWork.PartsSubCategory.GetByID(Convert.ToInt32(id));
                partsSubCategoryViewModel.PartsProductsSubCategoryName = partsProductsSubCategory.PartsProductsSubCategoryName;
                partsSubCategoryViewModel.PartsProductsCategoryName = partsProductsSubCategory.PartsProductsCategory.PartsProductsCategoryName;


                

                if (partsSubCategoryViewModel != null)
                {
                    return PartialView("_DetailsPartsSubCategory", partsSubCategoryViewModel);
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