using AutoSolution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.ViewModel
{
   public  class InnerMostPartViewModel
    {
        public int PartsProductId { get; set; }
        public string PartsProductName { get; set; }
        public DateTime? AddedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public int? startYear { get; set; }
        public int? EndYear { get; set; }
        public decimal UnitPrice { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public List<PartsProductsSubCategory> productsSubCategoriesList { get; set; }
    }
}
