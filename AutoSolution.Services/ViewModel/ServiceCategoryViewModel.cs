using AutoSolution.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.ViewModel
{
    public class ServiceCategoryViewModel
    {
        public int ServiceCategoryId { get; set; }

        [DisplayName("Service Category Name")]
        public string ServiceCategoryName { get; set; }
        [DisplayName("Service Category Code")]
        public string ServiceCategoryCode { get; set; }
        public string Description { get; set; }
        public bool IsDelete { get; set; }
        public string SearchTerm { get; set; }

        public List<ServiceCategory> ServiceCategoriesList { get; set; }
        public Pager Pager { get; set; }
    }
}
