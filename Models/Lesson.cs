using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICollege_WebApp.Models
{
    public class Lesson
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Subject Subject { get; set; }
        public virtual ICollection<LessonSchedule> LessonSchedule { get; set; }
    }
}