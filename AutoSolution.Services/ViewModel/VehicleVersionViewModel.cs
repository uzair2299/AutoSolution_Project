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
    public class VehicleVersionViewModel
    {
        public int VehicleVersionId { get; set; }
        [Display(Name = "Vehicle Version Name")]
        public string VehicleVersionName { get; set; }
        [Display(Name = "Engine Capacity")]
        public string EngineCapacity { get; set; }
        [Display(Name = "Status")]
        public bool IsDeleted { get; set; }

        [Display(Name = "Vehicle Manufacturer Name")]
        public string VehicleManufacturerName { get; set; }
        [Display(Name = "Vehicle Model Name")]
        public string VehicleModelName { get; set; }
        [Display(Name = "Vehicle Transmission Type")]
        public string VehicleTransmission { get; set; }
        [Display(Name = "Vehicle Engine Type")]
        public string VehicleEngineType { get; set; }
        public string SearchTerm { get; set; }
        [Display(Name = "Start Year")]
        public int? startYear { get; set; }
        [Display(Name = "End Year")]
        public int? EndYear { get; set; }
        public List<VehicleVersion> VehicleVersionList { get; set; }
        public Pager Pager { get; set; }

        [Display(Name = "Select Vehicle Manufacturer")]
        public string SelectedManufacturer { get; set; }
        public IEnumerable<SelectListItem> VehicleManufacturerList { get; set; }


        [Display(Name = "Select Vehicle Model")]
        public string SelectedModel { get; set; }
        public IEnumerable<SelectListItem> VehicleModelList { get; set; }


        [Display(Name = "Select Engine Type")]
        public string SelectedEngineType { get; set; }
        public IEnumerable<SelectListItem> EngineTypeList { get; set; }

        [Display(Name = "Select Transmission Type")]
        public string SelectedTransmissionType { get; set; }
        public IEnumerable<SelectListItem> TransmissionTypeList { get; set; }
    }
}
