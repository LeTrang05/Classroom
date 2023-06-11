namespace Lecturers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetableclass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Classes", "userTeacherMyClass_UserID", "dbo.User");
            DropIndex("dbo.Classes", new[] { "userTeacherMyClass_UserID" });
            AddColumn("dbo.Classes", "TeacherMyClass", c => c.Int(nullable: false));
            DropColumn("dbo.Classes", "userTeacherMyClass_UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Classes", "userTeacherMyClass_UserID", c => c.Int());
            DropColumn("dbo.Classes", "TeacherMyClass");
            CreateIndex("dbo.Classes", "userTeacherMyClass_UserID");
            AddForeignKey("dbo.Classes", "userTeacherMyClass_UserID", "dbo.User", "UserID");
        }
    }
}
