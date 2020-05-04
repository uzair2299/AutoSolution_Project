using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.ViewModel
{
   public  class ServiceProviderWraper
    {
        public List<ServiceProviderViewModel> serviceProviderViewModelList { get; set; }
        public Pager Pager { get; set; }
    }
}
