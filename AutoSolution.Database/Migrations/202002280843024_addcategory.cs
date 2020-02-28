namespace AutoSolution.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcategory : DbMigration
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
                        ProvinceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId, cascadeDelete: true)
                .Index(t => t.ProvinceId);
            
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
                "dbo.ServiceCategories",
                c => new
                    {
                        ServiceCategoryId = c.Int(nullable: false, identity: true),
                        ServiceCategoryName = c.String(),
                        ServiceCategoryCode = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ServiceCategoryId);
            
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
                        UserType = c.String(),
                        PasswordCount = c.Int(nullable: false),
                        RegistrationDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        UserRating = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.UserServiceCategories",
                c => new
                    {
                        User_UserId = c.Int(nullable: false),
                        ServiceCategory_ServiceCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserId, t.ServiceCategory_ServiceCategoryId })
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceCategories", t => t.ServiceCategory_ServiceCategoryId, cascadeDelete: true)
                .Index(t => t.User_UserId)
                .Index(t => t.ServiceCategory_ServiceCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserServiceCategories", "ServiceCategory_ServiceCategoryId", "dbo.ServiceCategories");
            DropForeignKey("dbo.UserServiceCategories", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Cities", "ProvinceId", "dbo.Provinces");
            DropIndex("dbo.UserServiceCategories", new[] { "ServiceCategory_ServiceCategoryId" });
            DropIndex("dbo.UserServiceCategories", new[] { "User_UserId" });
            DropIndex("dbo.Cities", new[] { "ProvinceId" });
            DropTable("dbo.UserServiceCategories");
            DropTable("dbo.Users");
            DropTable("dbo.ServiceCategories");
            DropTable("dbo.Provinces");
            DropTable("dbo.Cities");
        }
    }
}
