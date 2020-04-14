using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
    public class VehicleModel
    {
        public int VehicleModelId { get; set; }
        public string VehicleModelName { get; set; }
        public int VehicleManufacturerId { get; set; }
        public virtual VehicleManufacturer VehicleManufacturer { get; set; }

        public ICollection<CarVersion> CarVersions { get; set; }
    }
}
