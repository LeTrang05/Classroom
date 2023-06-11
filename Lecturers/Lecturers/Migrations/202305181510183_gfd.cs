namespace Lecturers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gfd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.diems", "nameStudent", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.diems", "nameStudent", c => c.String());
        }
    }
}
