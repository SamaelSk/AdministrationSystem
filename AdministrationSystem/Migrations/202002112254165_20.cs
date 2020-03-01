namespace AdministrationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subscriptions", "Name", c => c.String());
            AddColumn("dbo.Subscriptions", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subscriptions", "IsActive");
            DropColumn("dbo.Subscriptions", "Name");
        }
    }
}
