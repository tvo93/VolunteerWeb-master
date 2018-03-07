namespace VolunteerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addevent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Enrollment", "VolunteerID", "dbo.Volunteer");
            DropPrimaryKey("dbo.Volunteer");
            DropColumn("dbo.Volunteer", "ID");
            AddColumn("dbo.Volunteer", "VolunteerID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Volunteer", "VolunteerID");
            AddForeignKey("dbo.Enrollment", "VolunteerID", "dbo.Volunteer", "VolunteerID", cascadeDelete: true);
          
        }
        
        public override void Down()
        {
            AddColumn("dbo.Volunteer", "ID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Enrollment", "VolunteerID", "dbo.Volunteer");
            DropPrimaryKey("dbo.Volunteer");
            DropColumn("dbo.Volunteer", "VolunteerID");
            AddPrimaryKey("dbo.Volunteer", "ID");
            AddForeignKey("dbo.Enrollment", "VolunteerID", "dbo.Volunteer", "ID", cascadeDelete: true);
        }
    }
}
