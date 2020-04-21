using AutoSolution.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AutoSolution.Services.ViewModel
{
  public class VehilceModelViewModel
    {
        public int VehicleModelId { get; set; }

        [Display(Name = "Vehicle Model Name")]
        public string SearchTerm { get; set; }
        [Display(Name = "Vehicle Manufacturer Name")]
        public string VehicleManufacturerName { get; set; }
        [Display(Name = "Vehicle Model Name")]
        public string VehicleModel { get; set; }
        [Display(Name = "Select Vehicle Manufacturer")]
        public string SelectedVehicleManufacturer { get; set; }
        public IEnumerable<SelectListItem> VehicleManufacturersList { get; set; }
        public List<VehicleModel> VehicleModelsList { get; set; }
        public Pager Pager { get; set; }
    }
}
