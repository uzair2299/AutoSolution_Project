namespace AutoSolution.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cityar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CityAreas",
                c => new
                    {
                        CityAreaID = c.Int(nullable: false, identity: true),
                        CityAreaName = c.String(),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CityAreaID)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CityAreas", "CityId", "dbo.Cities");
            DropIndex("dbo.CityAreas", new[] { "CityId" });
            DropTable("dbo.CityAreas");
        }
    }
}
