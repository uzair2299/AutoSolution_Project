using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.ViewModel
{
  public   class VehicleManufacturerAddEditViewModel
    {

        public int VehicleManufacturerId { get; set; }
        [Display(Name = "Vehicle Manufacturer Name")]
        public string VehicleManufacturerName { get; set; }
        [Display(Name = "Added Date")]
        public DateTime AddedDate { get; set; }
        [Display(Name = "Last Update Date")]
        public DateTime UpdateDate { get; set; }
        [Display(Name = "Status")]
        public bool IsActive { get; set; }
    }
}
