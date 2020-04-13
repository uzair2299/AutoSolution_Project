using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
    public class PartsProduct
    {
        public int PartsProductId { get; set; }
        public string PartsProductName { get; set; }
        public DateTime AddedDate { get; set; }

        public int PartsProductCategoryId { get; set; }
        public virtual PartsProductCategory PartsProductCategory { get; set; }


        public int PartsProductManufacturerId { get; set; }
        public virtual PartsProductManufacturer PartsProductManufacturer { get; set; }
        public virtual ICollection<PartsProductSupplier> PartsProductSuppliers { get; set; }
        public virtual ICollection<Version_Year_PartsProduct> Version_Year_PartsProducts { get; set; }




    }
}
