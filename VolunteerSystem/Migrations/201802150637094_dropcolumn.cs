namespace VolunteerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropcolumn : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        EventID = c.Int(nullable: false),
                        JobID = c.Int(nullable: false),
                        VolunteerID = c.Int(nullable: false),
                        EventName = c.String(nullable: false, maxLength: 50),
                        Date = c.String(nullable: false),
                        Event_EventID = c.Int(),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.Event", t => t.Event_EventID)
                .ForeignKey("dbo.Job", t => t.JobID, cascadeDelete: true)
                .ForeignKey("dbo.Volunteer", t => t.VolunteerID, cascadeDelete: true)
                .Index(t => t.JobID)
                .Index(t => t.VolunteerID)
                .Index(t => t.Event_EventID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Event", "VolunteerID", "dbo.Volunteer");
            DropForeignKey("dbo.Event", "JobID", "dbo.Job");
            DropForeignKey("dbo.Event", "Event_EventID", "dbo.Event");
            DropIndex("dbo.Event", new[] { "Event_EventID" });
            DropIndex("dbo.Event", new[] { "VolunteerID" });
            DropIndex("dbo.Event", new[] { "JobID" });
            DropTable("dbo.Event");
        }
    }
}
