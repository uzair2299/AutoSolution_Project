﻿namespace AutoSolution.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newwww : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BodyTypes",
                c => new
                    {
                        BodyTypeId = c.Int(nullable: false, identity: true),
                        BodyTypeName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.BodyTypeId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                        CityCode = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                        ProvinceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId, cascadeDelete: true)
                .Index(t => t.ProvinceId);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        ProvinceId = c.Int(nullable: false, identity: true),
                        ProvinceName = c.String(),
                        ProvinceCode = c.String(),
                        AddedBy = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProvinceId);
            
            CreateTable(
                "dbo.CityAreas",
                c => new
                    {
                        CityAreaID = c.Int(nullable: false, identity: true),
                        CityAreaName = c.String(),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CityAreaID)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImageName = c.String(),
                        ImagePath = c.String(),
                        ContentType = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ImageId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        PartsProductId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        ProductUnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemQuanitiyPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductUnitPriceAfterDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.PartsProductId, t.OrderId })
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.PartsProducts", t => t.PartsProductId, cascadeDelete: true)
                .Index(t => t.PartsProductId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        First_Name = c.String(),
                        Last_Name = c.String(),
                        MobileNumber = c.String(),
                        MobileNumberCode = c.String(),
                        MobileIsConfirmed = c.Boolean(nullable: false),
                        ShippingAddress = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                        OrderStatusId = c.Int(nullable: false),
                        TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.Int(),
                        CityId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.OrderStatus", t => t.OrderStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.OrderStatusId)
                .Index(t => t.UserId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        OrderStatusId = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.OrderStatusId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        LoginId = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        DateOfBirth = c.DateTime(),
                        PhoneNumber = c.String(),
                        MobileNumber = c.String(),
                        MobileNumber1 = c.String(),
                        Email = c.String(),
                        EmailSecondary = c.String(),
                        IsConfrimEmail = c.Boolean(nullable: false),
                        EmailSendCounter = c.Int(nullable: false),
                        EmailSendTime = c.DateTime(),
                        Password = c.String(),
                        ConfrimPassword = c.String(),
                        PasswordCount = c.Int(nullable: false),
                        Address = c.String(),
                        ImagePath = c.String(),
                        RegistrationDate = c.DateTime(),
                        LastUpdateDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        IsTermAndConditionAccepted = c.Boolean(nullable: false),
                        RememberMe = c.Boolean(nullable: false),
                        ActivetionCode = c.Guid(),
                        OTP = c.String(),
                        CityId = c.Int(nullable: false),
                        CityAreaID = c.Int(),
                        BusinessDescription = c.String(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.CityAreas", t => t.CityAreaID)
                .Index(t => t.CityId)
                .Index(t => t.CityAreaID);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        RolesId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        AddedDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.RolesId, t.UserId })
                .ForeignKey("dbo.Roles", t => t.RolesId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RolesId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RolesId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.RolesId);
            
            CreateTable(
                "dbo.UserServiceCatogories",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        ServiceCategoryId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        IsDeleteTime = c.DateTime(),
                        ServiceAddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.ServiceCategoryId })
                .ForeignKey("dbo.ServiceCategories", t => t.ServiceCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ServiceCategoryId);
            
            CreateTable(
                "dbo.ServiceCategories",
                c => new
                    {
                        ServiceCategoryId = c.Int(nullable: false, identity: true),
                        ServiceCategoryName = c.String(),
                        ServiceCategoryCode = c.String(),
                        Description = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceCategoryId);
            
            CreateTable(
                "dbo.PartsProducts",
                c => new
                    {
                        PartsProductId = c.Int(nullable: false, identity: true),
                        PartsProductName = c.String(),
                        AddedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        startYear = c.Int(),
                        EndYear = c.Int(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ShortDescription = c.String(),
                        LongDescription = c.String(),
                        PartsProductsSubCategoryId = c.Int(nullable: false),
                        VehicleModelId = c.Int(),
                        VehicleManufacturerId = c.Int(),
                        PartsProductManufacturerId = c.Int(),
                    })
                .PrimaryKey(t => t.PartsProductId)
                .ForeignKey("dbo.PartsProductManufacturers", t => t.PartsProductManufacturerId)
                .ForeignKey("dbo.PartsProductsSubCategories", t => t.PartsProductsSubCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleManufacturers", t => t.VehicleManufacturerId)
                .ForeignKey("dbo.VehicleModels", t => t.VehicleModelId)
                .Index(t => t.PartsProductsSubCategoryId)
                .Index(t => t.VehicleModelId)
                .Index(t => t.VehicleManufacturerId)
                .Index(t => t.PartsProductManufacturerId);
            
            CreateTable(
                "dbo.PartProductImages",
                c => new
                    {
                        ImageId = c.Int(nullable: false),
                        PartsProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ImageId, t.PartsProductId })
                .ForeignKey("dbo.Images", t => t.ImageId, cascadeDelete: true)
                .ForeignKey("dbo.PartsProducts", t => t.PartsProductId, cascadeDelete: true)
                .Index(t => t.ImageId)
                .Index(t => t.PartsProductId);
            
            CreateTable(
                "dbo.PartsProductManufacturers",
                c => new
                    {
                        PartsProductManufacturerId = c.Int(nullable: false, identity: true),
                        PartsProductManufacturerName = c.String(),
                        PartsProductManufacturerCode = c.String(),
                    })
                .PrimaryKey(t => t.PartsProductManufacturerId);
            
            CreateTable(
                "dbo.PartsProductsSubCategories",
                c => new
                    {
                        PartsProductsSubCategoryId = c.Int(nullable: false, identity: true),
                        PartsProductsSubCategoryName = c.String(),
                        PartsProductsCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PartsProductsSubCategoryId)
                .ForeignKey("dbo.PartsProductsCategories", t => t.PartsProductsCategoryId, cascadeDelete: true)
                .Index(t => t.PartsProductsCategoryId);
            
            CreateTable(
                "dbo.PartsProductsCategories",
                c => new
                    {
                        PartsProductsCategoryId = c.Int(nullable: false, identity: true),
                        PartsProductsCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.PartsProductsCategoryId);
            
            CreateTable(
                "dbo.PartsProductSuppliers",
                c => new
                    {
                        SupplierId = c.Int(nullable: false),
                        PartsProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SupplierId, t.PartsProductId })
                .ForeignKey("dbo.PartsProducts", t => t.PartsProductId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId)
                .Index(t => t.PartsProductId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        SupplierName = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierId)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.VehicleManufacturers",
                c => new
                    {
                        VehicleManufacturerId = c.Int(nullable: false, identity: true),
                        VehicleManufacturerName = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleManufacturerId);
            
            CreateTable(
                "dbo.VehicleModels",
                c => new
                    {
                        VehicleModelId = c.Int(nullable: false, identity: true),
                        VehicleModelName = c.String(),
                        VehicleManufacturerId = c.Int(nullable: false),
                        YearOfManufacture = c.Int(),
                    })
                .PrimaryKey(t => t.VehicleModelId)
                .ForeignKey("dbo.VehicleManufacturers", t => t.VehicleManufacturerId, cascadeDelete: true)
                .Index(t => t.VehicleManufacturerId);
            
            CreateTable(
                "dbo.VehicleVersions",
                c => new
                    {
                        VehicleVersionId = c.Int(nullable: false, identity: true),
                        VehicleVersionName = c.String(),
                        EngineCapacity = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        startYear = c.Int(),
                        EndYear = c.Int(),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        AddedBy = c.String(),
                        UpdatedBy = c.String(),
                        VehicleModelId = c.Int(),
                        VehicleEngineTypeId = c.Int(nullable: false),
                        TransmissionTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleVersionId)
                .ForeignKey("dbo.TransmissionTypes", t => t.TransmissionTypeId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleEngineTypes", t => t.VehicleEngineTypeId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleModels", t => t.VehicleModelId)
                .Index(t => t.VehicleModelId)
                .Index(t => t.VehicleEngineTypeId)
                .Index(t => t.TransmissionTypeId);
            
            CreateTable(
                "dbo.TransmissionTypes",
                c => new
                    {
                        TransmissionTypeId = c.Int(nullable: false, identity: true),
                        TransmissionTypeName = c.String(),
                        ShortCode = c.String(),
                        Description = c.String(),
                        AddedBy = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TransmissionTypeId);
            
            CreateTable(
                "dbo.VehicleEngineTypes",
                c => new
                    {
                        VehicleEngineTypeId = c.Int(nullable: false, identity: true),
                        EngineTypeName = c.String(),
                    })
                .PrimaryKey(t => t.VehicleEngineTypeId);
            
            CreateTable(
                "dbo.Templates",
                c => new
                    {
                        TemplateId = c.Int(nullable: false, identity: true),
                        TemplateShortCode = c.String(),
                        TemplateTitle = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedTime = c.DateTime(nullable: false),
                        TemplateBody = c.String(unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.TemplateId);
            
            CreateTable(
                "dbo.WishLists",
                c => new
                    {
                        WishListId = c.Int(nullable: false, identity: true),
                        PartsProductId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.WishListId)
                .ForeignKey("dbo.PartsProducts", t => t.PartsProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.PartsProductId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WishLists", "UserId", "dbo.Users");
            DropForeignKey("dbo.WishLists", "PartsProductId", "dbo.PartsProducts");
            DropForeignKey("dbo.OrderDetails", "PartsProductId", "dbo.PartsProducts");
            DropForeignKey("dbo.PartsProducts", "VehicleModelId", "dbo.VehicleModels");
            DropForeignKey("dbo.VehicleVersions", "VehicleModelId", "dbo.VehicleModels");
            DropForeignKey("dbo.VehicleVersions", "VehicleEngineTypeId", "dbo.VehicleEngineTypes");
            DropForeignKey("dbo.VehicleVersions", "TransmissionTypeId", "dbo.TransmissionTypes");
            DropForeignKey("dbo.VehicleModels", "VehicleManufacturerId", "dbo.VehicleManufacturers");
            DropForeignKey("dbo.PartsProducts", "VehicleManufacturerId", "dbo.VehicleManufacturers");
            DropForeignKey("dbo.PartsProductSuppliers", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Suppliers", "CityId", "dbo.Cities");
            DropForeignKey("dbo.PartsProductSuppliers", "PartsProductId", "dbo.PartsProducts");
            DropForeignKey("dbo.PartsProductsSubCategories", "PartsProductsCategoryId", "dbo.PartsProductsCategories");
            DropForeignKey("dbo.PartsProducts", "PartsProductsSubCategoryId", "dbo.PartsProductsSubCategories");
            DropForeignKey("dbo.PartsProducts", "PartsProductManufacturerId", "dbo.PartsProductManufacturers");
            DropForeignKey("dbo.PartProductImages", "PartsProductId", "dbo.PartsProducts");
            DropForeignKey("dbo.PartProductImages", "ImageId", "dbo.Images");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserServiceCatogories", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserServiceCatogories", "ServiceCategoryId", "dbo.ServiceCategories");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RolesId", "dbo.Roles");
            DropForeignKey("dbo.Users", "CityAreaID", "dbo.CityAreas");
            DropForeignKey("dbo.Users", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Orders", "OrderStatusId", "dbo.OrderStatus");
            DropForeignKey("dbo.Orders", "CityId", "dbo.Cities");
            DropForeignKey("dbo.CityAreas", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Cities", "ProvinceId", "dbo.Provinces");
            DropIndex("dbo.WishLists", new[] { "UserId" });
            DropIndex("dbo.WishLists", new[] { "PartsProductId" });
            DropIndex("dbo.VehicleVersions", new[] { "TransmissionTypeId" });
            DropIndex("dbo.VehicleVersions", new[] { "VehicleEngineTypeId" });
            DropIndex("dbo.VehicleVersions", new[] { "VehicleModelId" });
            DropIndex("dbo.VehicleModels", new[] { "VehicleManufacturerId" });
            DropIndex("dbo.Suppliers", new[] { "CityId" });
            DropIndex("dbo.PartsProductSuppliers", new[] { "PartsProductId" });
            DropIndex("dbo.PartsProductSuppliers", new[] { "SupplierId" });
            DropIndex("dbo.PartsProductsSubCategories", new[] { "PartsProductsCategoryId" });
            DropIndex("dbo.PartProductImages", new[] { "PartsProductId" });
            DropIndex("dbo.PartProductImages", new[] { "ImageId" });
            DropIndex("dbo.PartsProducts", new[] { "PartsProductManufacturerId" });
            DropIndex("dbo.PartsProducts", new[] { "VehicleManufacturerId" });
            DropIndex("dbo.PartsProducts", new[] { "VehicleModelId" });
            DropIndex("dbo.PartsProducts", new[] { "PartsProductsSubCategoryId" });
            DropIndex("dbo.UserServiceCatogories", new[] { "ServiceCategoryId" });
            DropIndex("dbo.UserServiceCatogories", new[] { "UserId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.UserRoles", new[] { "RolesId" });
            DropIndex("dbo.Users", new[] { "CityAreaID" });
            DropIndex("dbo.Users", new[] { "CityId" });
            DropIndex("dbo.Orders", new[] { "CityId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "OrderStatusId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.OrderDetails", new[] { "PartsProductId" });
            DropIndex("dbo.CityAreas", new[] { "CityId" });
            DropIndex("dbo.Cities", new[] { "ProvinceId" });
            DropTable("dbo.WishLists");
            DropTable("dbo.Templates");
            DropTable("dbo.VehicleEngineTypes");
            DropTable("dbo.TransmissionTypes");
            DropTable("dbo.VehicleVersions");
            DropTable("dbo.VehicleModels");
            DropTable("dbo.VehicleManufacturers");
            DropTable("dbo.Suppliers");
            DropTable("dbo.PartsProductSuppliers");
            DropTable("dbo.PartsProductsCategories");
            DropTable("dbo.PartsProductsSubCategories");
            DropTable("dbo.PartsProductManufacturers");
            DropTable("dbo.PartProductImages");
            DropTable("dbo.PartsProducts");
            DropTable("dbo.ServiceCategories");
            DropTable("dbo.UserServiceCatogories");
            DropTable("dbo.Roles");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users");
            DropTable("dbo.OrderStatus");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Images");
            DropTable("dbo.CityAreas");
            DropTable("dbo.Provinces");
            DropTable("dbo.Cities");
            DropTable("dbo.BodyTypes");
        }
    }
}
