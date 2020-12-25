using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICollege_WebApp.Models
{
    public class Group
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Term { get; set; }
        public virtual ICollection<StudentGroup> StudentGroup { get; set; }
        public virtual ICollection<SubjectGroup> SubjectGroup { get; set; }
    }
}