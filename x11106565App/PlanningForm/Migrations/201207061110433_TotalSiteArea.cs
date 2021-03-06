namespace PlanningForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TotalSiteArea : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlanningApplications", "TotalSiteArea", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlanningApplications", "TotalSiteArea");
        }
    }
}
