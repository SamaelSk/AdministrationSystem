namespace AdministrationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentSubscriptions", "LinkedSubscription", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentSubscriptions", "LinkedSubscription");
        }
    }
}
