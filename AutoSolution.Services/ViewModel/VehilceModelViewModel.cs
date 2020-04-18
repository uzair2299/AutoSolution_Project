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
        [Display(Name = "Vehicle Model Name")]
        public string SearchTerm { get; set; }
        [Display(Name = "Vehicle Model Name")]
        public string VehicleModel { get; set; }
        public IEnumerable<SelectListItem> VehicleManufacturersList { get; set; }
        public List<VehicleModel> VehicleModelsList { get; set; }
        public Pager Pager { get; set; }
    }
}
