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
                Value = null,
                Text = "-------------------- Select Province ---------------------"
            };
            items.Insert(0, CityTip);
            return new SelectList(items, "value", "Text");
        }

        public bool isExist(string Province)
        {
            return AutoSolutionContext.Province.Any(x => x.ProvinceName.Trim().ToLower() == Province.Trim().ToLower());
        }

        public AutoSolutionContext AutoSolutionContext
        {
            get { return Context as AutoSolutionContext; }
        }
    }
}
