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
    public class PartsSubCategoryViewModel
    {
        public int PartsProductsSubCategoryId { get; set; }
        [Display(Name = "Parts/Products Sub Category Name : ")]
        public string PartsProductsSubCategoryName { get; set; }
        public string SearchTerm { get; set; }

        [Display(Name = "Select Parts/Products Category")]
        public string SelectedPartsProductsCategory { get; set; }

        [Display(Name = "Parts/Products Category Name : ")]
        public string PartsProductsCategoryName { get; set; }


        public IEnumerable<SelectListItem> PartsProductsCategoryList { get; set; }

        public List<PartsProductsSubCategory> PartsProductsSubCategoryList { get; set; }
        public Pager Pager { get; set; }

    }
}
