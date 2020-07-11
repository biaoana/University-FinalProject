using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.AppLogic.Models;

namespace University.ViewModel
{
    public class MultipleModels
    {
        public IEnumerable<Classroom> classrooms { get; set; }
        public IEnumerable<Require> requires { get; set; }
        public IEnumerable<Assignments> assignments { get; set; }
        public Classroom Classroom { get; set; }
        public Assignments Assignments { get; set; }
        public User Student { get; set; }
    }
}
