namespace PlanningForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class town1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlanningApplications", "town", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlanningApplications", "town");
        }
    }
}
