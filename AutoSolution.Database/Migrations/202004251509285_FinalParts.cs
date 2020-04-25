namespace AutoSolution.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalParts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PartsProducts", "VehicleManufacturerId", "dbo.VehicleManufacturers");
            DropForeignKey("dbo.PartsProducts", "VehicleVersionId", "dbo.VehicleVersions");
            DropIndex("dbo.PartsProducts", new[] { "VehicleVersionId" });
            DropIndex("dbo.PartsProducts", new[] { "VehicleManufacturerId" });
            AddColumn("dbo.PartsProducts", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.PartsProducts", "startYear", c => c.Int());
            AddColumn("dbo.PartsProducts", "EndYear", c => c.Int());
            AddColumn("dbo.PartsProducts", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.PartsProducts", "ShortDescription", c => c.String());
            AddColumn("dbo.PartsProducts", "LongDescription", c => c.String());
            AlterColumn("dbo.PartsProducts", "AddedDate", c => c.DateTime());
            AlterColumn("dbo.PartsProducts", "VehicleVersionId", c => c.Int());
            AlterColumn("dbo.PartsProducts", "VehicleManufacturerId", c => c.Int());
            CreateIndex("dbo.PartsProducts", "VehicleVersionId");
            CreateIndex("dbo.PartsProducts", "VehicleManufacturerId");
            AddForeignKey("dbo.PartsProducts", "VehicleManufacturerId", "dbo.VehicleManufacturers", "VehicleManufacturerId");
            AddForeignKey("dbo.PartsProducts", "VehicleVersionId", "dbo.VehicleVersions", "VehicleVersionId");
            DropColumn("dbo.PartsProducts", "YearOfManufacture");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PartsProducts", "YearOfManufacture", c => c.Int(nullable: false));
            DropForeignKey("dbo.PartsProducts", "VehicleVersionId", "dbo.VehicleVersions");
            DropForeignKey("dbo.PartsProducts", "VehicleManufacturerId", "dbo.VehicleManufacturers");
            DropIndex("dbo.PartsProducts", new[] { "VehicleManufacturerId" });
            DropIndex("dbo.PartsProducts", new[] { "VehicleVersionId" });
            AlterColumn("dbo.PartsProducts", "VehicleManufacturerId", c => c.Int(nullable: false));
            AlterColumn("dbo.PartsProducts", "VehicleVersionId", c => c.Int(nullable: false));
            AlterColumn("dbo.PartsProducts", "AddedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.PartsProducts", "LongDescription");
            DropColumn("dbo.PartsProducts", "ShortDescription");
            DropColumn("dbo.PartsProducts", "UnitPrice");
            DropColumn("dbo.PartsProducts", "EndYear");
            DropColumn("dbo.PartsProducts", "startYear");
            DropColumn("dbo.PartsProducts", "UpdatedDate");
            CreateIndex("dbo.PartsProducts", "VehicleManufacturerId");
            CreateIndex("dbo.PartsProducts", "VehicleVersionId");
            AddForeignKey("dbo.PartsProducts", "VehicleVersionId", "dbo.VehicleVersions", "VehicleVersionId", cascadeDelete: true);
            AddForeignKey("dbo.PartsProducts", "VehicleManufacturerId", "dbo.VehicleManufacturers", "VehicleManufacturerId", cascadeDelete: true);
        }
    }
}
