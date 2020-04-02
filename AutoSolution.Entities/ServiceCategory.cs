using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
    public class ServiceCategory
    {
        public int ServiceCategoryId { get; set; }

        [DisplayName("Service Category Name")]
        public string ServiceCategoryName { get; set; }
        [DisplayName("Service Category Code")]
        public string ServiceCategoryCode { get; set; }
        public string  Description { get; set; }
        public bool IsDelete { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
