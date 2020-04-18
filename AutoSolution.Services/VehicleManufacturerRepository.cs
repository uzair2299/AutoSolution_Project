using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services.Repo;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AutoSolution.Services
{
    public class VehicleManufacturerRepository : AutoSolutionRepository<VehicleManufacturer>, IVehicleManufacturerRepository
    {
        public VehicleManufacturerRepository(AutoSolutionContext context) : base(context) { }

        public IEnumerable<SelectListItem> GetVehicleManufacturerDropDown()
        {
            List<SelectListItem> items = Context.Set<VehicleManufacturer>().OrderBy(n => n.VehicleManufacturerName).Select(n => new SelectListItem
            {
                Value = n.VehicleManufacturerId.ToString(),
                Text = n.VehicleManufacturerName
            }).ToList();

            var Tip = new SelectListItem()
            {
                Value = (-1).ToString(),
                Text = "----------- Select Vehicle Manufacturer ------------"
            };
            items.Insert(0, Tip);
            return new SelectList(items, "value", "Text");
        }


        public VehilceModelViewModel AddnewVehicleModel()
        {
            var VehilceModelViewModel = new VehilceModelViewModel()
            {
                VehicleManufacturersList = GetVehicleManufacturerDropDown(),
            };
            return VehilceModelViewModel;
        }
    }
}
