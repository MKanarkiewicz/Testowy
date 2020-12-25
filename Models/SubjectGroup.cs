using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICollege_WebApp.Models
{
    public class SubjectGroup
    {
        public int ID { get; set; }
        public virtual ICollection<SubjectTeacher> SubjectTeacher { get; set; }
    }
}