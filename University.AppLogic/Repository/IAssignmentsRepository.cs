using System;
using System.Collections.Generic;
using System.Text;
using University.AppLogic.Models;

namespace University.AppLogic.Repository
{
    public interface IAssignmentsRepository: IRepository<Assignments>
    {
        IEnumerable<Assignments> GetByClassroomID(string Id);
        Assignments GetByID(string Id);

    }
}
