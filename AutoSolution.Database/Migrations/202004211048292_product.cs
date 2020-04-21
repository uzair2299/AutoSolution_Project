namespace AutoSolution.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class product : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PartsProducts", "PartsProductCategoryId", "dbo.PartsProductCategories");
            DropIndex("dbo.PartsProducts", new[] { "PartsProductCategoryId" });
            CreateTable(
                "dbo.PartsProductsSubCategories",
                c => new
                    {
                        PartsProductsSubCategoryId = c.Int(nullable: false, identity: true),
                        PartsProductsSubCategoryName = c.String(),
                        PartsProductCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PartsProductsSubCategoryId)
                .ForeignKey("dbo.PartsProductCategories", t => t.PartsProductCategoryId, cascadeDelete: true)
                .Index(t => t.PartsProductCategoryId);
            
            AddColumn("dbo.PartsProducts", "PartsProductsSubCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.PartsProducts", "PartsProductsSubCategoryId");
            AddForeignKey("dbo.PartsProducts", "PartsProductsSubCategoryId", "dbo.PartsProductsSubCategories", "PartsProductsSubCategoryId", cascadeDelete: true);
            DropColumn("dbo.PartsProducts", "PartsProductCategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PartsProducts", "PartsProductCategoryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.PartsProducts", "PartsProductsSubCategoryId", "dbo.PartsProductsSubCategories");
            DropForeignKey("dbo.PartsProductsSubCategories", "PartsProductCategoryId", "dbo.PartsProductCategories");
            DropIndex("dbo.PartsProductsSubCategories", new[] { "PartsProductCategoryId" });
            DropIndex("dbo.PartsProducts", new[] { "PartsProductsSubCategoryId" });
            DropColumn("dbo.PartsProducts", "PartsProductsSubCategoryId");
            DropTable("dbo.PartsProductsSubCategories");
            CreateIndex("dbo.PartsProducts", "PartsProductCategoryId");
            AddForeignKey("dbo.PartsProducts", "PartsProductCategoryId", "dbo.PartsProductCategories", "PartsProductCategoryId", cascadeDelete: true);
        }
    }
}
