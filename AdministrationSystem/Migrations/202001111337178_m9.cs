namespace AdministrationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentSubscriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        SubscriptionId = c.Int(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        DateOfExpire = c.DateTime(nullable: false),
                        CurrentLessonsUsed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Subscriptions", t => t.SubscriptionId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.SubscriptionId);
            
            CreateTable(
                "dbo.Subscriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Int(nullable: false),
                        DaysToExpire = c.Int(nullable: false),
                        AmountOfLessons = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Students", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentSubscriptions", "SubscriptionId", "dbo.Subscriptions");
            DropForeignKey("dbo.StudentSubscriptions", "StudentId", "dbo.Students");
            DropIndex("dbo.StudentSubscriptions", new[] { "SubscriptionId" });
            DropIndex("dbo.StudentSubscriptions", new[] { "StudentId" });
            DropColumn("dbo.Students", "IsActive");
            DropTable("dbo.Subscriptions");
            DropTable("dbo.StudentSubscriptions");
        }
    }
}
