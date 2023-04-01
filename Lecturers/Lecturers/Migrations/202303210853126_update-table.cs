namespace Lecturers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ClassId = c.Int(nullable: false, identity: true),
                        ClassName = c.String(),
                        ClassMaLop = c.String(),
                    })
                .PrimaryKey(t => t.ClassId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Classes");
        }
    }
}
