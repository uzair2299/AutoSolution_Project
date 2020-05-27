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
        IRoleRepository RoleRepository { get; }
        IUserRepository User { get; }
        IProvinceRepository Province { get; }
        ICityRepository City { get; }
        ICityAreaRepository CityArea { get; }
        IServiceCategoryRepository ServiceCategory { get; }
        IUserServiceCatogoryRepository UserServiceCatogory { get; }
        IVehicleManufacturerRepository VehicleManufacturer { get; }
        IVehicleModelRepository VehicleModel { get; }
        IVehicleVersionRepository VehicleVersion { get; }
        ITransmissionTypeRepository TransmissionType { get; }
        IVehicleEngineTypeRepository VehicleEngineType { get; }
        IPartsProductsCategoryRepository PartsProductsCategory { get; }
        IPartsSubCategoryRepository PartsSubCategory { get; }
        IPartsProductsRepository PartsProducts { get; }
        IPartsProductManufacturerRepository PartsProductManufacturer { get; }
        ITemplateRepository Template { get; }
        IWishListRepository WishList { get; }
        int Complete();
    }
}
