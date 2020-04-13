namespace AutoSolution.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CarModels", "CarManufacturerId", "dbo.CarManufacturers");
            DropIndex("dbo.CarModels", new[] { "CarManufacturerId" });
            CreateTable(
                "dbo.VehicleManufacturers",
                c => new
                    {
                        VehicleManufacturerId = c.Int(nullable: false, identity: true),
                        CarManufacturerName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleManufacturerId);
            
            AddColumn("dbo.CarModels", "CarManufacturer_VehicleManufacturerId", c => c.Int());
            CreateIndex("dbo.CarModels", "CarManufacturer_VehicleManufacturerId");
            AddForeignKey("dbo.CarModels", "CarManufacturer_VehicleManufacturerId", "dbo.VehicleManufacturers", "VehicleManufacturerId");
            DropTable("dbo.CarManufacturers");
        }
        
        public override void Down()
        {
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
            
            DropForeignKey("dbo.CarModels", "CarManufacturer_VehicleManufacturerId", "dbo.VehicleManufacturers");
            DropIndex("dbo.CarModels", new[] { "CarManufacturer_VehicleManufacturerId" });
            DropColumn("dbo.CarModels", "CarManufacturer_VehicleManufacturerId");
            DropTable("dbo.VehicleManufacturers");
            CreateIndex("dbo.CarModels", "CarManufacturerId");
            AddForeignKey("dbo.CarModels", "CarManufacturerId", "dbo.CarManufacturers", "CarManufacturerId", cascadeDelete: true);
        }
    }
}
