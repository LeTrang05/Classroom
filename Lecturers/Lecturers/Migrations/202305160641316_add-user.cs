namespace Lecturers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adduser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContentClasses", "userofclass_UserID", c => c.Int());
            CreateIndex("dbo.ContentClasses", "userofclass_UserID");
            AddForeignKey("dbo.ContentClasses", "userofclass_UserID", "dbo.User", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContentClasses", "userofclass_UserID", "dbo.User");
            DropIndex("dbo.ContentClasses", new[] { "userofclass_UserID" });
            DropColumn("dbo.ContentClasses", "userofclass_UserID");
        }
    }
}
