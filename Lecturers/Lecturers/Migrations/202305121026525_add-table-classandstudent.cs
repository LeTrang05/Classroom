namespace Lecturers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtableclassandstudent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassANDStudents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdClass = c.Int(nullable: false),
                        IdStudent = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ClassANDStudents");
        }
    }
}
