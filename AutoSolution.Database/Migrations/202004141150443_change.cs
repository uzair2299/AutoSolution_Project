namespace AutoSolution.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CarModels", "CarManufacturer_VehicleManufacturerId", "dbo.VehicleManufacturers");
            DropForeignKey("dbo.CarVersions", "CarModelId", "dbo.CarModels");
            DropIndex("dbo.CarVersions", new[] { "CarModelId" });
            DropIndex("dbo.CarModels", new[] { "CarManufacturer_VehicleManufacturerId" });
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
            
            AddColumn("dbo.CarVersions", "CarModel_VehicleModelId", c => c.Int());
            CreateIndex("dbo.CarVersions", "CarModel_VehicleModelId");
            AddForeignKey("dbo.CarVersions", "CarModel_VehicleModelId", "dbo.VehicleModels", "VehicleModelId");
            DropTable("dbo.CarModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CarModels",
                c => new
                    {
                        CarModelId = c.Int(nullable: false, identity: true),
                        CarModelName = c.String(),
                        CarManufacturerId = c.Int(nullable: false),
                        CarManufacturer_VehicleManufacturerId = c.Int(),
                    })
                .PrimaryKey(t => t.CarModelId);
            
            DropForeignKey("dbo.CarVersions", "CarModel_VehicleModelId", "dbo.VehicleModels");
            DropForeignKey("dbo.VehicleModels", "VehicleManufacturerId", "dbo.VehicleManufacturers");
            DropIndex("dbo.VehicleModels", new[] { "VehicleManufacturerId" });
            DropIndex("dbo.CarVersions", new[] { "CarModel_VehicleModelId" });
            DropColumn("dbo.CarVersions", "CarModel_VehicleModelId");
            DropTable("dbo.VehicleModels");
            CreateIndex("dbo.CarModels", "CarManufacturer_VehicleManufacturerId");
            CreateIndex("dbo.CarVersions", "CarModelId");
            AddForeignKey("dbo.CarVersions", "CarModelId", "dbo.CarModels", "CarModelId", cascadeDelete: true);
            AddForeignKey("dbo.CarModels", "CarManufacturer_VehicleManufacturerId", "dbo.VehicleManufacturers", "VehicleManufacturerId");
        }
    }
}
