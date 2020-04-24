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
    public class VehicleVersionController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new AutoSolutionContext());
        // GET: Admin/VehicleVersion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddNew()
        {
            var model = _unitOfWork.VehicleVersion.AddNewVehicleVerison();
            return PartialView("_AddNewVehicleVersion", model);
        }

        [HttpPost]
        public ActionResult AddNew(VehicleVersionViewModel vehicleVersionViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    VehicleVersionRepository vehicleVersionRepository = new VehicleVersionRepository(new AutoSolutionContext());
                    bool IsExist = vehicleVersionRepository.isExist(vehicleVersionViewModel.VehicleVersionName, vehicleVersionViewModel.SelectedModel);
                    if (!IsExist)
                    {

                        VehicleVersion vehicleVersion = new VehicleVersion();

                        vehicleVersion.VehicleVersionName = vehicleVersionViewModel.VehicleVersionName;
                        vehicleVersion.EngineCapacity = vehicleVersionViewModel.EngineCapacity;
                        vehicleVersion.startYear =Convert.ToInt32( vehicleVersionViewModel.startYear);
                        vehicleVersion.EndYear = Convert.ToInt32(vehicleVersionViewModel.EndYear);
                        vehicleVersion.VehicleModelId = Convert.ToInt32(vehicleVersionViewModel.SelectedModel);
                        vehicleVersion.TransmissionTypeId =Convert.ToInt32(vehicleVersionViewModel.SelectedTransmissionType);
                        vehicleVersion.VehicleEngineTypeId = Convert.ToInt32(vehicleVersionViewModel.SelectedEngineType);
                        vehicleVersion.AddedDate = DateTime.Now;
                        vehicleVersion.UpdatedDate = DateTime.Now;


                        _unitOfWork.VehicleVersion.Add(vehicleVersion);
                        _unitOfWork.Complete();
                        _unitOfWork.Dispose();
                        return RedirectToAction("GetVehicleVersion");

                    }
                    else
                    {
                        return RedirectToAction("GetVehicleVersion");

                    }
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

                var item = _unitOfWork.VehicleVersion.GetByID(Convert.ToInt32(id));
                var Manufacturer = _unitOfWork.VehicleManufacturer.GetByID(item.VehicleModel.VehicleManufacturerId);
                
                VehicleVersionViewModel vehicleVersionViewModel = new VehicleVersionViewModel();
                VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(new AutoSolutionContext());
                VehicleEngineTypeRepository vehicleEngineTypeRepository = new VehicleEngineTypeRepository(new AutoSolutionContext());
                TransmissionTypeRepository transmissionTypeRepository = new TransmissionTypeRepository(new AutoSolutionContext());
                
                vehicleVersionViewModel.VehicleVersionId = item.VehicleVersionId;
                vehicleVersionViewModel.VehicleVersionName = item.VehicleVersionName;
                vehicleVersionViewModel.EngineCapacity = item.EngineCapacity;
                vehicleVersionViewModel.startYear = item.startYear;
                vehicleVersionViewModel.EndYear = item.EndYear;
                vehicleVersionViewModel.VehicleManufacturerList = vehicleModelRepository.GetVehicleManufacturerDropDown();
                vehicleVersionViewModel.VehicleModelList = vehicleModelRepository.GetVehicleModelDropDown();
                vehicleVersionViewModel.TransmissionTypeList = transmissionTypeRepository.GetTransmissionDropDown();
                vehicleVersionViewModel.EngineTypeList = vehicleEngineTypeRepository.GetVehicleEngineTypeDropDown();
                
                vehicleVersionViewModel.SelectedManufacturer = Manufacturer.VehicleManufacturerId.ToString();
                vehicleVersionViewModel.SelectedEngineType = item.VehicleEngineTypeId.ToString();
                vehicleVersionViewModel.SelectedModel = item.VehicleModelId.ToString();
                vehicleVersionViewModel.SelectedTransmissionType = item.TransmissionTypeId.ToString();
                if (vehicleVersionViewModel != null)
                {
                    return PartialView("_EditVehicleVersion", vehicleVersionViewModel);
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
        public ActionResult Edit(VehicleVersionViewModel vehicleVersionViewModel)
        {
            try
            {

                if (vehicleVersionViewModel == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                VehicleVersion vehicleVersion = _unitOfWork.VehicleVersion.GetByID(vehicleVersionViewModel.VehicleVersionId);
                vehicleVersion.VehicleVersionId = vehicleVersionViewModel.VehicleVersionId;
                vehicleVersion.UpdatedDate = DateTime.Now;
                vehicleVersion.VehicleVersionName = vehicleVersionViewModel.VehicleVersionName;
                vehicleVersion.startYear = Convert.ToInt32(vehicleVersionViewModel.startYear);
                vehicleVersion.EndYear = Convert.ToInt32(vehicleVersionViewModel.EndYear);    
                vehicleVersion.TransmissionTypeId =Convert.ToInt32( vehicleVersionViewModel.SelectedTransmissionType);
                vehicleVersion.EngineCapacity = vehicleVersionViewModel.EngineCapacity;
                vehicleVersion.VehicleEngineTypeId =Convert.ToInt32(vehicleVersionViewModel.SelectedEngineType);
                vehicleVersion.VehicleModelId = Convert.ToInt32(vehicleVersionViewModel.SelectedModel);
                _unitOfWork.VehicleVersion.Update(vehicleVersion);
                _unitOfWork.Complete();
                _unitOfWork.Dispose();

            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("GetVehicleVersion");
        }

        public ActionResult GetVehicleVersion(string search, string SelectedVehicleVersion, int? pageNo)


        {
            try
            {
                if (string.IsNullOrEmpty(search) && string.IsNullOrEmpty(SelectedVehicleVersion))
                {
                    int PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
                    int TotalCount = _unitOfWork.VehicleVersion.Count();
                    var model = _unitOfWork.VehicleVersion.GetVehicleVersion(PageNo, TotalCount);
                    return PartialView("_GetVehicleVersion", model);

                }
                else
                {
                    int PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
                    int TotalCount = _unitOfWork.VehicleVersion.GetVehicleModelCount(search, SelectedVehicleVersion);
                    var model = _unitOfWork.VehicleVersion.GetVehicleVersion(PageNo, TotalCount, search, SelectedVehicleVersion);
                    return PartialView("_GetVehicleVersion", model);

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

                var item = _unitOfWork.VehicleVersion.GetByID(Convert.ToInt32(id));
                var Manufacturer = _unitOfWork.VehicleManufacturer.GetByID(item.VehicleModel.VehicleManufacturerId);
                VehicleVersionViewModel vehicleVersionViewModel = new VehicleVersionViewModel();

                vehicleVersionViewModel.VehicleVersionName = item.VehicleVersionName;
                vehicleVersionViewModel.EngineCapacity = item.EngineCapacity;
                vehicleVersionViewModel.startYear = item.startYear;
                vehicleVersionViewModel.EndYear = item.EndYear;
                vehicleVersionViewModel.VehicleManufacturerName = Manufacturer.VehicleManufacturerName;
                vehicleVersionViewModel.EngineCapacity = item.EngineCapacity;
                vehicleVersionViewModel.startYear = item.startYear;
                vehicleVersionViewModel.EndYear = item.EndYear;
                vehicleVersionViewModel.VehicleEngineType = item.VehicleEngineType.EngineTypeName;
                vehicleVersionViewModel.VehicleTransmission = item.TransmissionType.TransmissionTypeName;
                vehicleVersionViewModel.VehicleModelName = item.VehicleModel.VehicleModelName;
                if (vehicleVersionViewModel != null)
                {
                    return PartialView("_DetailsVehicleVersion", vehicleVersionViewModel);
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
        public ActionResult GetTransmissionTypes(string SelectedModelId)
        {
            if (!string.IsNullOrWhiteSpace(SelectedModelId))
            {
                IEnumerable<SelectListItem> Transmissions = _unitOfWork.TransmissionType.GetTransmissionDropDown();
                return Json(Transmissions, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        [HttpGet]
        public ActionResult GetEngineTypes()
        {
            
                IEnumerable<SelectListItem> Engines = _unitOfWork.VehicleEngineType.GetVehicleEngineTypeDropDown();
                return Json(Engines, JsonRequestBehavior.AllowGet);
            
        }


    }
}