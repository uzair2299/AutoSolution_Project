namespace AutoSolution.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vehicle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BodyTypes", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BodyTypes", "Description");
        }
    }
}
