namespace PlanningForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LegalInterest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlanningApplications", "LegalInterest", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlanningApplications", "LegalInterest");
        }
    }
}
