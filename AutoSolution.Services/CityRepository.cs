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



        public IEnumerable<SelectListItem> GetCities(string Id)
        {
            int ID = Convert.ToInt32(Id);
            
            List<SelectListItem> items = Context.Set<City>().OrderBy(n=>n.CityName).Where(x=>x.Province.ProvinceId==ID).Select(n => new SelectListItem {
                Value = n.CityId.ToString(),
                Text = n.CityName
            }).ToList();

            var CityTip = new SelectListItem()
            {
                Value = (-1).ToString(),
                Text = "----------------------- Select City ------------------------"
            };
            items.Insert(0, CityTip);
            return new SelectList(items, "value", "Text");
        }

        public IEnumerable<SelectListItem> GetCities()
        {
            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = (-1).ToString(),
                    Text = "----------------------- Select City ------------------------"
                }
            };
            return new SelectList(items, "value", "Text");
        }
    }
}
