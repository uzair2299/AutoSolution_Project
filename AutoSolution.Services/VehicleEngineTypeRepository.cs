using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services
{
   public  class VehicleEngineTypeRepository : AutoSolutionRepository<VehicleEngineType>,IVehicleEngineTypeRepository
    
    {
        public VehicleEngineTypeRepository(AutoSolutionContext context) : base(context) { }

        public bool isExist(string VehicleEngineType)
        {
            
                return AutoSolutionContext.VehicleEngineTypes.Any(x => x.EngineTypeName.Trim().ToLower() == VehicleEngineType.Trim().ToLower());
            

        }

        public AutoSolutionContext AutoSolutionContext
        {
            get { return Context as AutoSolutionContext; }
        }
    }

}
