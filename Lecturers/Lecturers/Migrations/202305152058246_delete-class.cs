namespace Lecturers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteclass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContentClasses", "clased_ClassId", "dbo.Classes");
            DropIndex("dbo.ContentClasses", new[] { "clased_ClassId" });
            DropColumn("dbo.ContentClasses", "clased_ClassId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContentClasses", "clased_ClassId", c => c.Int());
            CreateIndex("dbo.ContentClasses", "clased_ClassId");
            AddForeignKey("dbo.ContentClasses", "clased_ClassId", "dbo.Classes", "ClassId");
        }
    }
}
