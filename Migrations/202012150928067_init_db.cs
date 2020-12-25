namespace ICollege_WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Street = c.String(unicode: false),
                        Number = c.String(unicode: false),
                        ZipCode = c.String(unicode: false),
                        Town = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Term = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StudentGroup",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Group_ID = c.Int(),
                        Student_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Group", t => t.Group_ID)
                .ForeignKey("dbo.Person", t => t.Student_ID)
                .Index(t => t.Group_ID)
                .Index(t => t.Student_ID);
            
            CreateTable(
                "dbo.SubjectGroup",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Group_ID = c.Int(),
                        Subject_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Group", t => t.Group_ID)
                .ForeignKey("dbo.Subject", t => t.Subject_ID)
                .Index(t => t.Group_ID)
                .Index(t => t.Subject_ID);
            
            CreateTable(
                "dbo.SubjectTeacher",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SubjectGroup_ID = c.Int(),
                        Teacher_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SubjectGroup", t => t.SubjectGroup_ID)
                .ForeignKey("dbo.Person", t => t.Teacher_ID)
                .Index(t => t.SubjectGroup_ID)
                .Index(t => t.Teacher_ID);
            
            CreateTable(
                "dbo.Lesson",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        Subject_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Subject", t => t.Subject_ID)
                .Index(t => t.Subject_ID);
            
            CreateTable(
                "dbo.LessonSchedule",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Lesson_ID = c.Int(),
                        Schedule_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Lesson", t => t.Lesson_ID)
                .ForeignKey("dbo.Schedule", t => t.Schedule_ID)
                .Index(t => t.Lesson_ID)
                .Index(t => t.Schedule_ID);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Login",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Mail = c.String(unicode: false),
                        Password = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Mark",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        Student_ID = c.Int(),
                        Subject_ID = c.Int(),
                        Teacher_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Person", t => t.Student_ID)
                .ForeignKey("dbo.Subject", t => t.Subject_ID)
                .ForeignKey("dbo.Person", t => t.Teacher_ID)
                .Index(t => t.Student_ID)
                .Index(t => t.Subject_ID)
                .Index(t => t.Teacher_ID);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(unicode: false),
                        LastName = c.String(unicode: false),
                        Pesel = c.String(unicode: false),
                        DateBirth = c.DateTime(nullable: false, precision: 0),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Address_ID = c.Int(),
                        Login_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Address", t => t.Address_ID)
                .ForeignKey("dbo.Login", t => t.Login_ID)
                .Index(t => t.Address_ID)
                .Index(t => t.Login_ID);
            
            CreateTable(
                "dbo.Schedule",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LessonSchedule", "Schedule_ID", "dbo.Schedule");
            DropForeignKey("dbo.Person", "Login_ID", "dbo.Login");
            DropForeignKey("dbo.Person", "Address_ID", "dbo.Address");
            DropForeignKey("dbo.Mark", "Teacher_ID", "dbo.Person");
            DropForeignKey("dbo.SubjectTeacher", "Teacher_ID", "dbo.Person");
            DropForeignKey("dbo.Mark", "Subject_ID", "dbo.Subject");
            DropForeignKey("dbo.Mark", "Student_ID", "dbo.Person");
            DropForeignKey("dbo.StudentGroup", "Student_ID", "dbo.Person");
            DropForeignKey("dbo.Lesson", "Subject_ID", "dbo.Subject");
            DropForeignKey("dbo.SubjectGroup", "Subject_ID", "dbo.Subject");
            DropForeignKey("dbo.LessonSchedule", "Lesson_ID", "dbo.Lesson");
            DropForeignKey("dbo.SubjectGroup", "Group_ID", "dbo.Group");
            DropForeignKey("dbo.SubjectTeacher", "SubjectGroup_ID", "dbo.SubjectGroup");
            DropForeignKey("dbo.StudentGroup", "Group_ID", "dbo.Group");
            DropIndex("dbo.Person", new[] { "Login_ID" });
            DropIndex("dbo.Person", new[] { "Address_ID" });
            DropIndex("dbo.Mark", new[] { "Teacher_ID" });
            DropIndex("dbo.Mark", new[] { "Subject_ID" });
            DropIndex("dbo.Mark", new[] { "Student_ID" });
            DropIndex("dbo.LessonSchedule", new[] { "Schedule_ID" });
            DropIndex("dbo.LessonSchedule", new[] { "Lesson_ID" });
            DropIndex("dbo.Lesson", new[] { "Subject_ID" });
            DropIndex("dbo.SubjectTeacher", new[] { "Teacher_ID" });
            DropIndex("dbo.SubjectTeacher", new[] { "SubjectGroup_ID" });
            DropIndex("dbo.SubjectGroup", new[] { "Subject_ID" });
            DropIndex("dbo.SubjectGroup", new[] { "Group_ID" });
            DropIndex("dbo.StudentGroup", new[] { "Student_ID" });
            DropIndex("dbo.StudentGroup", new[] { "Group_ID" });
            DropTable("dbo.Schedule");
            DropTable("dbo.Person");
            DropTable("dbo.Mark");
            DropTable("dbo.Login");
            DropTable("dbo.Subject");
            DropTable("dbo.LessonSchedule");
            DropTable("dbo.Lesson");
            DropTable("dbo.SubjectTeacher");
            DropTable("dbo.SubjectGroup");
            DropTable("dbo.StudentGroup");
            DropTable("dbo.Group");
            DropTable("dbo.Address");
        }
    }
}
