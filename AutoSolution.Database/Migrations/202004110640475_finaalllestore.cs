namespace AutoSolution.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finaalllestore : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PartsProducts", "SupplierId", "dbo.Suppliers");
            DropIndex("dbo.PartsProducts", new[] { "SupplierId" });
            CreateTable(
                "dbo.PartsProductManufacturers",
                c => new
                    {
                        PartsProductManufacturerId = c.Int(nullable: false, identity: true),
                        PartsProductManufacturerName = c.String(),
                        PartsProductManufacturerCode = c.String(),
                    })
                .PrimaryKey(t => t.PartsProductManufacturerId);
            
            CreateTable(
                "dbo.PartsProductSuppliers",
                c => new
                    {
                        SupplierId = c.Int(nullable: false),
                        PartsProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SupplierId, t.PartsProductId })
                .ForeignKey("dbo.PartsProducts", t => t.PartsProductId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId)
                .Index(t => t.PartsProductId);
            
            AddColumn("dbo.PartsProducts", "PartsProductManufacturerId", c => c.Int(nullable: false));
            CreateIndex("dbo.PartsProducts", "PartsProductManufacturerId");
            AddForeignKey("dbo.PartsProducts", "PartsProductManufacturerId", "dbo.PartsProductManufacturers", "PartsProductManufacturerId", cascadeDelete: true);
            DropColumn("dbo.PartsProducts", "SupplierId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PartsProducts", "SupplierId", c => c.Int(nullable: false));
            DropForeignKey("dbo.PartsProductSuppliers", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.PartsProductSuppliers", "PartsProductId", "dbo.PartsProducts");
            DropForeignKey("dbo.PartsProducts", "PartsProductManufacturerId", "dbo.PartsProductManufacturers");
            DropIndex("dbo.PartsProductSuppliers", new[] { "PartsProductId" });
            DropIndex("dbo.PartsProductSuppliers", new[] { "SupplierId" });
            DropIndex("dbo.PartsProducts", new[] { "PartsProductManufacturerId" });
            DropColumn("dbo.PartsProducts", "PartsProductManufacturerId");
            DropTable("dbo.PartsProductSuppliers");
            DropTable("dbo.PartsProductManufacturers");
            CreateIndex("dbo.PartsProducts", "SupplierId");
            AddForeignKey("dbo.PartsProducts", "SupplierId", "dbo.Suppliers", "SupplierId", cascadeDelete: true);
        }
    }
}
