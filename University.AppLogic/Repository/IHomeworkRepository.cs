using System;
using System.Collections.Generic;
using System.Text;
using University.AppLogic.Models;

namespace University.AppLogic.Repository
{
    public interface IHomeworkRepository : IRepository<Homework>
    {
        IEnumerable<Homework> getByAssignmentId(string assignmentId);
        Boolean getByUserAndAssignment(string User, string assignmentId);
        Homework getById(string Id);
    }
}
