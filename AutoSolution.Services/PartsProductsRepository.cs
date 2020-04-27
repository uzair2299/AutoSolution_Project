using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services.Repo;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services
{
    public class PartsProductsRepository : AutoSolutionRepository<PartsProduct>, IPartsProductsRepository
    {
        public PartsProductsRepository(AutoSolutionContext context) : base(context) { }

        public PartsProductsViewModel AddNewPartsProducts()
        {
            VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(new AutoSolutionContext());
            PartsSubCategoryRepository partsSubCategoryRepository = new PartsSubCategoryRepository(new AutoSolutionContext());
            TransmissionTypeRepository transmissionTypeRepository = new TransmissionTypeRepository(new AutoSolutionContext());
            VehicleEngineTypeRepository vehicleEngineTypeRepository = new VehicleEngineTypeRepository(new AutoSolutionContext());
            PartsProductManufacturerRepository partsProductManufacturerRepository = new PartsProductManufacturerRepository(new AutoSolutionContext());
            PartsProductsViewModel partsProductsViewModel = new PartsProductsViewModel()
            {
                VehicleManufacturerList = vehicleModelRepository.GetVehicleManufacturerDropDown(),
                PartsProductsCategoryList = partsSubCategoryRepository.GetPartsProductCategoryDropDown(),
                PartsProductsSubCategoryList = partsSubCategoryRepository.GetPartsProductSubCategoryDropDownEmpty(),
                PartProductManufacturerList = partsProductManufacturerRepository.GetPPManufacturerDropDownEmpty(),
                VehicleModelList = vehicleModelRepository.GetVehicleModelDropDownEmpty(),
                //TransmissionTypeList = transmissionTypeRepository.GetTransmissionTypeDownEmpty(),
                //EngineTypeList = vehicleEngineTypeRepository.GetVehicleEngineTypeDropDownEmpty(),
            };
            return partsProductsViewModel;
        }

        public PartsProductsViewModel GetPartsProducts(int PageNo, int TotalCount)
        {
            var partsProductsViewModel = new PartsProductsViewModel()
            {
                PartsProductList = AutoSolutionContext.PartsProducts.OrderBy(x => x.PartsProductName).Skip((PageNo - 1) * 10).Take(10).ToList(),
                Pager = new Pager(TotalCount, PageNo, 10)

            };
            return partsProductsViewModel;
        }

        public PartsProductsViewModel GetPartsProducts(int PageNo, int TotalCount, string SearchTerm)
        {
            var partsProductsViewModel = new PartsProductsViewModel()
            {

                PartsProductList = AutoSolutionContext.PartsProducts.OrderBy(x => x.PartsProductName).Where(x => x.PartsProductName.Contains(SearchTerm)).Skip((PageNo - 1) * 10).Take(10).ToList(),
                Pager = new Pager(TotalCount, PageNo, 10)

            };

            return partsProductsViewModel;
        }

        public int GetPartsProductsCount(string SearchTerm)
        {
            throw new NotImplementedException();
        }

        public bool isExist(string GetVehicleVersion, string SelectedPartProduct)
        {
            throw new NotImplementedException();
        }

        public AutoSolutionContext AutoSolutionContext
        {
            get { return Context as AutoSolutionContext; }
        }
    }
}
