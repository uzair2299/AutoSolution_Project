namespace AutoSolution.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vehicleupd1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CarVersions", "EngineTypeId", "dbo.EngineTypes");
            DropIndex("dbo.CarVersions", new[] { "EngineTypeId" });
            CreateTable(
                "dbo.VehicleEngineTypes",
                c => new
                    {
                        VehicleEngineTypeId = c.Int(nullable: false, identity: true),
                        EngineTypeName = c.String(),
                    })
                .PrimaryKey(t => t.VehicleEngineTypeId);
            
            AddColumn("dbo.CarVersions", "EngineType_VehicleEngineTypeId", c => c.Int());
            CreateIndex("dbo.CarVersions", "EngineType_VehicleEngineTypeId");
            AddForeignKey("dbo.CarVersions", "EngineType_VehicleEngineTypeId", "dbo.VehicleEngineTypes", "VehicleEngineTypeId");
            DropTable("dbo.EngineTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EngineTypes",
                c => new
                    {
                        EngineTypeId = c.Int(nullable: false, identity: true),
                        EngineTypeName = c.String(),
                    })
                .PrimaryKey(t => t.EngineTypeId);
            
            DropForeignKey("dbo.CarVersions", "EngineType_VehicleEngineTypeId", "dbo.VehicleEngineTypes");
            DropIndex("dbo.CarVersions", new[] { "EngineType_VehicleEngineTypeId" });
            DropColumn("dbo.CarVersions", "EngineType_VehicleEngineTypeId");
            DropTable("dbo.VehicleEngineTypes");
            CreateIndex("dbo.CarVersions", "EngineTypeId");
            AddForeignKey("dbo.CarVersions", "EngineTypeId", "dbo.EngineTypes", "EngineTypeId", cascadeDelete: true);
        }
    }
}
