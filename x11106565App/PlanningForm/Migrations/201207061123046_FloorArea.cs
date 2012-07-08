namespace PlanningForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FloorArea : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlanningApplications", "FloorArea", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlanningApplications", "FloorArea");
        }
    }
}
