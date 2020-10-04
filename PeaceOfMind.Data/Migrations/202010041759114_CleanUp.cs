namespace PeaceOfMind.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CleanUp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PetJobAssign", "JobId", "dbo.Job");
            DropForeignKey("dbo.PetJobAssign", "PetId", "dbo.Pet");
            DropIndex("dbo.PetJobAssign", new[] { "PetId" });
            DropIndex("dbo.PetJobAssign", new[] { "JobId" });
            CreateTable(
                "dbo.PetToJob",
                c => new
                    {
                        PetToJobId = c.Int(nullable: false, identity: true),
                        PetId = c.Int(nullable: false),
                        JobId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PetToJobId)
                .ForeignKey("dbo.Job", t => t.JobId, cascadeDelete: true)
                .ForeignKey("dbo.Pet", t => t.PetId, cascadeDelete: true)
                .Index(t => t.PetId)
                .Index(t => t.JobId);
            
            AddColumn("dbo.Pet", "TypeOfPet", c => c.Int(nullable: false));
            AlterColumn("dbo.Client", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Client", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Client", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Pet", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Service", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Pet", "PetType");
            DropTable("dbo.PetJobAssign");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PetJobAssign",
                c => new
                    {
                        PetJobAssignId = c.Int(nullable: false, identity: true),
                        PetId = c.Int(nullable: false),
                        JobId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PetJobAssignId);
            
            AddColumn("dbo.Pet", "PetType", c => c.Int(nullable: false));
            DropForeignKey("dbo.PetToJob", "PetId", "dbo.Pet");
            DropForeignKey("dbo.PetToJob", "JobId", "dbo.Job");
            DropIndex("dbo.PetToJob", new[] { "JobId" });
            DropIndex("dbo.PetToJob", new[] { "PetId" });
            AlterColumn("dbo.Service", "Name", c => c.String());
            AlterColumn("dbo.Pet", "Name", c => c.String());
            AlterColumn("dbo.Client", "Address", c => c.String());
            AlterColumn("dbo.Client", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Client", "Email", c => c.String());
            DropColumn("dbo.Pet", "TypeOfPet");
            DropTable("dbo.PetToJob");
            CreateIndex("dbo.PetJobAssign", "JobId");
            CreateIndex("dbo.PetJobAssign", "PetId");
            AddForeignKey("dbo.PetJobAssign", "PetId", "dbo.Pet", "PetId", cascadeDelete: true);
            AddForeignKey("dbo.PetJobAssign", "JobId", "dbo.Job", "JobId", cascadeDelete: true);
        }
    }
}
