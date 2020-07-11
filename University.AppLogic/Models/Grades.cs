using System;
using System.Collections.Generic;
using System.Text;

namespace University.AppLogic.Models
{
    public class Grades
    {
        public Guid Id { get; set; }
        public Homework Homework { get; set; }
        public User StudentId { get; set; }
        public float Mark { get; set; }
    }
}
