namespace Lecturers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtablepint : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.points");
        }
    }
}
