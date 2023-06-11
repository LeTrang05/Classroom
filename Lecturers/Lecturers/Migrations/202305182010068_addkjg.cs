namespace Lecturers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addkjg : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.diems");
            DropTable("dbo.points");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.points",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idstudent = c.Int(nullable: false),
                        mypoint = c.Double(nullable: false),
                        myname = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.diems",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idStudent = c.Int(nullable: false),
                        nameStudent = c.String(nullable: false),
                        diems = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
    }
}
