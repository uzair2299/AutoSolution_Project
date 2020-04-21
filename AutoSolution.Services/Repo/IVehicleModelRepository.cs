using AutoSolution.Entities;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.Repo
{
    public interface IVehicleModelRepository: IRepository<VehicleModel>
    {
        VehilceModelViewModel AddnewVehicleModel();
        VehilceModelViewModel GetVehicleModel(int PageNo,int TotalCount);
        VehilceModelViewModel GetVehicleModel(int PageNo, int TotalCount, string SearchTerm, string SelectedVehicleManufacturer);
        int GetVehicleModelCount(string SearchTerm, string SelectedVehicleManufacturer);
    }
}
