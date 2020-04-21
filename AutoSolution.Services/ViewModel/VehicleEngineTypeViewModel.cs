using AutoSolution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.ViewModel
{
   public  class VehicleEngineTypeViewModel
    {
        public int VehicleEngineTypeId { get; set; }
        public string EngineTypeName { get; set; }

        public List<VehicleEngineType> VehicleEngineTypeList { get; set; }
        public Pager Pager { get; set; }
    }
}
