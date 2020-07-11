using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using University.AppLogic.Models;
using University.AppLogic.Repository;

namespace University.DataAccess.BaseRepository
{
    public class AssignmentsRepository: BaseRepository<Assignments>, IAssignmentsRepository
    {
        public AssignmentsRepository(UniversityDbContext dbContext) : base(dbContext)
        {
        }
        public IEnumerable<Assignments> GetByClassroomID(string Id)
        {
            return dbContext.Assignments.Include(classroom => classroom.Classroom).Where(item => item.Classroom.ClassroomID == Guid.Parse(Id)).ToList();
        }

        public Assignments GetByID(string Id)
        {
            return dbContext.Assignments.Where(item => item.AssignmentID == Guid.Parse(Id)).FirstOrDefault();
        }
    }
}
