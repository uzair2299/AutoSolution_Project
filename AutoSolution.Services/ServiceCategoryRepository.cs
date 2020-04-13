using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services.CommonServices;
using AutoSolution.Services.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AutoSolution.Services
{
    public class ServiceCategoryRepository: AutoSolutionRepository<ServiceCategory>, IServiceCategoryRepository
    {
      
        public ServiceCategoryRepository(AutoSolutionContext context)
           : base(context)
        {
        }

        public List<ServiceCategoryUtility> GetServiceCategories()
        {
            

            List<ServiceCategoryUtility> items = Context.Set<ServiceCategory>().OrderBy(n => n.ServiceCategoryName).Select(n => new ServiceCategoryUtility
            {

                ServiceCategoryUtilityId = n.ServiceCategoryId,
                ServiceCategoryUtilityName = n.ServiceCategoryName,
                IsChecked = false
            }).ToList();
            return items;
        }
    }
}
