namespace PeaceOfMind.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstLastRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Client", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Client", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Client", "LastName", c => c.String());
            AlterColumn("dbo.Client", "FirstName", c => c.String());
        }
    }
}
