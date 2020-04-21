using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services.Repo;


namespace AutoSolution.Services
{
    public class VehicleManufacturerRepository : AutoSolutionRepository<VehicleManufacturer>, IVehicleManufacturerRepository
    {
        public VehicleManufacturerRepository(AutoSolutionContext context) : base(context) { }
    }
}
