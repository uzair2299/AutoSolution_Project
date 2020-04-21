using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
    public class PartsProductsCategory
    {
        public int PartsProductsCategoryId { get; set; }
        public string PartsProductsCategoryName { get; set; }
        public virtual ICollection<PartsProductsSubCategory> PartsProductsSubCategories { get; set; }


    }
}
