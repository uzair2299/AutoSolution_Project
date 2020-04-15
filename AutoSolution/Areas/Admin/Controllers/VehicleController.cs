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
    public class VehicleController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new AutoSolutionContext());
        // GET: Admin/Vehicle
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AddNew()
        {
            VehicleManufacturerViewModel vehicleManufacturerView = new VehicleManufacturerViewModel();
            return PartialView("_AddNew");
        }

        [HttpPost]
        public ActionResult AddNew(VehicleManufacturerViewModel vehicleManufacturerViewModel)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    AutoSolutionContext autoSolutionContext = new AutoSolutionContext();

                    var isExist = autoSolutionContext.VehicleManufacturers.FirstOrDefault(x => x.VehicleManufacturerName.ToLower() ==vehicleManufacturerViewModel.VehicleManufacturer.ToLower());
                    if(isExist!=null)
                    {
                        return RedirectToAction("GetVehicleManufacturer");
                    }
                    else
                    {
                        VehicleManufacturer vehicle = new VehicleManufacturer();
                        vehicle.AddedDate = DateTime.Now;
                        vehicle.IsActive = true;
                        vehicle.UpdateDate = DateTime.Now;
                        vehicle.VehicleManufacturerName = vehicleManufacturerViewModel.VehicleManufacturer;
                        autoSolutionContext.VehicleManufacturers.Add(vehicle);
                        autoSolutionContext.SaveChanges();
                        return RedirectToAction("GetVehicleManufacturer");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult GetVehicleManufacturer(string search, int? pageNo)
        {
            try
            {
                if(search!=null)
                {
                    int PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
                    AutoSolutionContext autoSolution = new AutoSolutionContext();
                    var model = autoSolution.VehicleManufacturers.OrderBy(x => x.VehicleManufacturerName).Where(x=>x.VehicleManufacturerName.Contains(search)).Skip((PageNo - 1) * 10).Take(10).ToList();
                    int TotalCount = autoSolution.VehicleManufacturers.Where(x => x.VehicleManufacturerName.Contains(search)).Count();
                    //int TotalCount = _unitOfWork.VehicleManufacturer.Count();
                    VehicleManufacturerViewModel vehicleManufacturerView = new VehicleManufacturerViewModel();
                    vehicleManufacturerView.VehicleManufacturersList = model;
                    vehicleManufacturerView.Pager = new Pager(TotalCount, pageNo, 10);
                    return PartialView("_VehicleManufacturer", vehicleManufacturerView);


                }
                else
                {
                    int PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
                    AutoSolutionContext autoSolution = new AutoSolutionContext();
                    var model = autoSolution.VehicleManufacturers.OrderBy(x => x.VehicleManufacturerName).Skip((PageNo - 1) * 10).Take(10).ToList();
                    // int co = autoSolution.CarManufacturers.Count();
                    int TotalCount = _unitOfWork.VehicleManufacturer.Count();
                    VehicleManufacturerViewModel vehicleManufacturerView = new VehicleManufacturerViewModel();
                    vehicleManufacturerView.VehicleManufacturersList = model;
                    vehicleManufacturerView.Pager = new Pager(TotalCount, pageNo, 10);
                    return PartialView("_VehicleManufacturer", vehicleManufacturerView);


                }
            }
            catch (Exception)
            {

                return View("Error");
            }

        }


        public ActionResult Edit(string  id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoSolutionContext autoSolutionContext = new AutoSolutionContext();
            VehicleManufacturer vehicleManufacturer = new VehicleManufacturer();

            vehicleManufacturer = autoSolutionContext.VehicleManufacturers.Find(Convert.ToInt32(id));
            if (vehicleManufacturer != null) {
                return PartialView("_EditPartialView", vehicleManufacturer);
            }
            return RedirectToAction("Index");
            
        }
    }
}