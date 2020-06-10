using AutoSolution.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AutoSolution.Services.ViewModel
{
    public class PartsProductsViewModel
    {
        
        public int PartsProductId { get; set; }
        [Display(Name = "Select Part/Product Name")]
        public string PartsProductName { get; set; }
        [Display(Name = "Start Year")]
        public int? startYear { get; set; }
        [Display(Name = "End Year")]


        public DateTime? UpdatedDate { get; set; } 
        public int? EndYear { get; set; }
        [Display(Name = "Price")]
        public decimal UnitPrice { get; set; }

        public string ShortDescription { get; set; }
        [Display(Name = "Description")]
        public string LongDescription { get; set; }


        [Display(Name = "Vehicle Manufacturer Name")]
        public string VehicleManufacturerName { get; set; }
        [Display(Name = "Vehicle Model Name")]
        public string VehicleModelName { get; set; }

        [Display(Name = "Parts/Products Category Name")]
        public string PartsProductCategoryName { get; set; }

        [Display(Name = "Parts/Products Sub Category Name")]
        public string PartsProductSubCategoryName { get; set; }

        [Display(Name = "Parts/Products Manufacturer Name")]
        public string PartsProductManuName { get; set; }

        public int Quantity { get; set; }

        public string SearchTerm { get; set; }
        public string PictureIDs { get; set; }
        public List<VehicleVersion> VehicleVersionList { get; set; }
        public Pager Pager { get; set; }
        
        [Display(Name = "Select Vehicle Manufacturer")]
        public int? SelectedManufacturer { get; set; }
        public IEnumerable<SelectListItem> VehicleManufacturerList { get; set; }


        [Display(Name = "Select Part/Product Manufacturer")]
        public string SelectedPartProductManufacturer { get; set; }
        public IEnumerable<SelectListItem> PartProductManufacturerList { get; set; }


        [Display(Name = "Select Vehicle Model")]
        public int? SelectedModel { get; set; }
        public IEnumerable<SelectListItem> VehicleModelList { get; set; }


       



        [Display(Name = "Select Parts/Products Category Type")]
        public string SelectedPartsProductCategory { get; set; }
        public IEnumerable<SelectListItem> PartsProductsCategoryList { get; set; }


        [Display(Name = "Select Parts/Products Sub Category Type")]
        public string SelectedPartsProductSubCategory { get; set; }
        public IEnumerable<SelectListItem> PartsProductsSubCategoryList { get; set; }

        [Display(Name = "Upload Images")]
        public List<Image> images { get; set; }

        public List<PartsProduct> PartsProductList { get; set; }

        public List<PartProductImages> PartProductImagesList { get; set; }
    }
}
