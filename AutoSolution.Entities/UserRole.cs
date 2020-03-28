﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
    public class UserRole
    {
        public int UserRoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<User> User { get; set; }


    }
}
