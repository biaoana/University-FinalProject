using System;
using System.Collections.Generic;
using System.Text;

namespace University.AppLogic.Models
{
    public class Classroom
    {
        public Guid ClassroomID { get; set; }
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public string ClassCode { get; set; }

        public static Classroom Create(string name, string classCode)
        {
            return new Classroom
            {
                Name = name,
                ClassCode = classCode
            };
        }
        public void Update(string name, string classCode)
        {
            this.Name = name;
            this.ClassCode = classCode;
        }
    }
}
