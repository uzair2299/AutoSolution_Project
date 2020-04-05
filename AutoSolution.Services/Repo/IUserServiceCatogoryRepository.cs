using AutoSolution.Entities;
using AutoSolution.Services.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.Repo
{
   public interface IUserServiceCatogoryRepository : IRepository<UserServiceCatogory>
    {
        List<UserServiceCatogory> SelectedServiceCategories(List<ServiceCategoryUtility> serviceCategoryUtility);
    }
}
