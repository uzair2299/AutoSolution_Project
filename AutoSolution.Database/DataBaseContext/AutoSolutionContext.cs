using System;
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
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet <Province> Province { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<UserServiceCatogory> UserServiceCatogories { get; set; }
        public DbSet<VehicleManufacturer> VehicleManufacturers { get; set; }

        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<BodyType> BodyTypes { get; set; }
        public DbSet<TransmissionType> TransmissionTypes { get; set; }
        public DbSet<VehicleEngineType> VehicleEngineTypes { get; set; }
        public DbSet<VehicleVersion> VehicleVersions { get; set; }
        public DbSet<PartsProductsCategory> PartsProductsCategories { get; set; }
        public DbSet<PartsProductsSubCategory> PartsProductsSubCategories { get; set; }
        public DbSet<PartsProductManufacturer> PartsProductManufacturers { get; set; }
        public DbSet<PartsProduct>  PartsProducts { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}

//add manually dbcontext class
//Name should be same as define in web.config 
//add dbset classes
