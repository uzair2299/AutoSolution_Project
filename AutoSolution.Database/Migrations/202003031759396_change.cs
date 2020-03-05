namespace AutoSolution.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
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
                "dbo.Provinces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProvinceName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserServiceCategories",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        ServiceCategory_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.ServiceCategory_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.ServiceCategories", t => t.ServiceCategory_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.ServiceCategory_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserServiceCategories", "ServiceCategory_Id", "dbo.ServiceCategories");
            DropForeignKey("dbo.UserServiceCategories", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Cities", "Province_Id", "dbo.Provinces");
            DropIndex("dbo.UserServiceCategories", new[] { "ServiceCategory_Id" });
            DropIndex("dbo.UserServiceCategories", new[] { "User_Id" });
            DropIndex("dbo.Cities", new[] { "Province_Id" });
            DropTable("dbo.UserServiceCategories");
            DropTable("dbo.Users");
            DropTable("dbo.ServiceCategories");
            DropTable("dbo.Provinces");
            DropTable("dbo.Cities");
        }
    }
}
