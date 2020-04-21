using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
    public class PartsProductsSubCategory
    {
        public int PartsProductsSubCategoryId { get; set; }
        public string PartsProductsSubCategoryName { get; set; }
        public int PartsProductCategoryId { get; set; }
        public virtual PartsProductsCategory PartsProductCategory { get; set; }
    }
}
