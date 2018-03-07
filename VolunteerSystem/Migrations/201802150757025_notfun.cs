namespace VolunteerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notfun : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Event", "JobID", "dbo.Job");
            DropForeignKey("dbo.Event", "VolunteerID", "dbo.Volunteer");
            DropIndex("dbo.Event", new[] { "JobID" });
            DropIndex("dbo.Event", new[] { "VolunteerID" });
            RenameColumn(table: "dbo.Event", name: "JobID", newName: "Job_JobID");
            RenameColumn(table: "dbo.Event", name: "VolunteerID", newName: "Volunteer_VolunteerID");
            AlterColumn("dbo.Event", "Job_JobID", c => c.Int());
            AlterColumn("dbo.Event", "Volunteer_VolunteerID", c => c.Int());
            CreateIndex("dbo.Event", "Job_JobID");
            CreateIndex("dbo.Event", "Volunteer_VolunteerID");
            AddForeignKey("dbo.Event", "Job_JobID", "dbo.Job", "JobID");
            AddForeignKey("dbo.Event", "Volunteer_VolunteerID", "dbo.Volunteer", "VolunteerID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Event", "Volunteer_VolunteerID", "dbo.Volunteer");
            DropForeignKey("dbo.Event", "Job_JobID", "dbo.Job");
            DropIndex("dbo.Event", new[] { "Volunteer_VolunteerID" });
            DropIndex("dbo.Event", new[] { "Job_JobID" });
            AlterColumn("dbo.Event", "Volunteer_VolunteerID", c => c.Int(nullable: false));
            AlterColumn("dbo.Event", "Job_JobID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Event", name: "Volunteer_VolunteerID", newName: "VolunteerID");
            RenameColumn(table: "dbo.Event", name: "Job_JobID", newName: "JobID");
            CreateIndex("dbo.Event", "VolunteerID");
            CreateIndex("dbo.Event", "JobID");
            AddForeignKey("dbo.Event", "VolunteerID", "dbo.Volunteer", "VolunteerID", cascadeDelete: true);
            AddForeignKey("dbo.Event", "JobID", "dbo.Job", "JobID", cascadeDelete: true);
        }
    }
}
