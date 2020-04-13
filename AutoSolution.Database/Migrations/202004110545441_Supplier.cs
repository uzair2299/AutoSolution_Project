namespace AutoSolution.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Supplier : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.PartsProducts", "SupplierId", c => c.Int(nullable: false));
            CreateIndex("dbo.PartsProducts", "SupplierId");
            AddForeignKey("dbo.PartsProducts", "SupplierId", "dbo.Suppliers", "SupplierId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PartsProducts", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Suppliers", "CityId", "dbo.Cities");
            DropIndex("dbo.Suppliers", new[] { "CityId" });
            DropIndex("dbo.PartsProducts", new[] { "SupplierId" });
            DropColumn("dbo.PartsProducts", "SupplierId");
            DropTable("dbo.Suppliers");
        }
    }
}
