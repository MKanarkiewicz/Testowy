using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICollege_WebApp.Models
{
    public class Student : Person
    {
        public virtual ICollection<StudentGroup> StudentGroup { get; set; }
    }
}