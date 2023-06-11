namespace Lecturers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User", "myclass_ClassId", "dbo.Classes");
            DropIndex("dbo.User", new[] { "myclass_ClassId" });
            DropColumn("dbo.User", "myclass_ClassId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "myclass_ClassId", c => c.Int());
            CreateIndex("dbo.User", "myclass_ClassId");
            AddForeignKey("dbo.User", "myclass_ClassId", "dbo.Classes", "ClassId");
        }
    }
}
