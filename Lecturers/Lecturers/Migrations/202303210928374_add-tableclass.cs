namespace Lecturers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtableclass : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Classes", "ClassName", c => c.String(nullable: false));
            AlterColumn("dbo.Classes", "ClassMaLop", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Classes", "ClassMaLop", c => c.String());
            AlterColumn("dbo.Classes", "ClassName", c => c.String());
        }
    }
}
