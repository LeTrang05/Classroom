namespace Lecturers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Lecturer", t => t.lecturer_LecturerId)
                .Index(t => t.lecturer_LecturerId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserEmail = c.String(),
                        UserPassword = c.String(),
                        UserPosition = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "lecturer_LecturerId", "dbo.Lecturer");
            DropIndex("dbo.Students", new[] { "lecturer_LecturerId" });
            DropTable("dbo.User");
            DropTable("dbo.Students");
            DropTable("dbo.Lecturer");
        }
    }
}
