using AutoSolution.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.ViewModel
{
    public class VehicleManufacturerViewModel
    {
        [Display(Name = "Vehicle Manufacturer Name")]
        public string SearchTerm { get; set; }
        [Display(Name ="Vehicle Manufacturer Name")]
        public string VehicleManufacturer { get; set; } 
        public List<VehicleManufacturer> VehicleManufacturersList { get; set; }
        public Pager Pager { get; set; }
    }
}
