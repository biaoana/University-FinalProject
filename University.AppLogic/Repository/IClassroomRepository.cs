using System;
using System.Collections.Generic;
using System.Text;
using University.AppLogic.Models;

namespace University.AppLogic.Repository
{
    public interface IClassroomRepository : IRepository<Classroom>
    {
        IEnumerable<Classroom> GetUserClasses(string UserID);
        Classroom GetByID(string Id);
        Classroom GetByClassCode(string ClassCode);
        Boolean Exist(string ClassroomCode);
    }
    
}
