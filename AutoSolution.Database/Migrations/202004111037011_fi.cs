namespace AutoSolution.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VehicleManufacturers", "VehicleManufacturerName", c => c.String());
            DropColumn("dbo.VehicleManufacturers", "CarManufacturerName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VehicleManufacturers", "CarManufacturerName", c => c.String());
            DropColumn("dbo.VehicleManufacturers", "VehicleManufacturerName");
        }
    }
}
