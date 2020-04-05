using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services.CommonServices;
using AutoSolution.Services.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services
{
    public class UserServiceCatogoryRepository : AutoSolutionRepository<UserServiceCatogory>, IUserServiceCatogoryRepository
    {
        public UserServiceCatogoryRepository(AutoSolutionContext context)
          : base(context)
        {
        }

        public List<UserServiceCatogory> SelectedServiceCategories(List<ServiceCategoryUtility> serviceCategoryUtility)
        {

            if (serviceCategoryUtility.Count >= 1 && serviceCategoryUtility != null)
            {
                List<UserServiceCatogory> USC = new List<UserServiceCatogory>();
                foreach (var item in serviceCategoryUtility)
                {
                    UserServiceCatogory userServiceCatogory = new UserServiceCatogory();
                    if (item.IsChecked)
                    {
                        userServiceCatogory.ServiceAddedDate = DateTime.Now;
                        userServiceCatogory.ServiceCategoryId = item.ServiceCategoryUtilityId;
                        userServiceCatogory.IsActive = true;
                        USC.Add(userServiceCatogory);
                    }
                }
                return USC;
            }
            else
            {
                return null;
            }
        }
    }
}
