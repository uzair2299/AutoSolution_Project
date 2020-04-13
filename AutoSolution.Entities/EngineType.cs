using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
   public  class EngineType
    {
        public int EngineTypeId { get; set; }
        public string EngineTypeName { get; set; }

        public ICollection<CarVersion> CarVersions { get; set; }
    }
}
