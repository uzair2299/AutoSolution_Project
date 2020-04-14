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
            return PartialView("_AddNewVehicleManufacturer");
        }

        [HttpPost]
        public ActionResult AddNew(string Name)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    AutoSolutionContext autoSolutionContext = new AutoSolutionContext();

                    var isExist = autoSolutionContext.VehicleManufacturers.FirstOrDefault(x => x.VehicleManufacturerName.ToLower() == Name.ToLower());
                    if(isExist!=null)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        VehicleManufacturer vehicleManufacturer = new VehicleManufacturer();
                        vehicleManufacturer.AddedDate = DateTime.Now;
                        vehicleManufacturer.IsActive = true;
                        vehicleManufacturer.UpdateDate = DateTime.Now;
                        vehicleManufacturer.VehicleManufacturerName = Name;
                        autoSolutionContext.VehicleManufacturers.Add(vehicleManufacturer);
                        autoSolutionContext.SaveChanges();
                        return RedirectToAction("Index");
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


        public ActionResult Edit(int?  id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            return PartialView("_EditPartialView");
        }



    }
}