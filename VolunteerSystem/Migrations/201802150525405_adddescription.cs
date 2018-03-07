namespace VolunteerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Job", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Job", "Description");
        }
    }
}
