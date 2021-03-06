﻿using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services;
using AutoSolution.Services.CommonServices;
using AutoSolution.Services.ViewModel;
using Microsoft.Web.Infrastructure.DynamicValidationHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;

namespace AutoSolution.Areas.Admin.Controllers
{
    public class PartsProductsController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new AutoSolutionContext());
        // GET: Admin/PartsProducts
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddNew()
        {
            var model = _unitOfWork.PartsProducts.AddNewPartsProducts();
            return PartialView("_AddNewPartsProduct", model);
        }

        [HttpPost]
        public ActionResult AddNew(PartsProductsViewModel partsProductsViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    //VehicleVersionRepository vehicleVersionRepository = new VehicleVersionRepository(new AutoSolutionContext());
                    //bool IsExist = vehicleVersionRepository.isExist(vehicleVersionViewModel.VehicleVersionName, vehicleVersionViewModel.SelectedModel);
                    //if (!IsExist)
                    //{

                     PartsProduct partsProduct = new PartsProduct();
                     var ImageIds = partsProductsViewModel.PictureIDs.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries). Select(ID=>int.Parse(ID)).ToList();
                    partsProduct.PartProductImages = new List<PartProductImages>();
            foreach(var PicId in ImageIds)
                    {
                        PartProductImages partProductImages = new PartProductImages()
                        {
                            ImageId = PicId
                        };
                        partsProduct.PartProductImages.Add(partProductImages);

                    }

                    partsProduct.AddedDate = DateTime.Now;
                    partsProduct.EndYear = Convert.ToInt32(partsProductsViewModel.EndYear);
                    partsProduct.startYear = Convert.ToInt32(partsProductsViewModel.startYear);
                    partsProduct.UnitPrice = partsProductsViewModel.UnitPrice;
                    partsProduct.ShortDescription = partsProductsViewModel.ShortDescription;
                    partsProduct.LongDescription = partsProductsViewModel.LongDescription;
                    partsProduct.PartsProductName = partsProductsViewModel.PartsProductName;
                    partsProduct.VehicleManufacturerId = partsProductsViewModel.SelectedManufacturer;
                    partsProduct.PartsProductsSubCategoryId = Convert.ToInt32(partsProductsViewModel.SelectedPartsProductSubCategory);
                    partsProduct.VehicleModelId = partsProductsViewModel.SelectedModel;
                    //partsProduct.PartsProductManufacturerId = Convert.ToInt32(partsProductsViewModel.SelectedPartProductManufacturer);
                        _unitOfWork.PartsProducts.Add(partsProduct);
                        _unitOfWork.Complete();
                        _unitOfWork.Dispose();
                        return RedirectToAction("GetPartsProduct");

                    //}
                    //else
                    //{
              //      return RedirectToAction("GetVehicleVersion");

                    //}
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }


        public ActionResult Edit(string id)
        {

            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var item = _unitOfWork.PartsProducts.GetByID(Convert.ToInt32(id));
                var VManufacturer = _unitOfWork.VehicleManufacturer.GetByID(item.VehicleModel.VehicleManufacturerId);
                var VModel = _unitOfWork.VehicleModel.GetByID(item.VehicleModel.VehicleModelId);
                var PSUbCategory = _unitOfWork.PartsSubCategory.GetByID(item.PartsProductsSubCategoryId);
                var PCategory = _unitOfWork.PartsProductsCategory.GetByID(item.PartsProductsSubCategory.PartsProductsCategoryId);
                var PManufacturer = _unitOfWork.PartsProductManufacturer.GetByID(item.PartsProductManufacturer.PartsProductManufacturerId);
                VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(new AutoSolutionContext());
                PartsSubCategoryRepository partsSubCategoryRepository = new PartsSubCategoryRepository(new AutoSolutionContext());
                TransmissionTypeRepository transmissionTypeRepository = new TransmissionTypeRepository(new AutoSolutionContext());
                VehicleEngineTypeRepository vehicleEngineTypeRepository = new VehicleEngineTypeRepository(new AutoSolutionContext());
                PartsProductManufacturerRepository partsProductManufacturerRepository = new PartsProductManufacturerRepository(new AutoSolutionContext());

                PartsProductsViewModel partsProductsViewModel = new PartsProductsViewModel();
                partsProductsViewModel.PartsProductId = item.PartsProductId;
                partsProductsViewModel.EndYear = item.EndYear;
                partsProductsViewModel.startYear = item.startYear;
                partsProductsViewModel.PartsProductName = item.PartsProductName;
                partsProductsViewModel.LongDescription = item.LongDescription;
                partsProductsViewModel.ShortDescription = item.ShortDescription;
                partsProductsViewModel.UnitPrice = item.UnitPrice;


                partsProductsViewModel.VehicleManufacturerList = vehicleModelRepository.GetVehicleManufacturerDropDown();
                partsProductsViewModel.VehicleModelList = vehicleModelRepository.GetVehicleModelDropDown();
                partsProductsViewModel.PartsProductsCategoryList = partsSubCategoryRepository.GetPartsProductCategoryDropDown();
                partsProductsViewModel.PartsProductsSubCategoryList = partsSubCategoryRepository.GetPartsProductSubCategoryDropDown();
                partsProductsViewModel.PartProductManufacturerList = partsProductManufacturerRepository.GetPPManufacturerDropDown();


                partsProductsViewModel.SelectedManufacturer = VManufacturer.VehicleManufacturerId;
                partsProductsViewModel.SelectedModel = VModel.VehicleModelId;
                partsProductsViewModel.SelectedPartsProductCategory = PCategory.PartsProductsCategoryId.ToString();
                partsProductsViewModel.SelectedPartsProductSubCategory = PSUbCategory.PartsProductsSubCategoryId.ToString();
                partsProductsViewModel.SelectedPartProductManufacturer = PManufacturer.PartsProductManufacturerId.ToString();
                partsProductsViewModel.SelectedModel = item.VehicleModelId;

                partsProductsViewModel.PartProductImagesList = item.PartProductImages.ToList();
                if (partsProductsViewModel != null)
                {
                    return PartialView("_EditPartsProduct", partsProductsViewModel);
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
        public ActionResult Edit(PartsProductsViewModel partsProductsViewModel)
        {
            try
            {
               // PartsProduct partsProduct = new PartsProduct();
                var ImageIds = partsProductsViewModel.PictureIDs.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(ID => int.Parse(ID)).ToList();
                
                if (partsProductsViewModel == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                PartsProduct partsProduct = new PartsProduct();
                partsProduct = _unitOfWork.PartsProducts.GetByID(partsProductsViewModel.PartsProductId);
                AutoSolutionContext autoSolutionContext = new AutoSolutionContext();
               
                var partimagesDeleted= autoSolutionContext.PartProductImages.Where(x => x.PartsProductId == partsProduct.PartsProductId).ToList();
               foreach(var item in partimagesDeleted)
                {
                    autoSolutionContext.PartProductImages.Remove(item);
                   // autoSolutionContext.Images.Remove(item.Image);
                }

               //foreach(var item in ImageIds)
               // {
               //   var iamgeItem=  autoSolutionContext.Images.Where(x => x.ImageId == item).FirstOrDefault();
               //     autoSolutionContext.Images.Remove(iamgeItem);
               // }
                
                autoSolutionContext.SaveChanges();
                
                partsProduct.PartProductImages = new List<PartProductImages>();
                foreach (var PicId in ImageIds)
                {
                    PartProductImages partProductImages = new PartProductImages()
                    {
                        ImageId = PicId
                    };
                    partsProduct.PartProductImages.Add(partProductImages);

                }

                //vehicleVersion.VehicleVersionId = vehicleVersionViewModel.VehicleVersionId;
                partsProduct.AddedDate = DateTime.Now;
                partsProduct.EndYear = Convert.ToInt32(partsProductsViewModel.EndYear);
                partsProduct.startYear = Convert.ToInt32(partsProductsViewModel.startYear);
                partsProduct.UnitPrice = partsProductsViewModel.UnitPrice;
                partsProduct.ShortDescription = partsProductsViewModel.ShortDescription;
                partsProduct.LongDescription = partsProductsViewModel.LongDescription;
                partsProduct.PartsProductName = partsProductsViewModel.PartsProductName;
                partsProduct.VehicleManufacturerId = Convert.ToInt32(partsProductsViewModel.SelectedManufacturer);
                partsProduct.PartsProductsSubCategoryId = Convert.ToInt32(partsProductsViewModel.SelectedPartsProductSubCategory);
                partsProduct.VehicleModelId = Convert.ToInt32(partsProductsViewModel.SelectedModel);
                partsProduct.PartsProductManufacturerId = Convert.ToInt32(partsProductsViewModel.SelectedPartProductManufacturer);
                _unitOfWork.PartsProducts.Update(partsProduct);
                _unitOfWork.Complete();
                _unitOfWork.Dispose();

            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("GetPartsProduct");
        }


        public ActionResult GetPartsProduct(string search, int? pageNo)
        {
            try
            {
                if (string.IsNullOrEmpty(search))
                {
                    int PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
                    int TotalCount = _unitOfWork.PartsProducts.Count();
                    var model = _unitOfWork.PartsProducts.GetPartsProducts(PageNo, TotalCount);
                    return PartialView("_GetPartsProduct", model);
                }
                else
                {
                    int PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
                    int TotalCount = _unitOfWork.PartsProducts.GetPartsProductsCount(search);
                    var model = _unitOfWork.PartsProductsCategory.GetPartsProductsCategory(PageNo, TotalCount, search);
                    return PartialView("_GetPartsProductsCategory", model);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        public ActionResult Details(string id)
        {

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var item = _unitOfWork.PartsProducts.GetByID(Convert.ToInt32(id));
                PartsProductsViewModel partsProductsViewModel = new PartsProductsViewModel();

                partsProductsViewModel.PartsProductName = item.PartsProductName;
                partsProductsViewModel.UnitPrice = item.UnitPrice;
                partsProductsViewModel.EndYear = item.EndYear;
                partsProductsViewModel.startYear = item.startYear;
                partsProductsViewModel.ShortDescription = item.ShortDescription;
                partsProductsViewModel.LongDescription = item.LongDescription;
                partsProductsViewModel.VehicleManufacturerName = item.VehicleManufacturer.VehicleManufacturerName;
                partsProductsViewModel.VehicleModelName = item.VehicleModel.VehicleModelName;
                partsProductsViewModel.VehicleManufacturerName = item.PartsProductManufacturer.PartsProductManufacturerName;
                partsProductsViewModel.PartsProductSubCategoryName = item.PartsProductsSubCategory.PartsProductsSubCategoryName;
                partsProductsViewModel.PartsProductCategoryName = item.PartsProductsSubCategory.PartsProductsCategory.PartsProductsCategoryName;



                if (partsProductsViewModel != null)
                {
                    return PartialView("_DetailsPartsProduct", partsProductsViewModel);
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

        [HttpGet]
        public ActionResult GetModels(string selectedManufacturerId)
        {
            if (!string.IsNullOrWhiteSpace(selectedManufacturerId))
            {
                IEnumerable<SelectListItem> Moldels = _unitOfWork.VehicleModel.GetVehicleModelDropDown(selectedManufacturerId);
                return Json(Moldels, JsonRequestBehavior.AllowGet);
            }
            return null;
        }


        
        
        [HttpGet]
        public ActionResult GetSubCategories(string SelectedPartsProductCategoryId)
        {
            if (!string.IsNullOrWhiteSpace(SelectedPartsProductCategoryId))
            {
                IEnumerable<SelectListItem> Moldels = _unitOfWork.PartsSubCategory.GetPartsProductSubCategoryDropDown(SelectedPartsProductCategoryId);
                return Json(Moldels, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        [HttpGet]
        public ActionResult GetPPManufacturer()
        {
            
            
                IEnumerable<SelectListItem> Moldels = _unitOfWork.PartsProductManufacturer.GetPPManufacturerDropDown();
                return Json(Moldels, JsonRequestBehavior.AllowGet);
            
            
        }

        [HttpPost]
        public JsonResult AddImages()
        {
            JsonResult jsonResult = new JsonResult();
            List<object> PicJson = new List<object>();
            AutoSolutionContext autoSolutionContext = new AutoSolutionContext();
            var RequestPicx = Request.Files;


            for (int i = 0; i < RequestPicx.Count; i++)
            {
                var pic = RequestPicx[i];
                var FileName = pic.FileName;
                //var FileName = Guid.NewGuid() + Path.GetExtension(pic.FileName);
                var path = Server.MapPath("~/AutoImages/") + FileName ;
                pic.SaveAs(path);
                var Dbimg = new Image();
                Dbimg.AddedDate = DateTime.Now;
                Dbimg.ImageName = FileName;
                Dbimg.ImagePath = path;
                autoSolutionContext.Images.Add(Dbimg);
               autoSolutionContext.SaveChanges();
                PicJson.Add(new 
                {
                    ID = Dbimg.ImageId,
                    PicURL = FileName
                });
            }
            jsonResult.Data = PicJson;
            return jsonResult;
        }
    }
}