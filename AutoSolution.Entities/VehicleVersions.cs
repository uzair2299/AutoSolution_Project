using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
    public class VehicleVersion
    {
        public int VehicleVersionId { get; set; }
        public string VehicleVersionName { get; set; }
        public string EngineCapacity { get; set; }
        public bool IsDeleted { get; set; }
        public int? startYear { get; set; }
        public int? EndYear { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
         public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }

        public int? VehicleModelId { get; set; }
        public virtual VehicleModel VehicleModel { get; set; }

        
        public int VehicleEngineTypeId { get; set; }
        public virtual VehicleEngineType VehicleEngineType { get; set; }


        public int TransmissionTypeId { get; set; }
        public virtual TransmissionType TransmissionType { get; set; }


        //public int BodyTypeId { get; set; }
        //public virtual BodyType BodyType { get; set; }
    }
}
