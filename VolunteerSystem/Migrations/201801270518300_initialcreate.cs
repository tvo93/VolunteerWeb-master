namespace VolunteerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enrollment",
                c => new
                    {
                        EnrollmentID = c.Int(nullable: false, identity: true),
                        JobID = c.Int(nullable: false),
                        VolunteerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnrollmentID)
                .ForeignKey("dbo.Job", t => t.JobID, cascadeDelete: true)
                .ForeignKey("dbo.Volunteer", t => t.VolunteerID, cascadeDelete: true)
                .Index(t => t.JobID)
                .Index(t => t.VolunteerID);
            
            CreateTable(
                "dbo.Job",
                c => new
                    {
                        JobID = c.Int(nullable: false),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.JobID);
            
            CreateTable(
                "dbo.Volunteer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstMidName = c.String(),
                        EnrollmentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollment", "VolunteerID", "dbo.Volunteer");
            DropForeignKey("dbo.Enrollment", "JobID", "dbo.Job");
            DropIndex("dbo.Enrollment", new[] { "VolunteerID" });
            DropIndex("dbo.Enrollment", new[] { "JobID" });
            DropTable("dbo.Volunteer");
            DropTable("dbo.Job");
            DropTable("dbo.Enrollment");
        }
    }
}
