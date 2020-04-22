namespace AutoSolution.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CarVersions", "BodyTypeId", "dbo.BodyTypes");
            DropForeignKey("dbo.CarVersions", "CarModel_VehicleModelId", "dbo.VehicleModels");
            DropForeignKey("dbo.CarVersions", "EngineType_VehicleEngineTypeId", "dbo.VehicleEngineTypes");
            DropForeignKey("dbo.CarVersions", "TransmissionTypeId", "dbo.TransmissionTypes");
            DropForeignKey("dbo.Version_Year_PartsProduct", "CarVersionId", "dbo.CarVersions");
            DropForeignKey("dbo.Version_Year_PartsProduct", "CarYearOfManufactureId", "dbo.CarYearOfManufactures");
            DropForeignKey("dbo.Version_Year_PartsProduct", "PartsProductId", "dbo.PartsProducts");
            DropIndex("dbo.CarVersions", new[] { "TransmissionTypeId" });
            DropIndex("dbo.CarVersions", new[] { "BodyTypeId" });
            DropIndex("dbo.CarVersions", new[] { "CarModel_VehicleModelId" });
            DropIndex("dbo.CarVersions", new[] { "EngineType_VehicleEngineTypeId" });
            DropIndex("dbo.Version_Year_PartsProduct", new[] { "CarVersionId" });
            DropIndex("dbo.Version_Year_PartsProduct", new[] { "CarYearOfManufactureId" });
            DropIndex("dbo.Version_Year_PartsProduct", new[] { "PartsProductId" });
            CreateTable(
                "dbo.VehicleVersions",
                c => new
                    {
                        VehicleVersionId = c.Int(nullable: false, identity: true),
                        VehicleVersionName = c.String(),
                        EngineCapacity = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        VehicleModelId = c.Int(),
                        EngineTypeId = c.Int(nullable: false),
                        TransmissionTypeId = c.Int(nullable: false),
                        BodyTypeId = c.Int(nullable: false),
                        EngineType_VehicleEngineTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.VehicleVersionId)
                .ForeignKey("dbo.BodyTypes", t => t.BodyTypeId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleEngineTypes", t => t.EngineType_VehicleEngineTypeId)
                .ForeignKey("dbo.TransmissionTypes", t => t.TransmissionTypeId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleModels", t => t.VehicleModelId)
                .Index(t => t.VehicleModelId)
                .Index(t => t.TransmissionTypeId)
                .Index(t => t.BodyTypeId)
                .Index(t => t.EngineType_VehicleEngineTypeId);
            
            AddColumn("dbo.PartsProducts", "YearOfManufacture", c => c.Int(nullable: false));
            AddColumn("dbo.PartsProducts", "VehicleModelId", c => c.Int());
            AddColumn("dbo.PartsProducts", "VehicleVersionId", c => c.Int(nullable: false));
            AddColumn("dbo.PartsProducts", "VehicleManufacturerId", c => c.Int(nullable: false));
            CreateIndex("dbo.PartsProducts", "VehicleModelId");
            CreateIndex("dbo.PartsProducts", "VehicleVersionId");
            CreateIndex("dbo.PartsProducts", "VehicleManufacturerId");
            AddForeignKey("dbo.PartsProducts", "VehicleManufacturerId", "dbo.VehicleManufacturers", "VehicleManufacturerId", cascadeDelete: true);
            AddForeignKey("dbo.PartsProducts", "VehicleModelId", "dbo.VehicleModels", "VehicleModelId");
            AddForeignKey("dbo.PartsProducts", "VehicleVersionId", "dbo.VehicleVersions", "VehicleVersionId", cascadeDelete: true);
            DropTable("dbo.CarVersions");
            DropTable("dbo.Version_Year_PartsProduct");
            DropTable("dbo.CarYearOfManufactures");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CarYearOfManufactures",
                c => new
                    {
                        CarYearOfManufactureId = c.Int(nullable: false, identity: true),
                        year = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CarYearOfManufactureId);
            
            CreateTable(
                "dbo.Version_Year_PartsProduct",
                c => new
                    {
                        CarVersionId = c.Int(nullable: false),
                        CarYearOfManufactureId = c.Int(nullable: false),
                        PartsProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CarVersionId, t.CarYearOfManufactureId, t.PartsProductId });
            
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
                        EngineType_VehicleEngineTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.CarVersionId);
            
            DropForeignKey("dbo.PartsProducts", "VehicleVersionId", "dbo.VehicleVersions");
            DropForeignKey("dbo.PartsProducts", "VehicleModelId", "dbo.VehicleModels");
            DropForeignKey("dbo.VehicleVersions", "VehicleModelId", "dbo.VehicleModels");
            DropForeignKey("dbo.VehicleVersions", "TransmissionTypeId", "dbo.TransmissionTypes");
            DropForeignKey("dbo.VehicleVersions", "EngineType_VehicleEngineTypeId", "dbo.VehicleEngineTypes");
            DropForeignKey("dbo.VehicleVersions", "BodyTypeId", "dbo.BodyTypes");
            DropForeignKey("dbo.PartsProducts", "VehicleManufacturerId", "dbo.VehicleManufacturers");
            DropIndex("dbo.VehicleVersions", new[] { "EngineType_VehicleEngineTypeId" });
            DropIndex("dbo.VehicleVersions", new[] { "BodyTypeId" });
            DropIndex("dbo.VehicleVersions", new[] { "TransmissionTypeId" });
            DropIndex("dbo.VehicleVersions", new[] { "VehicleModelId" });
            DropIndex("dbo.PartsProducts", new[] { "VehicleManufacturerId" });
            DropIndex("dbo.PartsProducts", new[] { "VehicleVersionId" });
            DropIndex("dbo.PartsProducts", new[] { "VehicleModelId" });
            DropColumn("dbo.PartsProducts", "VehicleManufacturerId");
            DropColumn("dbo.PartsProducts", "VehicleVersionId");
            DropColumn("dbo.PartsProducts", "VehicleModelId");
            DropColumn("dbo.PartsProducts", "YearOfManufacture");
            DropTable("dbo.VehicleVersions");
            CreateIndex("dbo.Version_Year_PartsProduct", "PartsProductId");
            CreateIndex("dbo.Version_Year_PartsProduct", "CarYearOfManufactureId");
            CreateIndex("dbo.Version_Year_PartsProduct", "CarVersionId");
            CreateIndex("dbo.CarVersions", "EngineType_VehicleEngineTypeId");
            CreateIndex("dbo.CarVersions", "CarModel_VehicleModelId");
            CreateIndex("dbo.CarVersions", "BodyTypeId");
            CreateIndex("dbo.CarVersions", "TransmissionTypeId");
            AddForeignKey("dbo.Version_Year_PartsProduct", "PartsProductId", "dbo.PartsProducts", "PartsProductId", cascadeDelete: true);
            AddForeignKey("dbo.Version_Year_PartsProduct", "CarYearOfManufactureId", "dbo.CarYearOfManufactures", "CarYearOfManufactureId", cascadeDelete: true);
            AddForeignKey("dbo.Version_Year_PartsProduct", "CarVersionId", "dbo.CarVersions", "CarVersionId", cascadeDelete: true);
            AddForeignKey("dbo.CarVersions", "TransmissionTypeId", "dbo.TransmissionTypes", "TransmissionTypeId", cascadeDelete: true);
            AddForeignKey("dbo.CarVersions", "EngineType_VehicleEngineTypeId", "dbo.VehicleEngineTypes", "VehicleEngineTypeId");
            AddForeignKey("dbo.CarVersions", "CarModel_VehicleModelId", "dbo.VehicleModels", "VehicleModelId");
            AddForeignKey("dbo.CarVersions", "BodyTypeId", "dbo.BodyTypes", "BodyTypeId", cascadeDelete: true);
        }
    }
}
