﻿using AutoSolution.Database.DataBaseContext;
using AutoSolution.Database.Migrations;
using AutoSolution.Entities;
using AutoSolution.Services.IUnitOfWork;
using AutoSolution.Services.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services
{
    public class UnitOfWork: IAutoUnitOfWork
    {
        private readonly AutoSolutionContext _context;
        public UnitOfWork(AutoSolutionContext context)
        {
            _context = context;
            User = new UserRepository(_context);
            City = new CityRepository(_context);
            CityArea = new CityAreaRepository(_context);
            Province = new ProvinceRepository(_context);
            ServiceCategory = new ServiceCategoryRepository(_context);
            UserServiceCatogory = new UserServiceCatogoryRepository(_context);
            VehicleManufacturer = new VehicleManufacturerRepository(_context);
            RoleRepository = new RoleRepository(_context);
            VehicleModel = new VehicleModelRepository(_context);
            TransmissionType = new TransmissionTypeRepository(_context);
            VehicleEngineType = new VehicleEngineTypeRepository(_context);
            PartsProductsCategory = new PartsProductsCategoryRepository(_context);
            PartsSubCategory = new PartsSubCategoryRepository(_context);
            VehicleVersion = new VehicleVersionRepository(_context);
            PartsProductManufacturer = new PartsProductManufacturerRepository(_context);
            PartsProducts = new PartsProductsRepository(_context);
            Template = new TemplateRepository(_context);
            WishList = new WishListRepository(_context);
            Order = new OrderRepository(_context);
            OrderDetail = new OrderDetailRepository(_context);
            OrderStatus = new OrderStatusRepository(_context);
}

        public IRoleRepository RoleRepository { get; private set; }
        public IUserRepository User { get; private set; }
        public ICityRepository City { get; private set; }
        public ICityAreaRepository CityArea { get; }
        public IProvinceRepository Province { get; private set; }
        public IServiceCategoryRepository ServiceCategory { get; private set; }
        public IUserServiceCatogoryRepository UserServiceCatogory { get; private set; }
        public IVehicleManufacturerRepository VehicleManufacturer { get; private set; }
       public  IVehicleModelRepository VehicleModel { get; private set; }
       public IVehicleVersionRepository VehicleVersion { get; private set; }
        public ITransmissionTypeRepository TransmissionType { get; private set; }
        public IVehicleEngineTypeRepository VehicleEngineType { get; private set; }
        public IPartsProductsCategoryRepository PartsProductsCategory { get; private set; }
        public IPartsSubCategoryRepository PartsSubCategory { get; private set; }
        public IPartsProductManufacturerRepository PartsProductManufacturer { get; private set; }
        public IPartsProductsRepository PartsProducts { get; private set; }
        public ITemplateRepository Template { get; private set; }
       public  IWishListRepository WishList { get; private set; }
        public IOrderRepository Order { get; private set; }
        public IOrderStatusRepository OrderStatus { get; private set; }
        public IorderDetailRepository OrderDetail { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
