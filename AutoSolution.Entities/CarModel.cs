using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
    public class CarModel
    {
        public int CarModelId { get; set; }
        public string CarModelName { get; set; }
        public int CarManufacturerId { get; set; }
        public virtual VehicleManufacturer CarManufacturer { get; set; }

        public ICollection<CarVersion> CarVersions { get; set; }
    }
}
