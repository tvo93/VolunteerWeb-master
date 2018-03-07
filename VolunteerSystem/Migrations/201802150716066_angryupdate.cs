namespace VolunteerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class angryupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EventVolunteer", "EventID", "dbo.Event");
            DropForeignKey("dbo.EventVolunteer", "VolunteerID", "dbo.Volunteer");
            DropForeignKey("dbo.Event", "Volunteer_VolunteerID", "dbo.Volunteer");
            DropIndex("dbo.Event", new[] { "Volunteer_VolunteerID" });
            DropIndex("dbo.EventVolunteer", new[] { "EventID" });
            DropIndex("dbo.EventVolunteer", new[] { "VolunteerID" });
            DropColumn("dbo.Event", "VolunteerID");
            RenameColumn(table: "dbo.Event", name: "Volunteer_VolunteerID", newName: "VolunteerID");
            AlterColumn("dbo.Event", "VolunteerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Event", "VolunteerID");
            AddForeignKey("dbo.Event", "VolunteerID", "dbo.Volunteer", "VolunteerID", cascadeDelete: true);
            DropTable("dbo.EventVolunteer");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EventVolunteer",
                c => new
                    {
                        EventID = c.Int(nullable: false),
                        VolunteerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EventID, t.VolunteerID });
            
            DropForeignKey("dbo.Event", "VolunteerID", "dbo.Volunteer");
            DropIndex("dbo.Event", new[] { "VolunteerID" });
            AlterColumn("dbo.Event", "VolunteerID", c => c.Int());
            RenameColumn(table: "dbo.Event", name: "VolunteerID", newName: "Volunteer_VolunteerID");
            AddColumn("dbo.Event", "VolunteerID", c => c.Int(nullable: false));
            CreateIndex("dbo.EventVolunteer", "VolunteerID");
            CreateIndex("dbo.EventVolunteer", "EventID");
            CreateIndex("dbo.Event", "Volunteer_VolunteerID");
            AddForeignKey("dbo.Event", "Volunteer_VolunteerID", "dbo.Volunteer", "VolunteerID");
            AddForeignKey("dbo.EventVolunteer", "VolunteerID", "dbo.Volunteer", "VolunteerID", cascadeDelete: true);
            AddForeignKey("dbo.EventVolunteer", "EventID", "dbo.Event", "EventID", cascadeDelete: true);
        }
    }
}
