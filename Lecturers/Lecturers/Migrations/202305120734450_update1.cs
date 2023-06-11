namespace Lecturers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Classes", "userTeacherMyClass_UserID", c => c.Int());
            CreateIndex("dbo.Classes", "userTeacherMyClass_UserID");
            AddForeignKey("dbo.Classes", "userTeacherMyClass_UserID", "dbo.User", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "userTeacherMyClass_UserID", "dbo.User");
            DropIndex("dbo.Classes", new[] { "userTeacherMyClass_UserID" });
            DropColumn("dbo.Classes", "userTeacherMyClass_UserID");
        }
    }
}
