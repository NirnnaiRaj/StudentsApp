using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentBuisness.Models
{
    public class Student
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public DateTime DOB { set; get; }
        public decimal Mark { set; get; }
    }
}
