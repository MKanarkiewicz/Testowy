using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICollege_WebApp.Models
{
    public class Address
    {
        public int ID { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string ZipCode { get; set; }
        public string Town { get; set; }
    }
}