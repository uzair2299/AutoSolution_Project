﻿using AutoSolution.Entities;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AutoSolution.Services.Repo
{
    public interface IVehicleModelRepository: IRepository<VehicleModel>
    {
        VehilceModelViewModel AddnewVehicleModel();
        VehilceModelViewModel GetVehicleModel(int PageNo,int TotalCount);
        VehilceModelViewModel GetVehicleModel(int PageNo, int TotalCount, string SearchTerm, string SelectedVehicleManufacturer);
       
        int GetVehicleModelCount(string SearchTerm, string SelectedVehicleManufacturer);
        IEnumerable<SelectListItem> GetVehicleManufacturerDropDown();
        IEnumerable<SelectListItem> GetVehicleManufacturerDropDownForHome();
        IEnumerable<SelectListItem> GetVehicleModelDropDownEmptyForHome();
        IEnumerable<SelectListItem> GetVehicleModelDropDownForHome(string Id);
        IEnumerable<SelectListItem> GetVehicleModelDropDown();
        IEnumerable<SelectListItem> GetVehicleModelDropDown(string Id);
    }
}
