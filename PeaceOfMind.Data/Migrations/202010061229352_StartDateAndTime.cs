namespace PeaceOfMind.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StartDateAndTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Job", "StartDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Job", "StartDate");
        }
    }
}
