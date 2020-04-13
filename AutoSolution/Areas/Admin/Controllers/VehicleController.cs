using AutoSolution.Database.DataBaseContext;
using AutoSolution.Services;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult GetVehicleManufacturer(string search, int? pageNo)
        {
            try
            {

                int PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
                AutoSolutionContext autoSolution = new AutoSolutionContext();
                var model = autoSolution.CarManufacturers.OrderBy(x => x.VehicleManufacturerId).Skip((PageNo - 1) * 10).Take(10).ToList();
                // int co = autoSolution.CarManufacturers.Count();
                int TotalCount = _unitOfWork.VehicleManufacturer.Count();
                VehicleManufacturerViewModel vehicleManufacturerView = new VehicleManufacturerViewModel();
                vehicleManufacturerView.VehicleManufacturersList = model;
                vehicleManufacturerView.Pager = new Pager(TotalCount, pageNo, 10);
                return PartialView("_VehicleManufacturer", vehicleManufacturerView);
            }
            catch (Exception)
            {

                return View("Error");
            }

        }

    }
}