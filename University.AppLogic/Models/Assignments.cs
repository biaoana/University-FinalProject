using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace University.AppLogic.Models
{
    public class Assignments
    {
        [Key]
        public Guid AssignmentID { get; set; }
        public string Link { get; set; }
        public Classroom Classroom { get; set; }
        public DateTime WorkPosted { get; set; }
        public DateTime DueTo { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }


    }
}
