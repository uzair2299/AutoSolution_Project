using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoSolution.Entities;

namespace AutoSolution.Database.DataBaseContext
{
    class AutoSolutionContext: DbContext
    {
        public AutoSolutionContext() : base("name = AutoSolutionContext") { }


        public DbSet<User> User { get; set; }

    }
}

//add manually dbcontext class
//Name should be same as define in web.config 
//add dbset classes
