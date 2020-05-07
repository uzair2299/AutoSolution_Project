using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services.CommonServices;
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
    public class ServiceCategoryRepository: AutoSolutionRepository<ServiceCategory>, IServiceCategoryRepository
    {
      
        public ServiceCategoryRepository(AutoSolutionContext context)
           : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetServiceCategoryDropDown()
        {
            List<SelectListItem> items = Context.Set<ServiceCategory>().OrderBy(n => n.ServiceCategoryName).Select(n => new SelectListItem
            {
                Value = n.ServiceCategoryId.ToString(),
                Text = n.ServiceCategoryName
            }).ToList();

            var CityTip = new SelectListItem()
            {
                Value = null,
                Text = "--------- Select Service Category ----------"
            };
            items.Insert(0, CityTip);
            return new SelectList(items, "value", "Text");
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


        public bool isExist(string GetServiceCategory)
        {
            return AutoSolutionContext.ServiceCategories.Any(x => x.ServiceCategoryName.Trim().ToLower() == GetServiceCategory.Trim().ToLower());
        }

        public ServiceCategoryViewModel GetServiceCategory(int PageNo, int TotalCount)
        {
            var ServiceCategoryViewModel = new ServiceCategoryViewModel()
                {
                    ServiceCategoriesList= AutoSolutionContext.ServiceCategories.OrderBy(x => x.ServiceCategoryName).Skip((PageNo - 1) * 10).Take(10).ToList(),
                    Pager = new Pager(TotalCount, PageNo, 10)

                };
            return ServiceCategoryViewModel;
        }

        public ServiceCategoryViewModel GetServiceCategory(int PageNo, int TotalCount, string SearchTerm)
        {
            var ServiceCategoryViewModel = new ServiceCategoryViewModel()
            {

                ServiceCategoriesList = AutoSolutionContext.ServiceCategories.OrderBy(x => x.ServiceCategoryName).Where(x => x.ServiceCategoryName.Contains(SearchTerm)).Skip((PageNo - 1) * 10).Take(10).ToList(),
                Pager = new Pager(TotalCount, PageNo, 10)

            };

            return ServiceCategoryViewModel;

        }



        public int GetServiceCategoryCount(string SearchTerm)
        {

            return AutoSolutionContext.ServiceCategories.OrderBy(x => x.ServiceCategoryName).Where(x => x.ServiceCategoryName.Contains(SearchTerm)).Count();
        }




        public AutoSolutionContext AutoSolutionContext
        {
            get { return Context as AutoSolutionContext; }
        }
    }
}
