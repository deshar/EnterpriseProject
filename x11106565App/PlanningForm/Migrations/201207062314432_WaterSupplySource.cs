namespace PlanningForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WaterSupplySource : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlanningApplications", "WaterSupplySource", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlanningApplications", "WaterSupplySource");
        }
    }
}
