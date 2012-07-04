namespace PlanningForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class telephone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlanningApplications", "telephone", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlanningApplications", "telephone");
        }
    }
}
