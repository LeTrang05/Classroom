namespace Lecturers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addstringuser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContentClasses", "userofclass_UserID", "dbo.User");
            DropIndex("dbo.ContentClasses", new[] { "userofclass_UserID" });
            AddColumn("dbo.ContentClasses", "userofclass", c => c.String());
            DropColumn("dbo.ContentClasses", "userofclass_UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContentClasses", "userofclass_UserID", c => c.Int());
            DropColumn("dbo.ContentClasses", "userofclass");
            CreateIndex("dbo.ContentClasses", "userofclass_UserID");
            AddForeignKey("dbo.ContentClasses", "userofclass_UserID", "dbo.User", "UserID");
        }
    }
}
