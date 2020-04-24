using AutoSolution.Entities;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AutoSolution.Services.Repo
{
    public interface IVehicleVersionRepository: IRepository<VehicleVersion>
    {
        VehicleVersionViewModel AddNewVehicleVerison();
        VehicleVersionViewModel GetVehicleVersion(int PageNo, int TotalCount);
        VehicleVersionViewModel GetVehicleVersion(int PageNo, int TotalCount, string SearchTerm, string SelectedVehicleModel);
        int GetVehicleModelCount(string SearchTerm, string SelectedVehicleModel);
        bool isExist(string GetVehicleVersion, string SelectedVehicleModel);
        
    }
}
