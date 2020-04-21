namespace AutoSolution.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class produc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PartsProductsSubCategories", "PartsProductCategoryId", "dbo.PartsProductCategories");
            DropIndex("dbo.PartsProductsSubCategories", new[] { "PartsProductCategoryId" });
            CreateTable(
                "dbo.PartsProductsCategories",
                c => new
                    {
                        PartsProductsCategoryId = c.Int(nullable: false, identity: true),
                        PartsProductsCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.PartsProductsCategoryId);
            
            AddColumn("dbo.PartsProductsSubCategories", "PartsProductCategory_PartsProductsCategoryId", c => c.Int());
            CreateIndex("dbo.PartsProductsSubCategories", "PartsProductCategory_PartsProductsCategoryId");
            AddForeignKey("dbo.PartsProductsSubCategories", "PartsProductCategory_PartsProductsCategoryId", "dbo.PartsProductsCategories", "PartsProductsCategoryId");
            DropTable("dbo.PartsProductCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PartsProductCategories",
                c => new
                    {
                        PartsProductCategoryId = c.Int(nullable: false, identity: true),
                        PartsProductCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.PartsProductCategoryId);
            
            DropForeignKey("dbo.PartsProductsSubCategories", "PartsProductCategory_PartsProductsCategoryId", "dbo.PartsProductsCategories");
            DropIndex("dbo.PartsProductsSubCategories", new[] { "PartsProductCategory_PartsProductsCategoryId" });
            DropColumn("dbo.PartsProductsSubCategories", "PartsProductCategory_PartsProductsCategoryId");
            DropTable("dbo.PartsProductsCategories");
            CreateIndex("dbo.PartsProductsSubCategories", "PartsProductCategoryId");
            AddForeignKey("dbo.PartsProductsSubCategories", "PartsProductCategoryId", "dbo.PartsProductCategories", "PartsProductCategoryId", cascadeDelete: true);
        }
    }
}
