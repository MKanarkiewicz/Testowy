namespace ICollege_WebApp.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using ICollege_WebApp.Models;
    using MySql.Data.EntityFramework;

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ICollegeDbContext : DbContext
    {
        public ICollegeDbContext()
            : base("name=ICollegeDbContext")
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Login> LoginData { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Lesson> Lesson { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Mark> Mark { get; set; }
        public DbSet<StudentGroup> GroupStudent { get; set; }
        public DbSet<SubjectTeacher> SubjectTeacher { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}