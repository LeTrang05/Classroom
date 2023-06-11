namespace Lecturers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addidclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContentClasses", "IdClass", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContentClasses", "IdClass");
        }
    }
}
