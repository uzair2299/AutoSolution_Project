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
    public class CityRepository : AutoSolutionRepository<City>, ICityRepository
    {
        public CityRepository(AutoSolutionContext context)
           : base(context)
        {
        }

        public List<City> GetCityWithRespectToProvince(int Id)
        {
            Context.Configuration.ProxyCreationEnabled = false;
            var CityList = Context.Set<City>().Where(x => x.Province.ProvinceId == Id).ToList();
            return CityList;
        }

        public IEnumerable<SelectListItem> GetCities()
        {
            List<SelectListItem> items = Context.Set<City>().OrderBy(n=>n.CityName).Select(n => new SelectListItem {
                Value = n.CityId.ToString(),
                Text=n.CityName
            }).ToList();

            var CityTip = new SelectListItem()
            {
                Value = null,
                Text = "--- select country ---"
            };
            items.Insert(0, CityTip);
            return new SelectList(items, "value", "Text");
        }
    }
}
