namespace AutoSolution.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class order : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        OrderStatusId = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.OrderStatusId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        PartsProductId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        ProductUnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductUnitPriceAfterDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.PartsProductId, t.OrderId })
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.PartsProducts", t => t.PartsProductId, cascadeDelete: true)
                .Index(t => t.PartsProductId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        OrderStatusId = c.Int(nullable: false),
                        TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderFlag = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.OrderStatus", t => t.OrderStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.OrderStatusId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.WishLists",
                c => new
                    {
                        WishListId = c.Int(nullable: false, identity: true),
                        PartsProductId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.WishListId)
                .ForeignKey("dbo.PartsProducts", t => t.PartsProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.PartsProductId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WishLists", "UserId", "dbo.Users");
            DropForeignKey("dbo.WishLists", "PartsProductId", "dbo.PartsProducts");
            DropForeignKey("dbo.OrderDetails", "PartsProductId", "dbo.PartsProducts");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "OrderStatusId", "dbo.OrderStatus");
            DropIndex("dbo.WishLists", new[] { "UserId" });
            DropIndex("dbo.WishLists", new[] { "PartsProductId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "OrderStatusId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.OrderDetails", new[] { "PartsProductId" });
            DropTable("dbo.WishLists");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.OrderStatus");
        }
    }
}
