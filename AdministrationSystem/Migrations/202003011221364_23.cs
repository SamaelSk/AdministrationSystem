namespace AdministrationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _23 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.StudentLessons", newName: "LessonStudents");
            DropForeignKey("dbo.Students", "GroupId", "dbo.Groups");
            DropIndex("dbo.Students", new[] { "GroupId" });
            DropPrimaryKey("dbo.LessonStudents");
            CreateTable(
                "dbo.StudentGroups",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        Group_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Group_Id })
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.Group_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.Group_Id);
            
            AddPrimaryKey("dbo.LessonStudents", new[] { "Lesson_Id", "Student_Id" });
            //DropColumn("dbo.Students", "GroupId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "GroupId", c => c.Int());
            DropForeignKey("dbo.StudentGroups", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.StudentGroups", "Student_Id", "dbo.Students");
            DropIndex("dbo.StudentGroups", new[] { "Group_Id" });
            DropIndex("dbo.StudentGroups", new[] { "Student_Id" });
            DropPrimaryKey("dbo.LessonStudents");
            DropTable("dbo.StudentGroups");
            AddPrimaryKey("dbo.LessonStudents", new[] { "Student_Id", "Lesson_Id" });
            CreateIndex("dbo.Students", "GroupId");
            AddForeignKey("dbo.Students", "GroupId", "dbo.Groups", "Id");
            RenameTable(name: "dbo.LessonStudents", newName: "StudentLessons");
        }
    }
}
