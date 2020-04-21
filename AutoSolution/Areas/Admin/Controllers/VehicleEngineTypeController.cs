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
    public class VehicleEngineTypeController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new AutoSolutionContext());

        // GET: Admin/VehicleEngineType
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddNew()
        {
            return PartialView("_AddNew");
        }

        [HttpPost]
        public ActionResult AddNew(VehicleEngineTypeViewModel vehicleEngineTypeViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    VehicleEngineTypeRepository vehicleEngineTypeRepository = new VehicleEngineTypeRepository(new AutoSolutionContext());
                    bool IsExist = vehicleEngineTypeRepository.isExist(vehicleEngineTypeViewModel.EngineTypeName);
                    if (!IsExist)
                    {
                        VehicleEngineType vehicleEngineType = new VehicleEngineType();
                        vehicleEngineType.EngineTypeName = vehicleEngineTypeViewModel.EngineTypeName;
                        _unitOfWork.VehicleEngineType.Add(vehicleEngineType);
                        _unitOfWork.Complete();
                        _unitOfWork.Dispose();
                        return RedirectToAction("GetVehicleEngineType");
                    }
                    else
                    {
                        return RedirectToAction("GetVehicleEngineType");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }


        public ActionResult GetVehicleEngineType(int? pageNo)
        {
            try
            {
                var Items = _unitOfWork.VehicleEngineType.GetAll();
                VehicleEngineTypeViewModel vehicleEngineTypeViewModel = new VehicleEngineTypeViewModel();
                int TotalCount = _unitOfWork.VehicleEngineType.Count();
                Pager pager = new Pager(TotalCount, pageNo, 10);
                vehicleEngineTypeViewModel.VehicleEngineTypeList = Items;
                vehicleEngineTypeViewModel.Pager = pager;
                return PartialView("_GetVehicleEngineType", vehicleEngineTypeViewModel);
            }
            catch (Exception)
            {

                return View("Error");
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

                var item = _unitOfWork.VehicleEngineType.GetByID(Convert.ToInt32(id));
                VehicleEngineTypeViewModel vehicleEngineTypeViewModel = new VehicleEngineTypeViewModel();
                vehicleEngineTypeViewModel.EngineTypeName= item.EngineTypeName;
                vehicleEngineTypeViewModel.VehicleEngineTypeId = item.VehicleEngineTypeId;
                
                if (vehicleEngineTypeViewModel != null)
                {
                    return PartialView("_EditvehicleEngineType", vehicleEngineTypeViewModel);
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
        public ActionResult Edit(VehicleEngineTypeViewModel vehicleEngineTypeViewModel)
        {
            VehicleEngineType vehicleEnginetype  = new VehicleEngineType();
            vehicleEnginetype = _unitOfWork.VehicleEngineType.GetByID(vehicleEngineTypeViewModel.VehicleEngineTypeId);
            vehicleEnginetype.EngineTypeName = vehicleEngineTypeViewModel.EngineTypeName;

            vehicleEnginetype.VehicleEngineTypeId = vehicleEngineTypeViewModel.VehicleEngineTypeId;
            _unitOfWork.VehicleEngineType.Update(vehicleEnginetype);
            _unitOfWork.Complete();
            _unitOfWork.Dispose();
            return RedirectToAction("GetVehicleEngineType");
        }

        public ActionResult Details(string id)
        {

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }


                VehicleEngineType vehicleEngineType = _unitOfWork.VehicleEngineType.GetByID(Convert.ToInt32(id));
                VehicleEngineTypeViewModel vehicleEngineTypeViewModel = new VehicleEngineTypeViewModel();

                vehicleEngineTypeViewModel.EngineTypeName = vehicleEngineType.EngineTypeName;
                
                if (vehicleEngineTypeViewModel != null)
                {
                    return PartialView("_DetailsvehicleEngineType", vehicleEngineTypeViewModel);
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