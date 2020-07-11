using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.ViewModel
{
    public class AdministratorViewModel
    {
        public IEnumerable<IdentityUser> Employees { get; set; }
    }
}
