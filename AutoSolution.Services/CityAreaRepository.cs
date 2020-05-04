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
    public class CityAreaRepository : AutoSolutionRepository<CityArea>, ICityAreaRepository
    {
        public CityAreaRepository(AutoSolutionContext context): base(context){}

        public CityAreaViewModel AddNewCityArea()
        {
            ProvinceRepository provinceRepository = new ProvinceRepository(new AutoSolutionContext());
           CityRepository cityRepository = new CityRepository(new AutoSolutionContext());
            CityAreaViewModel cityAreaViewModel = new CityAreaViewModel()
            {
                ProvinceList = provinceRepository.GetProvinces(),
                CityList = cityRepository.GetCities(),
            };
            return cityAreaViewModel;

        }
     

        public bool isExist(string CityAreaName, string SelectedCity)
        {
            int City = Convert.ToInt32(SelectedCity);
            return AutoSolutionContext.CityAreas.Any(x => x.CityAreaName.Trim().ToLower() == CityAreaName.Trim().ToLower() && x.CityId == City);
        }

        public CityAreaViewModel GetCityArea(int PageNo, int TotalCount)
        {
            CityRepository cityRepository = new CityRepository(new AutoSolutionContext());
            ProvinceRepository provinceRepository = new ProvinceRepository(new AutoSolutionContext());
            var cityAreaViewModel = new CityAreaViewModel()
            {
                ProvinceList = provinceRepository.GetProvinces(),
                CityList = cityRepository.GetCities(),
                CityAreaList = AutoSolutionContext.CityAreas.OrderBy(x => x.CityAreaName).Skip((PageNo - 1) * 10).Take(10).ToList(),
                Pager = new Pager(TotalCount, PageNo, 10)
            };
            return cityAreaViewModel;
        }

        public int GetCityAreaCount(string SearchTerm, string SelectedCity)
        {
            int SelectedItem = Convert.ToInt32(SelectedCity);

            return AutoSolutionContext.CityAreas.OrderBy(x => x.CityAreaName).Where(x => x.CityAreaName.Contains(SearchTerm) && x.CityId == SelectedItem).Count();
        }
        public CityAreaViewModel GetCityArea(int PageNo, int TotalCount, string SearchTerm, string SelectedCity)
        {

            if ((!string.IsNullOrEmpty(SelectedCity)) && (!string.IsNullOrEmpty(SearchTerm)))
            {
                ProvinceRepository provinceRepository = new ProvinceRepository(new AutoSolutionContext());
                CityRepository cityRepository = new CityRepository(new AutoSolutionContext());
                int Selecteditem = Convert.ToInt32(SelectedCity);
                var cityAreaViewModel = new CityAreaViewModel()
                {
                    ProvinceList = provinceRepository.GetProvinces(),
                    CityList = cityRepository.GetCities(),
                    CityAreaList = AutoSolutionContext.CityAreas.OrderBy(x => x.CityAreaName).Where(x => x.CityAreaName.ToLower().Contains(SearchTerm.ToLower()) && x.CityId == Selecteditem).Skip((PageNo - 1) * 10).Take(10).ToList(),
                    Pager = new Pager(TotalCount, PageNo, 10)
                };
                return cityAreaViewModel;
            }
            return null;
        }
        public AutoSolutionContext AutoSolutionContext
        {
            get { return Context as AutoSolutionContext; }
        }
    }
}
