namespace AutoSolution.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uzair : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserTypes", "UserTypeCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserTypes", "UserTypeCode");
        }
    }
}
