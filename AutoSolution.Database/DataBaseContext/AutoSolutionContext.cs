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
        public DbSet<VehicleManufacturer> CarManufacturers { get; set; }

        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<BodyType> BodyTypes { get; set; }
        public DbSet<TransmissionType> TransmissionTypes { get; set; }
        public DbSet<EngineType> EngineTypes { get; set; }
        public DbSet<CarVersion> CarVersions { get; set; }
        public DbSet<PartsProductCategory> PartsProductCategories { get; set; }
        public DbSet<PartsProduct>  PartsProducts { get; set; }
        public DbSet<Version_Year_PartsProduct> Version_Year_PartsProducts { get; set; }
        public DbSet<CarYearOfManufacture> CarYearOfManufactures { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }


    }
}

//add manually dbcontext class
//Name should be same as define in web.config 
//add dbset classes
