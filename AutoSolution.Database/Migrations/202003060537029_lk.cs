namespace AutoSolution.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                        CityCode = c.String(),
                        Province_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Provinces", t => t.Province_Id)
                .Index(t => t.Province_Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        Cities_Id = c.Int(),
                        Provinces_Id = c.Int(),
                    })
                .PrimaryKey(t => t.LocationId)
                .ForeignKey("dbo.Cities", t => t.Cities_Id)
                .ForeignKey("dbo.Provinces", t => t.Provinces_Id)
                .Index(t => t.Cities_Id)
                .Index(t => t.Provinces_Id);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProvinceName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        First_Name = c.String(),
                        Last_Name = c.String(),
                        Email = c.String(),
                        IsConfrimEmail = c.Boolean(nullable: false),
                        Password = c.String(),
                        ConfrimPassword = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        MobileNumber = c.Int(nullable: false),
                        WebSiteLink = c.String(),
                        FacebookPageLink = c.String(),
                        Address = c.String(),
                        PasswordCount = c.Int(nullable: false),
                        RegistrationDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.ServiceCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceCategoryName = c.String(),
                        ServiceCategoryCode = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServiceCategoryUsers",
                c => new
                    {
                        ServiceCategory_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ServiceCategory_Id, t.User_Id })
                .ForeignKey("dbo.ServiceCategories", t => t.ServiceCategory_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.ServiceCategory_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceCategoryUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.ServiceCategoryUsers", "ServiceCategory_Id", "dbo.ServiceCategories");
            DropForeignKey("dbo.Users", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Locations", "Provinces_Id", "dbo.Provinces");
            DropForeignKey("dbo.Cities", "Province_Id", "dbo.Provinces");
            DropForeignKey("dbo.Locations", "Cities_Id", "dbo.Cities");
            DropIndex("dbo.ServiceCategoryUsers", new[] { "User_Id" });
            DropIndex("dbo.ServiceCategoryUsers", new[] { "ServiceCategory_Id" });
            DropIndex("dbo.Users", new[] { "LocationId" });
            DropIndex("dbo.Locations", new[] { "Provinces_Id" });
            DropIndex("dbo.Locations", new[] { "Cities_Id" });
            DropIndex("dbo.Cities", new[] { "Province_Id" });
            DropTable("dbo.ServiceCategoryUsers");
            DropTable("dbo.ServiceCategories");
            DropTable("dbo.Users");
            DropTable("dbo.Provinces");
            DropTable("dbo.Locations");
            DropTable("dbo.Cities");
        }
    }
}
