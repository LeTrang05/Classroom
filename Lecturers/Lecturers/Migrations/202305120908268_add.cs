namespace Lecturers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "myclass_ClassId", c => c.Int());
            CreateIndex("dbo.User", "myclass_ClassId");
            AddForeignKey("dbo.User", "myclass_ClassId", "dbo.Classes", "ClassId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "myclass_ClassId", "dbo.Classes");
            DropIndex("dbo.User", new[] { "myclass_ClassId" });
            DropColumn("dbo.User", "myclass_ClassId");
        }
    }
}
