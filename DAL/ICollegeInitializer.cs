using ICollege_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ICollege_WebApp.DAL
{
    public class ICollegeInitializer : DropCreateDatabaseAlways<ICollegeDbContext>
    {
        protected override void Seed(ICollegeDbContext context)
        {
            List<Student> students = new List<Student>()
            {
                new Student() {FirstName = "Adam", LastName = "Nowak"}
            };
            context.Student.Add(students[0]);
        }
    }
}