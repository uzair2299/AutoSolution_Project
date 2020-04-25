using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AutoSolution.Areas.Admin.Controllers
{
    public class PartsProductManuController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new AutoSolutionContext());
        // GET: Admin/PartsProductManu
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AddNew()
        {
            return PartialView("_AddNewPartsProductManu");
        }


        [HttpPost]
        public ActionResult AddNew(PartsProductManuVeiwModel partsProductManuVeiwModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PartsProductManufacturerRepository partsProductManufacturerRepository = new PartsProductManufacturerRepository(new AutoSolutionContext());
                    bool IsExist = partsProductManufacturerRepository.isExist(partsProductManuVeiwModel.PartsProductManufacturerName);
                    if (!IsExist)
                    {

                        PartsProductManufacturer partsProductManufacturer = new PartsProductManufacturer();
                        partsProductManufacturer.PartsProductManufacturerName = partsProductManuVeiwModel.PartsProductManufacturerName;
                        partsProductManufacturer.PartsProductManufacturerCode = partsProductManuVeiwModel.PartsProductManufacturerCode;
                        _unitOfWork.PartsProductManufacturer.Add(partsProductManufacturer);
                        _unitOfWork.Complete();
                        _unitOfWork.Dispose();
                        return RedirectToAction("GetPartsProductsManu");
                    }
                    else
                    {
                        return RedirectToAction("GetPartsProductsManu");

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }


        public ActionResult GetPartsProductsManu(string search, int? pageNo)
        {
            try
            {
                if (string.IsNullOrEmpty(search))
                {
                    int PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
                    int TotalCount = _unitOfWork.PartsProductManufacturer.Count();
                    var model = _unitOfWork.PartsProductManufacturer.GetPartsProductManu(PageNo, TotalCount);
                    return PartialView("_GetPartsProductsManu", model);
                }
                else
                {
                    int PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
                    int TotalCount = _unitOfWork.PartsProductManufacturer.GetPartsProductManuCount(search);
                    var model = _unitOfWork.PartsProductManufacturer.GetPartsProductManu(PageNo, TotalCount, search);
                    return PartialView("_GetPartsProductsManu", model);
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

                var item = _unitOfWork.PartsProductManufacturer.GetByID(Convert.ToInt32(id));
                PartsProductManuVeiwModel partsProductManufacturerVM = new PartsProductManuVeiwModel();
                partsProductManufacturerVM.PartsProductManufacturerId = item.PartsProductManufacturerId;
                partsProductManufacturerVM.PartsProductManufacturerName = item.PartsProductManufacturerName;
                partsProductManufacturerVM.PartsProductManufacturerCode = item.PartsProductManufacturerCode;
                if (partsProductManufacturerVM != null)
                {
                    return PartialView("_EditPartsProductsManu", partsProductManufacturerVM);
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
        public ActionResult Edit(PartsProductManuVeiwModel PartsProductManuVeiwModel)
        {
            try
            {

                if (PartsProductManuVeiwModel == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                PartsProductManufacturer partsProductManufacturer = new PartsProductManufacturer();
                partsProductManufacturer = _unitOfWork.PartsProductManufacturer.GetByID(Convert.ToInt32(PartsProductManuVeiwModel.PartsProductManufacturerId));

                partsProductManufacturer.PartsProductManufacturerName = PartsProductManuVeiwModel.PartsProductManufacturerName;
                partsProductManufacturer.PartsProductManufacturerCode = PartsProductManuVeiwModel.PartsProductManufacturerCode;

                _unitOfWork.PartsProductManufacturer.Update(partsProductManufacturer);
                _unitOfWork.Complete();
                _unitOfWork.Dispose();

            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("GetPartsProductsManu");
        }



        public ActionResult Details(string id)
        {

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var item = _unitOfWork.PartsProductManufacturer.GetByID(Convert.ToInt32(id));
                PartsProductManuVeiwModel partsProductManufacturerVM = new PartsProductManuVeiwModel();
                partsProductManufacturerVM.PartsProductManufacturerId = item.PartsProductManufacturerId;
                partsProductManufacturerVM.PartsProductManufacturerName = item.PartsProductManufacturerName;
                partsProductManufacturerVM.PartsProductManufacturerCode = item.PartsProductManufacturerCode;



                if (partsProductManufacturerVM != null)
                {
                    return PartialView("_DetailsPartsProductsManu", partsProductManufacturerVM);
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