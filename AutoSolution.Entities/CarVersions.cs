using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
    public class CarVersion
    {
        public int CarVersionId { get; set; }
        public string CarVersionName { get; set; }
        public string EngineCapacity { get; set; }
        public bool IsDeleted { get; set; }

        public int CarModelId { get; set; }
        public virtual CarModel CarModel { get; set; }

        
        public int EngineTypeId { get; set; }
        public virtual EngineType EngineType { get; set; }


        public int TransmissionTypeId { get; set; }
        public virtual TransmissionType TransmissionType { get; set; }


        public int BodyTypeId { get; set; }
        public virtual BodyType BodyType { get; set; }

        public virtual ICollection<Version_Year_PartsProduct> Version_Year_PartsProducts { get; set; }



    }
}
