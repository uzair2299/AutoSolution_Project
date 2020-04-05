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
   public  class ProvinceRepository:AutoSolutionRepository<Province>,IProvinceRepository
    {
        public ProvinceRepository(AutoSolutionContext context): base(context){ }

        public IEnumerable<SelectListItem> GetProvinces()
        {
            List<SelectListItem> items = Context.Set<Province>().OrderBy(n => n.ProvinceName).Select(n => new SelectListItem
            {
                Value = n.ProvinceId.ToString(),
                Text = n.ProvinceName
            }).ToList();

            var CityTip = new SelectListItem()
            {
                Value = (-1).ToString(),
                Text = "-------------------- Select Province ---------------------"
            };
            items.Insert(0, CityTip);
            return new SelectList(items, "value", "Text");
        }
    }
}
