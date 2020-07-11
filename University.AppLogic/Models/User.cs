using System;
using System.Collections.Generic;
using System.Text;

namespace University.AppLogic.Models
{
    public class User
    {
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNr { get; set; }
    }
}
