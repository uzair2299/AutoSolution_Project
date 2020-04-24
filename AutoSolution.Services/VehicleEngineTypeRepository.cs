using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AutoSolution.Services
{
   public  class VehicleEngineTypeRepository : AutoSolutionRepository<VehicleEngineType>,IVehicleEngineTypeRepository
    
    {
        public VehicleEngineTypeRepository(AutoSolutionContext context) : base(context) { }

        public bool isExist(string VehicleEngineType)
        {
            
                return AutoSolutionContext.VehicleEngineTypes.Any(x => x.EngineTypeName.Trim().ToLower() == VehicleEngineType.Trim().ToLower());
            

        }

        public IEnumerable<SelectListItem> GetVehicleEngineTypeDropDownEmpty()
        {
            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = (-1).ToString(),
                    Text = "------------------ Select Vehicle Engine Type -------------------"
                }
            };
            return new SelectList(items, "value", "Text");
        }
        public IEnumerable<SelectListItem> GetVehicleEngineTypeDropDown()
        {
            List<SelectListItem> items = Context.Set<VehicleEngineType>().OrderBy(n => n.EngineTypeName).Select(n => new SelectListItem
            {
                Value = n.VehicleEngineTypeId.ToString(),
                Text = n.EngineTypeName
            }).ToList();

            var Tip = new SelectListItem()
            {
                Value = null,
                Text = "---------------- Select Vehicle Engine Type -----------------"
            };
            items.Insert(0, Tip);
            return new SelectList(items, "value", "Text");
        }


        public AutoSolutionContext AutoSolutionContext
        {
            get { return Context as AutoSolutionContext; }
        }
    }

}
