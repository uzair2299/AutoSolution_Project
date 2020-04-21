using AutoSolution.Entities;
using AutoSolution.Services.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.IUnitOfWork
{
    public interface IAutoUnitOfWork: IDisposable
    {
        IUserRepository User { get; }
        ICityRepository City { get; }
        IProvinceRepository Province { get; }
        IServiceCategoryRepository ServiceCategory { get; }
        IUserServiceCatogoryRepository UserServiceCatogory { get; }

        IVehicleManufacturerRepository VehicleManufacturer { get; }
        IRoleRepository RoleRepository { get; }
        IVehicleModelRepository VehicleModel { get; }
        ITransmissionTypeRepository TransmissionType { get; }
        IVehicleEngineTypeRepository VehicleEngineType { get; }

        IPartsProductsCategoryRepository PartsProductsCategory { get; }
        int Complete();
    }
}
