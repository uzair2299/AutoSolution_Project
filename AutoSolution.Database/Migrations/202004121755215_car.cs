namespace AutoSolution.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class car : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VehicleManufacturers", "UpdateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.VehicleManufacturers", "IsActive", c => c.Boolean(nullable: false));
            DropColumn("dbo.VehicleManufacturers", "IsDeleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VehicleManufacturers", "IsDeleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.VehicleManufacturers", "IsActive");
            DropColumn("dbo.VehicleManufacturers", "UpdateDate");
        }
    }
}
