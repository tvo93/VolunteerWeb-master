namespace VolunteerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeventdata : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Event", "VolunteerID", "dbo.Volunteer");
            DropIndex("dbo.Event", new[] { "VolunteerID" });
            CreateTable(
                "dbo.EventVolunteer",
                c => new
                    {
                        EventID = c.Int(nullable: false),
                        VolunteerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EventID, t.VolunteerID })
                .ForeignKey("dbo.Event", t => t.EventID, cascadeDelete: true)
                .ForeignKey("dbo.Volunteer", t => t.VolunteerID, cascadeDelete: true)
                .Index(t => t.EventID)
                .Index(t => t.VolunteerID);
            
            AddColumn("dbo.Event", "Volunteer_VolunteerID", c => c.Int());
            CreateIndex("dbo.Event", "Volunteer_VolunteerID");
            AddForeignKey("dbo.Event", "Volunteer_VolunteerID", "dbo.Volunteer", "VolunteerID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Event", "Volunteer_VolunteerID", "dbo.Volunteer");
            DropForeignKey("dbo.EventVolunteer", "VolunteerID", "dbo.Volunteer");
            DropForeignKey("dbo.EventVolunteer", "EventID", "dbo.Event");
            DropIndex("dbo.EventVolunteer", new[] { "VolunteerID" });
            DropIndex("dbo.EventVolunteer", new[] { "EventID" });
            DropIndex("dbo.Event", new[] { "Volunteer_VolunteerID" });
            DropColumn("dbo.Event", "Volunteer_VolunteerID");
            DropTable("dbo.EventVolunteer");
            CreateIndex("dbo.Event", "VolunteerID");
            AddForeignKey("dbo.Event", "VolunteerID", "dbo.Volunteer", "VolunteerID", cascadeDelete: true);
        }
    }
}
