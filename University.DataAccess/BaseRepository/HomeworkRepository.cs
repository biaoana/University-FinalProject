using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using University.AppLogic.Models;
using University.AppLogic.Repository;

namespace University.DataAccess.BaseRepository
{
    public class HomeworkRepository : BaseRepository<Homework>, IHomeworkRepository
    {
        public HomeworkRepository(UniversityDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Homework> getByAssignmentId(string assignmentId)
        {
            return dbContext.Homeworks.Include(item => item.StudentId).Include(item => item.Assignment).Where(item => item.Assignment.AssignmentID == Guid.Parse(assignmentId)).ToList();
        }

        public Homework getById(string Id)
        {
            return dbContext.Homeworks.Include(item => item.Assignment).Include(item => item.Assignment).Where(item => item.Id == Guid.Parse(Id)).FirstOrDefault();
        }

        public Boolean getByUserAndAssignment(string User, string assignmentId)
        {
            var homework = dbContext.Homeworks.Include(item => item.StudentId).Include(item => item.Assignment).Where(item => item.StudentId.UserID == Guid.Parse(User) && item.Assignment.AssignmentID == Guid.Parse(assignmentId)).FirstOrDefault();
            if (homework != null)
                return true;
            return false;
        }


    }
}
