namespace PlanningForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlanningApplications",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Apptype = c.String(maxLength: 4000),
                        name = c.String(maxLength: 4000),
                        address = c.String(maxLength: 4000),
                        email = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PlanningApplications");
        }
    }
}
