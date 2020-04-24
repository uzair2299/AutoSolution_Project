using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services.Repo;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AutoSolution.Services
{
    public class VehicleModelRepository :AutoSolutionRepository<VehicleModel> ,IVehicleModelRepository
    {
        public VehicleModelRepository(AutoSolutionContext context)
           : base(context)
        {
        }

        public bool isExist(string VehicleMode)
        {
            return AutoSolutionContext.VehicleModels.Any(x => x.VehicleModelName.Trim().ToLower() == VehicleMode.Trim().ToLower());
        }
        public IEnumerable<SelectListItem> GetVehicleManufacturerDropDown()
        {
            List<SelectListItem> items = Context.Set<VehicleManufacturer>().OrderBy(n => n.VehicleManufacturerName).Select(n => new SelectListItem
            {
                Value = n.VehicleManufacturerId.ToString(),
                Text = n.VehicleManufacturerName
            }).ToList();

            var Tip = new SelectListItem()
            {
                Value = null,
                Text = "--------------- Select Vehicle Manufacturer ----------------"
            };
            items.Insert(0, Tip);
            return new SelectList(items, "value", "Text");
        }

        public IEnumerable<SelectListItem> GetVehicleModelDropDown()
        {
            List<SelectListItem> items = Context.Set<VehicleModel>().OrderBy(n => n.VehicleModelName).Select(n => new SelectListItem
            {
                Value = n.VehicleModelId.ToString(),
                Text = n.VehicleModelName
            }).ToList();

            var Tip = new SelectListItem()
            {
                Value = null,
                Text = "-------------- Select Vehicle Model ---------------"
            };
            items.Insert(0, Tip);
            return new SelectList(items, "value", "Text");
        }

        public IEnumerable<SelectListItem> GetVehicleModelDropDownEmpty()
        {
            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = (-1).ToString(),
                    Text = "--------------------- Select Vehicle Model ---------------------"
                }
            };
            return new SelectList(items, "value", "Text");
        }

        public IEnumerable<SelectListItem> GetVehicleModelDropDown(string Id)
        {
            int ID = Convert.ToInt32(Id);

            List<SelectListItem> items = Context.Set<VehicleModel>().OrderBy(n => n.VehicleModelName).Where(x =>x.VehicleManufacturer.VehicleManufacturerId == ID).Select(n => new SelectListItem
            {
                Value = n.VehicleModelId.ToString(),
                Text = n.VehicleModelName
            }).ToList();

            var CityTip = new SelectListItem()
            {
                Value = (-1).ToString(),
                Text = "--------------------- Select Vehicle Model ---------------------"
            };
            items.Insert(0, CityTip);
            return new SelectList(items, "value", "Text");
        }
        public VehilceModelViewModel AddnewVehicleModel()
        {
            var VehilceModelViewModel = new VehilceModelViewModel()
            {
                VehicleManufacturersList = GetVehicleManufacturerDropDown(),
            };
            return VehilceModelViewModel;
        }


        public VehilceModelViewModel GetVehicleModel(int PageNo,int TotalCount)
        {
            var VehilceModelViewModel = new VehilceModelViewModel()
            {
                VehicleManufacturersList = GetVehicleManufacturerDropDown(),
                VehicleModelsList = AutoSolutionContext.VehicleModels.OrderBy(x => x.VehicleModelName).Skip((PageNo - 1) * 10).Take(10).ToList(),
                Pager = new Pager(TotalCount, PageNo, 10)
                
        };

            return VehilceModelViewModel;

        }
        public VehilceModelViewModel GetVehicleModel(int PageNo, int TotalCount,string SearchTerm,string SelectedVehicleManufacturer)
        {
            int SelectedItem =Convert.ToInt32(SelectedVehicleManufacturer);
            var VehilceModelViewModel = new VehilceModelViewModel()
            {
                VehicleManufacturersList = GetVehicleManufacturerDropDown(),
                VehicleModelsList = AutoSolutionContext.VehicleModels.OrderBy(x => x.VehicleModelName).Where(x=>x.VehicleModelName.Contains(SearchTerm) && x.VehicleManufacturerId == SelectedItem).Skip((PageNo - 1) * 10).Take(10).ToList(),
                Pager = new Pager(TotalCount, PageNo, 10)

            };

            return VehilceModelViewModel;

        }

        public int GetVehicleModelCount(string SearchTerm, string SelectedVehicleManufacturer)
        {
            int SelectedItem = Convert.ToInt32(SelectedVehicleManufacturer);

           return AutoSolutionContext.VehicleModels.OrderBy(x => x.VehicleModelName).Where(x => x.VehicleModelName.Contains(SearchTerm) && x.VehicleManufacturerId == SelectedItem).Count();
        }
        public AutoSolutionContext AutoSolutionContext
        {
            get { return Context as AutoSolutionContext; }
        }
    }
}
