using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public int SupplierName { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<PartsProductSupplier> PartsProductSuppliers { get; set; }
        public  int CityId { get; set; }
        public virtual City City { get; set; }

    }
}
