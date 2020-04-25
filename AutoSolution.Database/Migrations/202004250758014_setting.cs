namespace AutoSolution.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setting : DbMigration
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
                "dbo.PartsProducts",
                c => new
                    {
                        PartsProductId = c.Int(nullable: false, identity: true),
                        PartsProductName = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        YearOfManufacture = c.Int(nullable: false),
                        PartsProductsSubCategoryId = c.Int(nullable: false),
                        VehicleModelId = c.Int(),
                        VehicleVersionId = c.Int(nullable: false),
                        VehicleManufacturerId = c.Int(nullable: false),
                        PartsProductManufacturerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PartsProductId)
                .ForeignKey("dbo.PartsProductManufacturers", t => t.PartsProductManufacturerId, cascadeDelete: true)
                .ForeignKey("dbo.PartsProductsSubCategories", t => t.PartsProductsSubCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleManufacturers", t => t.VehicleManufacturerId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleModels", t => t.VehicleModelId)
                .ForeignKey("dbo.VehicleVersions", t => t.VehicleVersionId, cascadeDelete: true)
                .Index(t => t.PartsProductsSubCategoryId)
                .Index(t => t.VehicleModelId)
                .Index(t => t.VehicleVersionId)
                .Index(t => t.VehicleManufacturerId)
                .Index(t => t.PartsProductManufacturerId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImageName = c.String(),
                        ImagePath = c.String(),
                        ContentType = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        PartsProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.PartsProducts", t => t.PartsProductId, cascadeDelete: true)
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
            DropForeignKey("dbo.PartsProducts", "VehicleVersionId", "dbo.VehicleVersions");
            DropForeignKey("dbo.PartsProducts", "VehicleModelId", "dbo.VehicleModels");
            DropForeignKey("dbo.VehicleVersions", "VehicleModelId", "dbo.VehicleModels");
            DropForeignKey("dbo.VehicleVersions", "VehicleEngineTypeId", "dbo.VehicleEngineTypes");
            DropForeignKey("dbo.VehicleVersions", "TransmissionTypeId", "dbo.TransmissionTypes");
            DropForeignKey("dbo.VehicleModels", "VehicleManufacturerId", "dbo.VehicleManufacturers");
            DropForeignKey("dbo.PartsProducts", "VehicleManufacturerId", "dbo.VehicleManufacturers");
            DropForeignKey("dbo.PartsProductSuppliers", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Suppliers", "CityId", "dbo.Cities");
            DropForeignKey("dbo.PartsProductSuppliers", "PartsProductId", "dbo.PartsProducts");
            DropForeignKey("dbo.PartsProducts", "PartsProductsSubCategoryId", "dbo.PartsProductsSubCategories");
            DropForeignKey("dbo.PartsProductsSubCategories", "PartsProductsCategoryId", "dbo.PartsProductsCategories");
            DropForeignKey("dbo.PartsProducts", "PartsProductManufacturerId", "dbo.PartsProductManufacturers");
            DropForeignKey("dbo.Images", "PartsProductId", "dbo.PartsProducts");
            DropForeignKey("dbo.Cities", "ProvinceId", "dbo.Provinces");
            DropIndex("dbo.UserServiceCatogories", new[] { "ServiceCategoryId" });
            DropIndex("dbo.UserServiceCatogories", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "CityId" });
            DropIndex("dbo.Users", new[] { "UserTypeId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.UserRoles", new[] { "RolesId" });
            DropIndex("dbo.VehicleVersions", new[] { "TransmissionTypeId" });
            DropIndex("dbo.VehicleVersions", new[] { "VehicleEngineTypeId" });
            DropIndex("dbo.VehicleVersions", new[] { "VehicleModelId" });
            DropIndex("dbo.VehicleModels", new[] { "VehicleManufacturerId" });
            DropIndex("dbo.Suppliers", new[] { "CityId" });
            DropIndex("dbo.PartsProductSuppliers", new[] { "PartsProductId" });
            DropIndex("dbo.PartsProductSuppliers", new[] { "SupplierId" });
            DropIndex("dbo.PartsProductsSubCategories", new[] { "PartsProductsCategoryId" });
            DropIndex("dbo.Images", new[] { "PartsProductId" });
            DropIndex("dbo.PartsProducts", new[] { "PartsProductManufacturerId" });
            DropIndex("dbo.PartsProducts", new[] { "VehicleManufacturerId" });
            DropIndex("dbo.PartsProducts", new[] { "VehicleVersionId" });
            DropIndex("dbo.PartsProducts", new[] { "VehicleModelId" });
            DropIndex("dbo.PartsProducts", new[] { "PartsProductsSubCategoryId" });
            DropIndex("dbo.Cities", new[] { "ProvinceId" });
            DropTable("dbo.UserTypes");
            DropTable("dbo.ServiceCategories");
            DropTable("dbo.UserServiceCatogories");
            DropTable("dbo.Users");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
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
            DropTable("dbo.Images");
            DropTable("dbo.PartsProducts");
            DropTable("dbo.Provinces");
            DropTable("dbo.Cities");
            DropTable("dbo.BodyTypes");
        }
    }
}
