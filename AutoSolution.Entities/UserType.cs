using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
    public class UserType
    {
        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }

        public string UserTypeCode { get; set; }
        public string UserTypeDescription { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
