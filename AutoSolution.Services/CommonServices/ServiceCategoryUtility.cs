using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.CommonServices
{
   public  class ServiceCategoryUtility
    {
        public int serviceCategoryId { get; set; }

        [DisplayName("Service Category Name")]
        public string serviceCategoryName { get; set; }

        [DisplayName("Service Category Code")]
        public string serviceCategoryCode { get; set; }

        public bool IsChecked { get; set; }
    }
}
