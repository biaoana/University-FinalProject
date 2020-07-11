using System;
using System.Collections.Generic;
using System.Text;

namespace University.AppLogic.Models
{
    public class Homework
    {
        public Guid Id { get; set; }
        public Assignments Assignment { get; set; }
        public User StudentId { get; set; }
        public string Link { get; set; }
        public Boolean Status { get; set; }
    }
}
