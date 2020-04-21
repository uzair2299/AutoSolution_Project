using AutoSolution.Entities;
using AutoSolution.Services.CommonServices;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AutoSolution.Services.Repo
{
   public interface IServiceCategoryRepository:IRepository<ServiceCategory>
    {
        List<ServiceCategoryUtility> GetServiceCategories();
        bool isExist(string ServiceCategory);

        ServiceCategoryViewModel GetServiceCategory(int PageNo, int TotalCount);

        ServiceCategoryViewModel GetServiceCategory(int PageNo, int TotalCount, string SearchTerm);

        int GetServiceCategoryCount(string SearchTerm);
    }
}
