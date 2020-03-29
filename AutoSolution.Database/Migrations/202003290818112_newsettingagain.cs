namespace AutoSolution.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newsettingagain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Gender", c => c.String());
            AddColumn("dbo.Users", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "UpdateDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Users", "WebSiteLink");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "WebSiteLink", c => c.String());
            DropColumn("dbo.Users", "UpdateDate");
            DropColumn("dbo.Users", "DateOfBirth");
            DropColumn("dbo.Users", "Gender");
        }
    }
}
