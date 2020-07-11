using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.ViewModel
{
    public class ClassroomViewModel
    {
        public Guid ClassroomID { get; set; }
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public string ClassCode { get; set; }
    }
}
