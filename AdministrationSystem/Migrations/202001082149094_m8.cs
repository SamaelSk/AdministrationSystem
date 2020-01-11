namespace AdministrationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m8 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Lessons", name: "Group_Id", newName: "GroupId");
            RenameColumn(table: "dbo.Students", name: "Group_Id", newName: "GroupId");
            RenameIndex(table: "dbo.Lessons", name: "IX_Group_Id", newName: "IX_GroupId");
            RenameIndex(table: "dbo.Students", name: "IX_Group_Id", newName: "IX_GroupId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Students", name: "IX_GroupId", newName: "IX_Group_Id");
            RenameIndex(table: "dbo.Lessons", name: "IX_GroupId", newName: "IX_Group_Id");
            RenameColumn(table: "dbo.Students", name: "GroupId", newName: "Group_Id");
            RenameColumn(table: "dbo.Lessons", name: "GroupId", newName: "Group_Id");
        }
    }
}
