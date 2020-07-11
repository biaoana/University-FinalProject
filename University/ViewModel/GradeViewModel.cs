using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.ViewModel
{
    public class GradeViewModel
    {
        public Guid Id { get; set; }
        public String[] HomeworkId { get; set; }
        public String[] StudentId { get; set; }
        public float[] Mark { get; set; }
    }
}

