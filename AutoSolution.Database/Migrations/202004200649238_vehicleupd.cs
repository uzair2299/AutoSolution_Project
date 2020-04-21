namespace AutoSolution.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vehicleupd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransmissionTypes", "ShortCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransmissionTypes", "ShortCode");
        }
    }
}
