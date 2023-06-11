namespace Lecturers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablediem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.diems",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idStudent = c.Int(nullable: false),
                        nameStudent = c.String(),
                        diems = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.diems");
        }
    }
}
