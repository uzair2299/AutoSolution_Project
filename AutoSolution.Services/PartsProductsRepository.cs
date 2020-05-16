using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services.Repo;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public PartProductwraperForHome GetPartsProducts(int PageNo, int TotalCount, int id)
        {
            VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(new AutoSolutionContext());

            PartsSubCategoryRepository partsSubCategoryRepository = new PartsSubCategoryRepository(new AutoSolutionContext());
            PartProductwraperForHome partProductwraperForHome = new PartProductwraperForHome()
            {

                FindYourPart =
                {
                    VehicleManufacturersList = vehicleModelRepository.GetVehicleManufacturerDropDownForHome(),
                    VehicleModelsList = vehicleModelRepository.GetVehicleModelDropDownEmptyForHome(),
                    PartsProductsCategoryList = partsSubCategoryRepository.GetPartsProductCategoryDropDown(),
                    PartsProductsSubCategoryList = partsSubCategoryRepository.GetPartsProductSubCategoryDropDownEmpty()
                },
                PartsProductsCategory = AutoSolutionContext.PartsProductsCategories.Where(x => x.PartsProductsCategoryId == id).FirstOrDefault(),
                PartsProductsViewModelsList =
                (from ppsc in AutoSolutionContext.PartsProductsSubCategories
                 join pp in AutoSolutionContext.PartsProducts
                 on ppsc.PartsProductsSubCategoryId equals pp.PartsProductsSubCategoryId
                 where id==ppsc.PartsProductsCategoryId
                 orderby pp.AddedDate
                 select new PartsProductsViewModel()
                 {
                     PartsProductName = pp.PartsProductName,
                     UnitPrice = pp.UnitPrice,
                     ShortDescription = pp.ShortDescription,
                     VehicleManufacturerName = pp.VehicleManufacturer.VehicleManufacturerName,
                     VehicleModelName = pp.VehicleModel.VehicleModelName,
                     startYear = pp.startYear,
                     EndYear = pp.EndYear
                 }).Skip((PageNo - 1) * 12).Take(12).ToList(),
                Pager = new Pager(TotalCount, PageNo, 12)
            };
            return partProductwraperForHome;
        }
        public int GetPartProductCountWRTCategory(string id)
        {
            int Id = Convert.ToInt32(id);
            return (from ppsc in AutoSolutionContext.PartsProductsSubCategories
                    join pp in AutoSolutionContext.PartsProducts
                    on ppsc.PartsProductsSubCategoryId equals pp.PartsProductsSubCategoryId
                    where Id == ppsc.PartsProductsCategoryId
                    select new Object() { }).Count();
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

        public OuterMostPartsViewModel GetPartsProductForHome()
        {


            PartsProductsCategoryRepository partsProductsCategoryRepository = new PartsProductsCategoryRepository(new AutoSolutionContext());

            PartsSubCategoryRepository partsSubCategoryRepository = new PartsSubCategoryRepository(new AutoSolutionContext());

            //OuterMostPartsViewModel outerMostPartsViewModel = new OuterMostPartsViewModel()
            //{
            //    OuterpartViewModelsList = AutoSolutionContext.PartsProductsCategories.Select(x => new OuterPartViewModel()
            //    {
            //        PartsProductsCategoryId = x.PartsProductsCategoryId,
            //        PartsProductsCategoryName = x.PartsProductsCategoryName,
            //        partInnerViewModelList = x.PartsProductsSubCategories.Select(y => new InnerPartViewModel()
            //        {
            //            PartsProductsSubCategoryId = y.PartsProductsSubCategoryId,
            //            PartsProductsSubCategoryName = y.PartsProductsSubCategoryName,
            //            mostInnertPartViewModelList = y.PartsProducts.Select(z => new InnerMostPartViewModel
            //            {
            //                PartsProductId = z.PartsProductId,
            //                PartsProductName = z.PartsProductName
            //            }).ToList()
            //        }).ToList()
            //    }).ToList()
            //};


            OuterMostPartsViewModel outerMostPartsViewModel = new OuterMostPartsViewModel()
            {
                OuterpartViewModelsList = AutoSolutionContext.PartsProductsCategories.Select(x => new OuterPartViewModel()
                {
                    PartsProductsCategoryId = x.PartsProductsCategoryId,
                    PartsProductsCategoryName = x.PartsProductsCategoryName,
                    partInnerViewModelList = x.PartsProductsSubCategories.OrderBy(sub=>sub.PartsProductsSubCategoryName).Select(y => new InnerPartViewModel()
                    {
                        PartsProductsSubCategoryId = y.PartsProductsSubCategoryId,
                        PartsProductsSubCategoryName = y.PartsProductsSubCategoryName,
                    }).ToList(),
                    PartsProductsViewModelsList = (from sub in x.PartsProductsSubCategories
                                                   join pp in AutoSolutionContext.PartsProducts
                                                   on sub.PartsProductsSubCategoryId equals pp.PartsProductsSubCategoryId
                                                   orderby pp.PartsProductName
                                                   //where sub.PartsProductsSubCategoryId ==pp.PartsProductsSubCategoryId
                                                   select new PartsProductsViewModel()
                                                   {
                                                       PartsProductId=pp.PartsProductId,
                                                       PartsProductName = pp.PartsProductName,
                                                       UnitPrice=pp.UnitPrice,
                                                       ShortDescription=pp.ShortDescription,
                                                       VehicleManufacturerName=pp.VehicleManufacturer.VehicleManufacturerName,
                                                       VehicleModelName=pp.VehicleModel.VehicleModelName,
                                                       startYear=pp.startYear,
                                                       EndYear=pp.EndYear
                                                   }).Take(8).ToList()
                }).ToList()
            };
            return outerMostPartsViewModel;
        

        }

        public AutoSolutionContext AutoSolutionContext
        {
            get { return Context as AutoSolutionContext; }
        }
    }
}
