namespace PlanningForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlanningApplications", "ApplicationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlanningApplications", "ApplicationDate");
        }
    }
}
