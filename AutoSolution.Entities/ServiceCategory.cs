using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
    public class ServiceCategory
    {
        public int ServiceCategoryId { get; set; }
        public string ServiceCategoryName { get; set; }
        public string ServiceCategoryCode { get; set; }
        public string  Description { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
