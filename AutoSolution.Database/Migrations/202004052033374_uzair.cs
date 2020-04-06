namespace AutoSolution.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uzair : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ActivetionCode", c => c.Guid());
            AddColumn("dbo.Users", "OTP", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "OTP");
            DropColumn("dbo.Users", "ActivetionCode");
        }
    }
}
