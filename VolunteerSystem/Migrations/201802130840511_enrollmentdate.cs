namespace VolunteerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enrollmentdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enrollment", "EnrollmentDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Volunteer", "PhoneNumber", c => c.String());
            AddColumn("dbo.Volunteer", "Email", c => c.String());
            DropColumn("dbo.Volunteer", "EnrollmentDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Volunteer", "EnrollmentDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Volunteer", "Email");
            DropColumn("dbo.Volunteer", "PhoneNumber");
            DropColumn("dbo.Enrollment", "EnrollmentDate");
        }
    }
}
