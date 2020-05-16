using AutoSolution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.ViewModel
{
   public  class ServiceProviderWraperForHome
    {
        public ServiceProviderWraperForHome()
        {
            FindYourMechanicViewModel = new FindYourMechanicViewModel();
            ServiceCategoryName = new ServiceCategory();
        }
        public List<ServiceProviderViewModel> serviceProviderViewModelList { get; set; }
        public List<ServiceCategory> ServiceCategoriesList { get; set; }
        public ServiceCategory ServiceCategoryName { get; set; }
        public FindYourMechanicViewModel FindYourMechanicViewModel { get; set; }
        public Pager Pager { get; set; }
    }
}
