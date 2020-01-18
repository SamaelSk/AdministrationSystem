namespace AdministrationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m12 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudentSubscriptions", "PurchaseDate", c => c.DateTime());
            AlterColumn("dbo.StudentSubscriptions", "DateOfExpire", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentSubscriptions", "DateOfExpire", c => c.DateTime(nullable: false));
            AlterColumn("dbo.StudentSubscriptions", "PurchaseDate", c => c.DateTime(nullable: false));
        }
    }
}
