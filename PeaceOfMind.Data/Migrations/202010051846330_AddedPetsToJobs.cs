namespace PeaceOfMind.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPetsToJobs : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.PetToJob");
            AddPrimaryKey("dbo.PetToJob", new[] { "PetId", "JobId" });
            DropColumn("dbo.PetToJob", "PetToJobId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PetToJob", "PetToJobId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.PetToJob");
            AddPrimaryKey("dbo.PetToJob", "PetToJobId");
        }
    }
}
