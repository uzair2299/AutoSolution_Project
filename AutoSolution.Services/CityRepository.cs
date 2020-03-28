using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services.Repo;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
