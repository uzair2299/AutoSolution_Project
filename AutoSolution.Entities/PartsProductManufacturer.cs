using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
   public  class PartsProductManufacturer
    {
        public int PartsProductManufacturerId { get; set; }
        public string PartsProductManufacturerName { get; set; }
        public string PartsProductManufacturerCode { get; set; }
        public virtual ICollection<PartsProduct> PartsProducts { get; set; }

    }
}
