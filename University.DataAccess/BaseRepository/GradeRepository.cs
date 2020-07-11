using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using University.AppLogic.Models;
using University.AppLogic.Repository;

namespace University.DataAccess.BaseRepository
{
    public class GradeRepository : BaseRepository<Grades>, IGradeRepository
    {
        public GradeRepository(UniversityDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Grades> getByAssignmentId(string id)
        {
            return dbContext.Grades.Include(item => item.Homework).Include(item => item.StudentId).Where(item => item.Homework.Assignment.AssignmentID == Guid.Parse(id)).ToList();
        }


        public Grades getByUserIdAndAssignmentId(string UserId, string assignmentId)
        {
            return dbContext.Grades.Include(item => item.StudentId).Where(item => item.StudentId.UserID == Guid.Parse(UserId) && item.Homework.Assignment.AssignmentID == Guid.Parse(assignmentId)).FirstOrDefault();

        }
    }
}
