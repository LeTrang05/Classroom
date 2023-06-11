namespace Lecturers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContentClasses", "clased_ClassId", c => c.Int());
            CreateIndex("dbo.ContentClasses", "clased_ClassId");
            AddForeignKey("dbo.ContentClasses", "clased_ClassId", "dbo.Classes", "ClassId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContentClasses", "clased_ClassId", "dbo.Classes");
            DropIndex("dbo.ContentClasses", new[] { "clased_ClassId" });
            DropColumn("dbo.ContentClasses", "clased_ClassId");
        }
    }
}
