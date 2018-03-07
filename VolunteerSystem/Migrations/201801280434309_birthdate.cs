namespace VolunteerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class birthdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Volunteer", "BirthDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Volunteer", "BirthDate");
        }
    }
}
