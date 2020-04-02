namespace AutoSolution.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstRecord288 : DbMigration
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
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceCategoryId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        First_Name = c.String(),
                        Last_Name = c.String(),
                        Gender = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        PhoneNumber = c.Int(nullable: false),
                        MobileNumber = c.Int(nullable: false),
                        Email = c.String(),
                        IsConfrimEmail = c.Boolean(nullable: false),
                        Password = c.String(),
                        ConfrimPassword = c.String(),
                        PasswordCount = c.Int(nullable: false),
                        Address = c.String(),
                        FacebookPageLink = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        IsTermAndConditionAccepted = c.Boolean(nullable: false),
                        RememberMe = c.Boolean(nullable: false),
                        UserRoleId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.UserRoles", t => t.UserRoleId, cascadeDelete: true)
                .Index(t => t.UserRoleId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserRoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.UserRoleId);
            
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
            DropForeignKey("dbo.Users", "UserRoleId", "dbo.UserRoles");
            DropForeignKey("dbo.UserServiceCategories", "ServiceCategory_ServiceCategoryId", "dbo.ServiceCategories");
            DropForeignKey("dbo.UserServiceCategories", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Cities", "ProvinceId", "dbo.Provinces");
            DropIndex("dbo.UserServiceCategories", new[] { "ServiceCategory_ServiceCategoryId" });
            DropIndex("dbo.UserServiceCategories", new[] { "User_UserId" });
            DropIndex("dbo.Users", new[] { "CityId" });
            DropIndex("dbo.Users", new[] { "UserRoleId" });
            DropIndex("dbo.Cities", new[] { "ProvinceId" });
            DropTable("dbo.UserServiceCategories");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users");
            DropTable("dbo.ServiceCategories");
            DropTable("dbo.Provinces");
            DropTable("dbo.Cities");
        }
    }
}
