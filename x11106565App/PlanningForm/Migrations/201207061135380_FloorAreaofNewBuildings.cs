namespace PlanningForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FloorAreaofNewBuildings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlanningApplications", "FloorAreaofNewBuildings", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlanningApplications", "FloorAreaofNewBuildings");
        }
    }
}
