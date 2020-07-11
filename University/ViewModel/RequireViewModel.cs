using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.AppLogic.Models;

namespace University.ViewModel
{
    public class RequireViewModel
    {
        public Guid RequireID { get; set; }
        public Classroom ClassroomId { get; set; }
        public User StudentId { get; set; }
        public Boolean Status { get; set; }
    }
}
