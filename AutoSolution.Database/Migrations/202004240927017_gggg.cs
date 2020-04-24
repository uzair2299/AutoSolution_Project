namespace AutoSolution.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gggg : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.VehicleVersions", "YearOfManufacture");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VehicleVersions", "YearOfManufacture", c => c.Int(nullable: false));
        }
    }
}
