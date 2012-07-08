namespace PlanningForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProposedDevelopmentTotalFloorArea : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlanningApplications", "ProposedDevelopmentTotalFloorArea", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlanningApplications", "ProposedDevelopmentTotalFloorArea");
        }
    }
}
