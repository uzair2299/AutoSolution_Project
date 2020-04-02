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

        public IEnumerable<ServiceCategoryUtility> GetServiceCategories()
        {
            //var ii = _unitOfWork.ServiceCategory.GetAll();
            //List<ServiceCategoryUtility> ites = new List<ServiceCategoryUtility>();
            //foreach(var i in ii)
            //{
            //    ServiceCategoryUtility newww = new ServiceCategoryUtility();
            //    newww.serviceCategoryId = i.ServiceCategoryId;
            //    newww.serviceCategoryName = i.ServiceCategoryName;
            //    newww.serviceCategoryCode = i.ServiceCategoryCode;
            //    ites.Add(newww);
            //}

        List<ServiceCategoryUtility> items = Context.Set<ServiceCategory>().OrderBy(n => n.ServiceCategoryName).Select(n => new ServiceCategoryUtility
           {

                serviceCategoryId = n.ServiceCategoryId,
                serviceCategoryName =n.ServiceCategoryName,
                serviceCategoryCode=n.ServiceCategoryCode
            }) .ToList();
            return items;
        }
    }
}
