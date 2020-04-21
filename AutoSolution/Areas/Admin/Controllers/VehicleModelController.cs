using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services;
using AutoSolution.Services.ViewModel;
using System;
using System.Net;
using System.Web.Mvc;

namespace AutoSolution.Areas.Admin.Controllers
{
    public class VehicleModelController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new AutoSolutionContext());
        // GET: Admin/VehicleModel
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult AddNew()
        {
            var model = _unitOfWork.VehicleModel.AddnewVehicleModel();
            return PartialView("_AddNew",model);
        }
        [HttpPost]
        public ActionResult AddNew(VehilceModelViewModel vehilceModelViewModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    string str = vehilceModelViewModel.VehicleModel;
                    VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(new AutoSolutionContext());
                    bool IsExist = vehicleModelRepository.isExist(vehilceModelViewModel.VehicleModel);
                    if (!IsExist)
                    {
                        VehicleModel vehicleModel = new VehicleModel();
                        vehicleModel.VehicleModelName = vehilceModelViewModel.VehicleModel;
                        vehicleModel.VehicleManufacturerId = Convert.ToInt32(vehilceModelViewModel.SelectedVehicleManufacturer);
                        _unitOfWork.VehicleModel.Add(vehicleModel);
                        _unitOfWork.Complete();
                        _unitOfWork.Dispose();
                        return RedirectToAction("GetVehicleModel");

                    }
                    else
                    {
                        return RedirectToAction("GetVehicleModel");
                        
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }
        public ActionResult GetVehicleModel(string search,string SelectedVehicleManufacturer, int? pageNo)
        
        
       {
            try
            {
                if (string.IsNullOrEmpty(search))
                {
                    int PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
                    int TotalCount = _unitOfWork.VehicleModel.Count();
                    var model = _unitOfWork.VehicleModel.GetVehicleModel(PageNo, TotalCount);
                    return PartialView("_GetVehicleModel", model);

                                    }
                else
                {
                    int PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
                    int TotalCount = _unitOfWork.VehicleModel.GetVehicleModelCount(search, SelectedVehicleManufacturer);
                    var model = _unitOfWork.VehicleModel.GetVehicleModel(PageNo, TotalCount, search, SelectedVehicleManufacturer);
                    return PartialView("_GetVehicleModel", model);

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

                var item = _unitOfWork.VehicleModel.GetByID(Convert.ToInt32(id));
                VehilceModelViewModel vehilceModelViewModel = new VehilceModelViewModel();
                VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(new AutoSolutionContext());
                vehilceModelViewModel.VehicleModelId = item.VehicleModelId;
                vehilceModelViewModel.VehicleModel = item.VehicleModelName;
                vehilceModelViewModel.SelectedVehicleManufacturer = item.VehicleManufacturerId.ToString();
                vehilceModelViewModel.VehicleManufacturersList = vehicleModelRepository.GetVehicleManufacturerDropDown();
                if (vehilceModelViewModel != null)
                {
                    return PartialView("_EditVehicleModel",vehilceModelViewModel);
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
        public ActionResult Edit(VehilceModelViewModel vehilceModelViewModel)
        {
            try
            {

                if (vehilceModelViewModel == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                VehicleModel vehicleModel = new VehicleModel();
                vehicleModel.VehicleModelId = vehilceModelViewModel.VehicleModelId;
                vehicleModel.VehicleModelName = vehilceModelViewModel.VehicleModel;
                vehicleModel.VehicleManufacturerId =Convert.ToInt32(vehilceModelViewModel.SelectedVehicleManufacturer);
                _unitOfWork.VehicleModel.Update(vehicleModel);
                _unitOfWork.Complete();
                _unitOfWork.Dispose();

            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("GetVehicleModel");
        }


        public ActionResult Details(string id)
        {

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                VehicleModel vehicleModel = new VehicleModel();

                  vehicleModel  = _unitOfWork.VehicleModel.GetByID(Convert.ToInt32(id));
                VehilceModelViewModel vehilceModelViewModel = new VehilceModelViewModel();
                vehilceModelViewModel.VehicleModelId = vehicleModel.VehicleModelId;
                vehilceModelViewModel.VehicleModel = vehicleModel.VehicleModelName;
                vehilceModelViewModel.VehicleManufacturerName = vehicleModel.VehicleManufacturer.VehicleManufacturerName;
                

                if (vehilceModelViewModel!=null)
                {
                    return PartialView("_DetailsVehilceModel", vehilceModelViewModel);
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