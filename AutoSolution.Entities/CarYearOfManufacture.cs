using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
    public class CarYearOfManufacture
    {
        public int CarYearOfManufactureId { get; set; }
        public DateTime year { get; set; }
        public virtual ICollection<Version_Year_PartsProduct> Version_Year_PartsProducts { get; set; }
    }
}
