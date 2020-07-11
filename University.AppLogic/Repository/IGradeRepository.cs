using System;
using System.Collections.Generic;
using System.Text;
using University.AppLogic.Models;

namespace University.AppLogic.Repository
{
    public interface IGradeRepository : IRepository<Grades>
    {
        IEnumerable<Grades> getByAssignmentId(string id);
        Grades getByUserIdAndAssignmentId(string UserId, string assignmentId);
    }
}
