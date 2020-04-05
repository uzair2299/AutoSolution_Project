﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoSolution.Entities;

namespace AutoSolution.Database.DataBaseContext
{
   public class AutoSolutionContext: DbContext
    {
        public AutoSolutionContext() : base("name = AutoSolutionContext") { }

        public DbSet<User> User { get; set; }
        public DbSet<UserType> UserRoles { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet <Province> Province { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<UserServiceCatogory> UserServiceCatogories { get; set; }

    }
}

//add manually dbcontext class
//Name should be same as define in web.config 
//add dbset classes
