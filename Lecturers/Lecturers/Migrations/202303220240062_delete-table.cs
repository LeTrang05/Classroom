namespace Lecturers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletetable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "lecturer_LecturerId", "dbo.Lecturer");
            DropIndex("dbo.Students", new[] { "lecturer_LecturerId" });
            DropTable("dbo.Lecturer");
            DropTable("dbo.Students");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(nullable: false),
                        StudentBirthday = c.DateTime(nullable: false),
                        StudentClass = c.String(nullable: false),
                        StudentPhone = c.Int(nullable: false),
                        StudentEmail = c.String(nullable: false),
                        StudentOfTeacher = c.String(nullable: false),
                        StudentGender = c.String(nullable: false),
                        lecturer_LecturerId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.Lecturer",
                c => new
                    {
                        LecturerId = c.Int(nullable: false, identity: true),
                        LecturerName = c.String(),
                        LecturerBirthday = c.DateTime(),
                        LecturerAddress = c.String(),
                        LecturerPhone = c.Int(nullable: false),
                        LectureEmail = c.String(),
                        LecturerDegree = c.String(),
                        LecturerGender = c.String(),
                    })
                .PrimaryKey(t => t.LecturerId);
            
            CreateIndex("dbo.Students", "lecturer_LecturerId");
            AddForeignKey("dbo.Students", "lecturer_LecturerId", "dbo.Lecturer", "LecturerId");
        }
    }
}
