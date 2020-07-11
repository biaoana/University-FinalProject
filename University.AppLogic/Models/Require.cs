using System;
using System.Collections.Generic;
using System.Text;

namespace University.AppLogic.Models
{
    public class Require
    {
        public Guid RequireID { get; set; }
        public Classroom ClassroomId { get; set; }
        public User StudentId { get; set; }
        public Boolean Status { get; set; }
    }
}
