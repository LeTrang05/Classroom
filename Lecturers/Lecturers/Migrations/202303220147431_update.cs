namespace Lecturers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Classes", "ClassName", c => c.String());
            AlterColumn("dbo.Classes", "ClassMaLop", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Classes", "ClassMaLop", c => c.String(nullable: false));
            AlterColumn("dbo.Classes", "ClassName", c => c.String(nullable: false));
        }
    }
}
