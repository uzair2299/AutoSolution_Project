namespace AutoSolution.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vehicleupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransmissionTypes", "Description", c => c.String());
            AddColumn("dbo.TransmissionTypes", "AddedBy", c => c.String());
            AddColumn("dbo.TransmissionTypes", "AddedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.TransmissionTypes", "UpdatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransmissionTypes", "UpdatedDate");
            DropColumn("dbo.TransmissionTypes", "AddedDate");
            DropColumn("dbo.TransmissionTypes", "AddedBy");
            DropColumn("dbo.TransmissionTypes", "Description");
        }
    }
}
