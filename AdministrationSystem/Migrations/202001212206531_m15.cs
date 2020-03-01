namespace AdministrationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentSubscriptions", "StartingDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentSubscriptions", "StartingDate");
        }
    }
}
