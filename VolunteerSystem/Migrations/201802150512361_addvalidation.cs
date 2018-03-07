namespace VolunteerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvalidation : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Volunteer", name: "FirstMidName", newName: "FirstName");
            AlterColumn("dbo.Volunteer", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Volunteer", "FirstName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Volunteer", "FirstName", c => c.String());
            AlterColumn("dbo.Volunteer", "LastName", c => c.String());
            RenameColumn(table: "dbo.Volunteer", name: "FirstName", newName: "FirstMidName");
        }
    }
}
