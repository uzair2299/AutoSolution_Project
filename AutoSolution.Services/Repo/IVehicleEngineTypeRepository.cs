using AutoSolution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AutoSolution.Services.Repo
{
   public  interface IVehicleEngineTypeRepository:IRepository<VehicleEngineType>
    {
        bool isExist(string VehicleEngineType);
        IEnumerable<SelectListItem> GetVehicleEngineTypeDropDownEmpty();
        IEnumerable<SelectListItem> GetVehicleEngineTypeDropDown();
    }
}
