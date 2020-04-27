namespace AutoSolution.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imge : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "PartsProductId", "dbo.PartsProducts");
            DropIndex("dbo.Images", new[] { "PartsProductId" });
            CreateTable(
                "dbo.PartProductImages",
                c => new
                    {
                        ImageId = c.Int(nullable: false),
                        PartsProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ImageId, t.PartsProductId })
                .ForeignKey("dbo.Images", t => t.ImageId, cascadeDelete: true)
                .ForeignKey("dbo.PartsProducts", t => t.PartsProductId, cascadeDelete: true)
                .Index(t => t.ImageId)
                .Index(t => t.PartsProductId);
            
            DropColumn("dbo.Images", "PartsProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "PartsProductId", c => c.Int(nullable: false));
            DropForeignKey("dbo.PartProductImages", "PartsProductId", "dbo.PartsProducts");
            DropForeignKey("dbo.PartProductImages", "ImageId", "dbo.Images");
            DropIndex("dbo.PartProductImages", new[] { "PartsProductId" });
            DropIndex("dbo.PartProductImages", new[] { "ImageId" });
            DropTable("dbo.PartProductImages");
            CreateIndex("dbo.Images", "PartsProductId");
            AddForeignKey("dbo.Images", "PartsProductId", "dbo.PartsProducts", "PartsProductId", cascadeDelete: true);
        }
    }
}
