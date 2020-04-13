using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
    public class VehicleManufacturer
    {
        public int VehicleManufacturerId { get; set; }
        public string VehicleManufacturerName { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsActive { get; set; }
    }
}
