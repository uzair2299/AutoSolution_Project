namespace AutoSolution.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Images : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImageName = c.String(),
                        ContentType = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        PartsProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.PartsProducts", t => t.PartsProductId, cascadeDelete: true)
                .Index(t => t.PartsProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "PartsProductId", "dbo.PartsProducts");
            DropIndex("dbo.Images", new[] { "PartsProductId" });
            DropTable("dbo.Images");
        }
    }
}
