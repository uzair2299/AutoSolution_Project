using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
    public class PartsProductCategory
    {
        public int PartsProductCategoryId { get; set; }
        public string PartsProductCategoryName { get; set; }
        public ICollection<PartsProduct> PartsProducts { get; set; }


    }
}
