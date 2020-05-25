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
    public class PartsProductsDetailViewModel
    {
        public int PartsProductId { get; set; }
        [Display(Name = "Part/Product Name")]
        public string PartsProductName { get; set; }
        [Display(Name = "Start Year")]
        public int? startYear { get; set; }


        [Display(Name = "Last Update")]
        public DateTime? UpdatedDate { get; set; }
        [Display(Name = "End Year")]
        public int? EndYear { get; set; }
        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }

        public string ShortDescription { get; set; }
        [Display(Name = "Description")]
        public string LongDescription { get; set; }


        [Display(Name = "Vehicle Maker Name")]
        public string VehicleManufacturerName { get; set; }
        [Display(Name = "Vehicle Model Name")]
        public string VehicleModelName { get; set; }

        [Display(Name = "Category Name")]
        public string PartsProductCategoryName { get; set; }

        [Display(Name = "Sub Category Name")]
        public string PartsProductSubCategoryName { get; set; }

        [Display(Name = "Parts/Products Manufacturer Name")]
        public string PartsProductManuName { get; set; }

        public List<PartsProduct> PartsProductsList{ get; set; }

        public List<PartProductImages> PartProductImagesList { get; set; }
    }
}
