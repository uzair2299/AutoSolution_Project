using AutoSolution.Entities;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.Repo
{
   public interface ICityAreaRepository: IRepository<CityArea>
    {
         CityAreaViewModel AddNewCityArea();
        bool isExist(string CityAreaName, string SelectedCity);
       CityAreaViewModel GetCityArea(int PageNo, int TotalCount);
        CityAreaViewModel GetCityArea(int PageNo, int TotalCount, string SearchTerm, string SelectedCity);
        int GetCityAreaCount(string SearchTerm, string SelectedCity);
    }
}
