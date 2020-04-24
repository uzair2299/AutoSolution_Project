using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services.Repo;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AutoSolution.Services
{
     public class VehicleVersionRepository: AutoSolutionRepository<VehicleVersion>, IVehicleVersionRepository
    {
        public VehicleVersionRepository(AutoSolutionContext context)
           : base(context)
    {
    }

        public VehicleVersionViewModel AddNewVehicleVerison()
        {
            VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(new AutoSolutionContext());
            TransmissionTypeRepository transmissionTypeRepository = new TransmissionTypeRepository(new AutoSolutionContext());
            VehicleEngineTypeRepository vehicleEngineTypeRepository = new VehicleEngineTypeRepository(new AutoSolutionContext());
            VehicleVersionViewModel vehicleVersionViewModel = new VehicleVersionViewModel()
            {
                VehicleManufacturerList = vehicleModelRepository.GetVehicleManufacturerDropDown(),
                VehicleModelList = vehicleModelRepository.GetVehicleModelDropDownEmpty(),
                TransmissionTypeList = transmissionTypeRepository.GetTransmissionTypeDownEmpty(),
                EngineTypeList = vehicleEngineTypeRepository.GetVehicleEngineTypeDropDownEmpty(),
            };
        return vehicleVersionViewModel;

    }

        
        
        
        
        public int GetVehicleModelCount(string SearchTerm, string SelectedVehicleModel)
        {
            int SelectedItem = Convert.ToInt32(SelectedVehicleModel);

            return AutoSolutionContext.VehicleVersions.OrderBy(x => x.VehicleVersionName).Where(x => x.VehicleVersionName.Contains(SearchTerm) && x.VehicleModelId == SelectedItem).Count();
        }

        public VehicleVersionViewModel GetVehicleVersion(int PageNo, int TotalCount)
        {
            VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(new AutoSolutionContext());
            var VehicleVersionViewModel = new VehicleVersionViewModel()
            {
                VehicleModelList = vehicleModelRepository.GetVehicleModelDropDown(),
                VehicleVersionList = AutoSolutionContext.VehicleVersions.OrderBy(x => x.VehicleVersionName).Skip((PageNo - 1) * 10).Take(10).ToList(),
                Pager = new Pager(TotalCount, PageNo, 10)
            };
            return VehicleVersionViewModel;
        }

       
        
        public VehicleVersionViewModel GetVehicleVersion(int PageNo, int TotalCount, string SearchTerm, string SelectedVehicleVersion)
        {

            if ((!string.IsNullOrEmpty(SelectedVehicleVersion)) && (!string.IsNullOrEmpty(SearchTerm)))
            {
                VehicleModelRepository vehicleModelRepository = new VehicleModelRepository(new AutoSolutionContext());
                int SelectedModel = Convert.ToInt32(SelectedVehicleVersion);
                var VehicleVersionViewModel = new VehicleVersionViewModel()
                {
                    VehicleModelList = vehicleModelRepository.GetVehicleModelDropDownEmpty(),
                    VehicleVersionList = AutoSolutionContext.VehicleVersions.OrderBy(x => x.VehicleVersionName).Where(x => x.VehicleVersionName.ToLower().Contains(SearchTerm.ToLower()) || x.VehicleModelId == SelectedModel).Skip((PageNo - 1) * 10).Take(10).ToList(),
                    Pager = new Pager(TotalCount, PageNo, 10)
                };
                return VehicleVersionViewModel;
            }
            return null;
        }

        
        
        
        public bool isExist(string GetVehicleVersion ,string SelectedVehicleModel)
        {
            int VehicleModel = Convert.ToInt32(SelectedVehicleModel);
            return AutoSolutionContext.VehicleModels.Any(x => x.VehicleModelName.Trim().ToLower() == GetVehicleVersion.Trim().ToLower() && x.VehicleModelId == VehicleModel);

        }

        public AutoSolutionContext AutoSolutionContext
        {
            get { return Context as AutoSolutionContext; }
        }
    }
}
