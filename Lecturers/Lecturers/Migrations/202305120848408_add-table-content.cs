namespace Lecturers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtablecontent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContentClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        tin = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.students", "msv", c => c.String());
            AddColumn("dbo.students", "malop", c => c.String());
            AddColumn("dbo.students", "diem", c => c.Double(nullable: false));
            DropColumn("dbo.students", "age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.students", "age", c => c.Int(nullable: false));
            DropColumn("dbo.students", "diem");
            DropColumn("dbo.students", "malop");
            DropColumn("dbo.students", "msv");
            DropTable("dbo.ContentClasses");
        }
    }
}
