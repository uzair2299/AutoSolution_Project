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
        public int PartsProductsCategoryId { get; set; }
        public virtual PartsProductsCategory PartsProductsCategory { get; set; }
        public virtual ICollection<PartsProduct> PartsProducts { get; set; }
    }
}
