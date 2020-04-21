namespace AutoSolution.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uzair : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BodyTypes",
                c => new
                    {
                        BodyTypeId = c.Int(nullable: false, identity: true),
                        BodyTypeName = c.String(),
                    })
                .PrimaryKey(t => t.BodyTypeId);
            
            CreateTable(
                "dbo.CarVersions",
                c => new
                    {
                        CarVersionId = c.Int(nullable: false, identity: true),
                        CarVersionName = c.String(),
                        EngineCapacity = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CarModelId = c.Int(nullable: false),
                        EngineTypeId = c.Int(nullable: false),
                        TransmissionTypeId = c.Int(nullable: false),
                        BodyTypeId = c.Int(nullable: false),
                        CarModel_VehicleModelId = c.Int(),
                    })
                .PrimaryKey(t => t.CarVersionId)
                .ForeignKey("dbo.BodyTypes", t => t.BodyTypeId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleModels", t => t.CarModel_VehicleModelId)
                .ForeignKey("dbo.EngineTypes", t => t.EngineTypeId, cascadeDelete: true)
                .ForeignKey("dbo.TransmissionTypes", t => t.TransmissionTypeId, cascadeDelete: true)
                .Index(t => t.EngineTypeId)
                .Index(t => t.TransmissionTypeId)
                .Index(t => t.BodyTypeId)
                .Index(t => t.CarModel_VehicleModelId);
            
            CreateTable(
                "dbo.VehicleModels",
                c => new
                    {
                        VehicleModelId = c.Int(nullable: false, identity: true),
                        VehicleModelName = c.String(),
                        VehicleManufacturerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleModelId)
                .ForeignKey("dbo.VehicleManufacturers", t => t.VehicleManufacturerId, cascadeDelete: true)
                .Index(t => t.VehicleManufacturerId);
            
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
                "dbo.EngineTypes",
                c => new
                    {
                        EngineTypeId = c.Int(nullable: false, identity: true),
                        EngineTypeName = c.String(),
                    })
                .PrimaryKey(t => t.EngineTypeId);
            
            CreateTable(
                "dbo.TransmissionTypes",
                c => new
                    {
                        TransmissionTypeId = c.Int(nullable: false, identity: true),
                        TransmissionTypeName = c.String(),
                    })
                .PrimaryKey(t => t.TransmissionTypeId);
            
            CreateTable(
                "dbo.Version_Year_PartsProduct",
                c => new
                    {
                        CarVersionId = c.Int(nullable: false),
                        CarYearOfManufactureId = c.Int(nullable: false),
                        PartsProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CarVersionId, t.CarYearOfManufactureId, t.PartsProductId })
                .ForeignKey("dbo.CarVersions", t => t.CarVersionId, cascadeDelete: true)
                .ForeignKey("dbo.CarYearOfManufactures", t => t.CarYearOfManufactureId, cascadeDelete: true)
                .ForeignKey("dbo.PartsProducts", t => t.PartsProductId, cascadeDelete: true)
                .Index(t => t.CarVersionId)
                .Index(t => t.CarYearOfManufactureId)
                .Index(t => t.PartsProductId);
            
            CreateTable(
                "dbo.CarYearOfManufactures",
                c => new
                    {
                        CarYearOfManufactureId = c.Int(nullable: false, identity: true),
                        year = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CarYearOfManufactureId);
            
            CreateTable(
                "dbo.PartsProducts",
                c => new
                    {
                        PartsProductId = c.Int(nullable: false, identity: true),
                        PartsProductName = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        PartsProductCategoryId = c.Int(nullable: false),
                        PartsProductManufacturerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PartsProductId)
                .ForeignKey("dbo.PartsProductCategories", t => t.PartsProductCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.PartsProductManufacturers", t => t.PartsProductManufacturerId, cascadeDelete: true)
                .Index(t => t.PartsProductCategoryId)
                .Index(t => t.PartsProductManufacturerId);
            
            CreateTable(
                "dbo.PartsProductCategories",
                c => new
                    {
                        PartsProductCategoryId = c.Int(nullable: false, identity: true),
                        PartsProductCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.PartsProductCategoryId);
            
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
                "dbo.Roles",
                c => new
                    {
                        RolesId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.RolesId);
            
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
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        LoginId = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        DateOfBirth = c.DateTime(),
                        PhoneNumber = c.Int(nullable: false),
                        MobileNumber = c.Int(nullable: false),
                        MobileNumber1 = c.Int(nullable: false),
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
                        UserTypeId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeId, cascadeDelete: true)
                .Index(t => t.UserTypeId)
                .Index(t => t.CityId);
            
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
                "dbo.UserTypes",
                c => new
                    {
                        UserTypeId = c.Int(nullable: false, identity: true),
                        UserTypeName = c.String(),
                        UserTypeCode = c.String(),
                        UserTypeDescription = c.String(),
                    })
                .PrimaryKey(t => t.UserTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.UserServiceCatogories", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserServiceCatogories", "ServiceCategoryId", "dbo.ServiceCategories");
            DropForeignKey("dbo.Users", "CityId", "dbo.Cities");
            DropForeignKey("dbo.UserRoles", "RolesId", "dbo.Roles");
            DropForeignKey("dbo.Version_Year_PartsProduct", "PartsProductId", "dbo.PartsProducts");
            DropForeignKey("dbo.PartsProductSuppliers", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Suppliers", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Cities", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.PartsProductSuppliers", "PartsProductId", "dbo.PartsProducts");
            DropForeignKey("dbo.PartsProducts", "PartsProductManufacturerId", "dbo.PartsProductManufacturers");
            DropForeignKey("dbo.PartsProducts", "PartsProductCategoryId", "dbo.PartsProductCategories");
            DropForeignKey("dbo.Version_Year_PartsProduct", "CarYearOfManufactureId", "dbo.CarYearOfManufactures");
            DropForeignKey("dbo.Version_Year_PartsProduct", "CarVersionId", "dbo.CarVersions");
            DropForeignKey("dbo.CarVersions", "TransmissionTypeId", "dbo.TransmissionTypes");
            DropForeignKey("dbo.CarVersions", "EngineTypeId", "dbo.EngineTypes");
            DropForeignKey("dbo.VehicleModels", "VehicleManufacturerId", "dbo.VehicleManufacturers");
            DropForeignKey("dbo.CarVersions", "CarModel_VehicleModelId", "dbo.VehicleModels");
            DropForeignKey("dbo.CarVersions", "BodyTypeId", "dbo.BodyTypes");
            DropIndex("dbo.UserServiceCatogories", new[] { "ServiceCategoryId" });
            DropIndex("dbo.UserServiceCatogories", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "CityId" });
            DropIndex("dbo.Users", new[] { "UserTypeId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.UserRoles", new[] { "RolesId" });
            DropIndex("dbo.Cities", new[] { "ProvinceId" });
            DropIndex("dbo.Suppliers", new[] { "CityId" });
            DropIndex("dbo.PartsProductSuppliers", new[] { "PartsProductId" });
            DropIndex("dbo.PartsProductSuppliers", new[] { "SupplierId" });
            DropIndex("dbo.PartsProducts", new[] { "PartsProductManufacturerId" });
            DropIndex("dbo.PartsProducts", new[] { "PartsProductCategoryId" });
            DropIndex("dbo.Version_Year_PartsProduct", new[] { "PartsProductId" });
            DropIndex("dbo.Version_Year_PartsProduct", new[] { "CarYearOfManufactureId" });
            DropIndex("dbo.Version_Year_PartsProduct", new[] { "CarVersionId" });
            DropIndex("dbo.VehicleModels", new[] { "VehicleManufacturerId" });
            DropIndex("dbo.CarVersions", new[] { "CarModel_VehicleModelId" });
            DropIndex("dbo.CarVersions", new[] { "BodyTypeId" });
            DropIndex("dbo.CarVersions", new[] { "TransmissionTypeId" });
            DropIndex("dbo.CarVersions", new[] { "EngineTypeId" });
            DropTable("dbo.UserTypes");
            DropTable("dbo.ServiceCategories");
            DropTable("dbo.UserServiceCatogories");
            DropTable("dbo.Users");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
            DropTable("dbo.Provinces");
            DropTable("dbo.Cities");
            DropTable("dbo.Suppliers");
            DropTable("dbo.PartsProductSuppliers");
            DropTable("dbo.PartsProductManufacturers");
            DropTable("dbo.PartsProductCategories");
            DropTable("dbo.PartsProducts");
            DropTable("dbo.CarYearOfManufactures");
            DropTable("dbo.Version_Year_PartsProduct");
            DropTable("dbo.TransmissionTypes");
            DropTable("dbo.EngineTypes");
            DropTable("dbo.VehicleManufacturers");
            DropTable("dbo.VehicleModels");
            DropTable("dbo.CarVersions");
            DropTable("dbo.BodyTypes");
        }
    }
}
