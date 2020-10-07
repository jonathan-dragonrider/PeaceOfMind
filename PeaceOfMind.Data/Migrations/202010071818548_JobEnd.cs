namespace PeaceOfMind.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobEnd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Job", "End", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Job", "End");
        }
    }
}
