namespace PeaceOfMind.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Job",
                c => new
                    {
                        JobId = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        ClientId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.JobId)
                .ForeignKey("dbo.Client", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Service", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.PetJobAssign",
                c => new
                    {
                        PetJobAssignId = c.Int(nullable: false, identity: true),
                        PetId = c.Int(nullable: false),
                        JobId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PetJobAssignId)
                .ForeignKey("dbo.Job", t => t.JobId, cascadeDelete: true)
                .ForeignKey("dbo.Pet", t => t.PetId, cascadeDelete: true)
                .Index(t => t.PetId)
                .Index(t => t.JobId);
            
            CreateTable(
                "dbo.Pet",
                c => new
                    {
                        PetId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PetType = c.Int(nullable: false),
                        ClientId = c.Int(),
                    })
                .PrimaryKey(t => t.PetId)
                .ForeignKey("dbo.Client", t => t.ClientId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Service",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Cost = c.Double(nullable: false),
                        Duration = c.Int(nullable: false),
                        DurationUnit = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ServiceId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Job", "ServiceId", "dbo.Service");
            DropForeignKey("dbo.PetJobAssign", "PetId", "dbo.Pet");
            DropForeignKey("dbo.Pet", "ClientId", "dbo.Client");
            DropForeignKey("dbo.PetJobAssign", "JobId", "dbo.Job");
            DropForeignKey("dbo.Job", "ClientId", "dbo.Client");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Pet", new[] { "ClientId" });
            DropIndex("dbo.PetJobAssign", new[] { "JobId" });
            DropIndex("dbo.PetJobAssign", new[] { "PetId" });
            DropIndex("dbo.Job", new[] { "ServiceId" });
            DropIndex("dbo.Job", new[] { "ClientId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Service");
            DropTable("dbo.Pet");
            DropTable("dbo.PetJobAssign");
            DropTable("dbo.Job");
            DropTable("dbo.Client");
        }
    }
}
