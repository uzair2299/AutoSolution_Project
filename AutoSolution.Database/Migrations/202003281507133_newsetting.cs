namespace AutoSolution.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newsetting : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                        CityCode = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                        Province_ProvinceId = c.Int(),
                    })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.Provinces", t => t.Province_ProvinceId)
                .Index(t => t.Province_ProvinceId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        Cities_CityId = c.Int(),
                        Provinces_ProvinceId = c.Int(),
                    })
                .PrimaryKey(t => t.LocationId)
                .ForeignKey("dbo.Cities", t => t.Cities_CityId)
                .ForeignKey("dbo.Provinces", t => t.Provinces_ProvinceId)
                .Index(t => t.Cities_CityId)
                .Index(t => t.Provinces_ProvinceId);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        ProvinceId = c.Int(nullable: false, identity: true),
                        ProvinceName = c.String(),
                        ProvinceCode = c.String(),
                    })
                .PrimaryKey(t => t.ProvinceId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
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
                        IsDelete = c.Boolean(nullable: false),
                        IsTermAndConditionAccepted = c.Boolean(nullable: false),
                        RememberMe = c.Boolean(nullable: false),
                        LocationId = c.Int(nullable: false),
                        UserRoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .ForeignKey("dbo.UserRoles", t => t.UserRoleId, cascadeDelete: true)
                .Index(t => t.LocationId)
                .Index(t => t.UserRoleId);
            
            CreateTable(
                "dbo.ServiceCategories",
                c => new
                    {
                        ServiceCategoryId = c.Int(nullable: false, identity: true),
                        ServiceCategoryName = c.String(),
                        ServiceCategoryCode = c.String(),
                        Description = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceCategoryId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserRoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.UserRoleId);
            
            CreateTable(
                "dbo.ServiceCategoryUsers",
                c => new
                    {
                        ServiceCategory_ServiceCategoryId = c.Int(nullable: false),
                        User_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ServiceCategory_ServiceCategoryId, t.User_UserId })
                .ForeignKey("dbo.ServiceCategories", t => t.ServiceCategory_ServiceCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.ServiceCategory_ServiceCategoryId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserRoleId", "dbo.UserRoles");
            DropForeignKey("dbo.ServiceCategoryUsers", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.ServiceCategoryUsers", "ServiceCategory_ServiceCategoryId", "dbo.ServiceCategories");
            DropForeignKey("dbo.Users", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Locations", "Provinces_ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.Cities", "Province_ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.Locations", "Cities_CityId", "dbo.Cities");
            DropIndex("dbo.ServiceCategoryUsers", new[] { "User_UserId" });
            DropIndex("dbo.ServiceCategoryUsers", new[] { "ServiceCategory_ServiceCategoryId" });
            DropIndex("dbo.Users", new[] { "UserRoleId" });
            DropIndex("dbo.Users", new[] { "LocationId" });
            DropIndex("dbo.Locations", new[] { "Provinces_ProvinceId" });
            DropIndex("dbo.Locations", new[] { "Cities_CityId" });
            DropIndex("dbo.Cities", new[] { "Province_ProvinceId" });
            DropTable("dbo.ServiceCategoryUsers");
            DropTable("dbo.UserRoles");
            DropTable("dbo.ServiceCategories");
            DropTable("dbo.Users");
            DropTable("dbo.Provinces");
            DropTable("dbo.Locations");
            DropTable("dbo.Cities");
        }
    }
}
