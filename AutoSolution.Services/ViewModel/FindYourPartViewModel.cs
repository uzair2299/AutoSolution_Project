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
   public class FindYourPartViewModel
    {
        public int? startYear { get; set; }
        [Display(Name = "End Year")]
        public int? EndYear { get; set; }
        
        [Display(Name = "Select Vehicle Manufacturer")]
        public string SelectedVehicleManufacturer { get; set; }
        
        public IEnumerable<SelectListItem> VehicleManufacturersList { get; set; }
        [Display(Name = "Select Vehicle Model")]

        public string SelectedVehicleModel { get; set; }
        public IEnumerable<SelectListItem> VehicleModelsList { get; set; }

        public string SelectedPartProductCategory { get; set; }
        public IEnumerable<SelectListItem> PartsProductsCategoryList { get; set; }

        public string SelectedPartProductSubCategory { get; set; }
        public IEnumerable<SelectListItem> PartsProductsSubCategoryList { get; set; }


    }
}
