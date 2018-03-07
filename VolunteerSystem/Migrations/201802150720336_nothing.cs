namespace VolunteerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nothing : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Event", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Event", "Date", c => c.String(nullable: false));
        }
    }
}
