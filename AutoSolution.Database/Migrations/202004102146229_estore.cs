namespace AutoSolution.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class estore : DbMigration
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
                    })
                .PrimaryKey(t => t.CarVersionId)
                .ForeignKey("dbo.BodyTypes", t => t.BodyTypeId, cascadeDelete: true)
                .ForeignKey("dbo.CarModels", t => t.CarModelId, cascadeDelete: true)
                .ForeignKey("dbo.EngineTypes", t => t.EngineTypeId, cascadeDelete: true)
                .ForeignKey("dbo.TransmissionTypes", t => t.TransmissionTypeId, cascadeDelete: true)
                .Index(t => t.CarModelId)
                .Index(t => t.EngineTypeId)
                .Index(t => t.TransmissionTypeId)
                .Index(t => t.BodyTypeId);
            
            CreateTable(
                "dbo.CarModels",
                c => new
                    {
                        CarModelId = c.Int(nullable: false, identity: true),
                        CarModelName = c.String(),
                        CarManufacturerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CarModelId)
                .ForeignKey("dbo.CarManufacturers", t => t.CarManufacturerId, cascadeDelete: true)
                .Index(t => t.CarManufacturerId);
            
            CreateTable(
                "dbo.CarManufacturers",
                c => new
                    {
                        CarManufacturerId = c.Int(nullable: false, identity: true),
                        CarManufacturerName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CarManufacturerId);
            
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
                    })
                .PrimaryKey(t => t.PartsProductId)
                .ForeignKey("dbo.PartsProductCategories", t => t.PartsProductCategoryId, cascadeDelete: true)
                .Index(t => t.PartsProductCategoryId);
            
            CreateTable(
                "dbo.PartsProductCategories",
                c => new
                    {
                        PartsProductCategoryId = c.Int(nullable: false, identity: true),
                        PartsProductCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.PartsProductCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Version_Year_PartsProduct", "PartsProductId", "dbo.PartsProducts");
            DropForeignKey("dbo.PartsProducts", "PartsProductCategoryId", "dbo.PartsProductCategories");
            DropForeignKey("dbo.Version_Year_PartsProduct", "CarYearOfManufactureId", "dbo.CarYearOfManufactures");
            DropForeignKey("dbo.Version_Year_PartsProduct", "CarVersionId", "dbo.CarVersions");
            DropForeignKey("dbo.CarVersions", "TransmissionTypeId", "dbo.TransmissionTypes");
            DropForeignKey("dbo.CarVersions", "EngineTypeId", "dbo.EngineTypes");
            DropForeignKey("dbo.CarVersions", "CarModelId", "dbo.CarModels");
            DropForeignKey("dbo.CarModels", "CarManufacturerId", "dbo.CarManufacturers");
            DropForeignKey("dbo.CarVersions", "BodyTypeId", "dbo.BodyTypes");
            DropIndex("dbo.PartsProducts", new[] { "PartsProductCategoryId" });
            DropIndex("dbo.Version_Year_PartsProduct", new[] { "PartsProductId" });
            DropIndex("dbo.Version_Year_PartsProduct", new[] { "CarYearOfManufactureId" });
            DropIndex("dbo.Version_Year_PartsProduct", new[] { "CarVersionId" });
            DropIndex("dbo.CarModels", new[] { "CarManufacturerId" });
            DropIndex("dbo.CarVersions", new[] { "BodyTypeId" });
            DropIndex("dbo.CarVersions", new[] { "TransmissionTypeId" });
            DropIndex("dbo.CarVersions", new[] { "EngineTypeId" });
            DropIndex("dbo.CarVersions", new[] { "CarModelId" });
            DropTable("dbo.PartsProductCategories");
            DropTable("dbo.PartsProducts");
            DropTable("dbo.CarYearOfManufactures");
            DropTable("dbo.Version_Year_PartsProduct");
            DropTable("dbo.TransmissionTypes");
            DropTable("dbo.EngineTypes");
            DropTable("dbo.CarManufacturers");
            DropTable("dbo.CarModels");
            DropTable("dbo.CarVersions");
            DropTable("dbo.BodyTypes");
        }
    }
}
