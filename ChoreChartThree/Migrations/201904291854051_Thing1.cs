namespace ChoreChartThree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Thing1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Guardians", "TaskApproval", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Guardians", "TaskApproval", c => c.Boolean(nullable: false));
        }
    }
}
