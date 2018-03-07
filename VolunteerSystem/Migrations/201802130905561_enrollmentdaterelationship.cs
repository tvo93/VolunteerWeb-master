namespace VolunteerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enrollmentdaterelationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enrollment", "Enrollment_EnrollmentID", c => c.Int());
            CreateIndex("dbo.Enrollment", "Enrollment_EnrollmentID");
            AddForeignKey("dbo.Enrollment", "Enrollment_EnrollmentID", "dbo.Enrollment", "EnrollmentID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollment", "Enrollment_EnrollmentID", "dbo.Enrollment");
            DropIndex("dbo.Enrollment", new[] { "Enrollment_EnrollmentID" });
            DropColumn("dbo.Enrollment", "Enrollment_EnrollmentID");
        }
    }
}
