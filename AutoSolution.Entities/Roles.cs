using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
    public class Roles
    {
            public  int RolesId { get; set; }
            public  string Name { get; set; }
            public  string Description { get; set; }
            public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
