using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICollege_WebApp.Models
{
    public class Mark
    {
        public int ID { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; }
        public Subject Subject { get; set; }
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
    }
}