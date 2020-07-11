using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using University.AppLogic.Models;
using University.AppLogic.Repository;

namespace University.DataAccess.BaseRepository
{
    public class RequireRepository: BaseRepository<Require>, IRequireRepository
    {
        public RequireRepository(UniversityDbContext dbContext): base (dbContext)
        {

        }

        public IEnumerable<Require> AcceptedRequest(string userId)
        {
            return dbContext.Requires.Include(item => item.StudentId).Include(item => item.ClassroomId).Where(item => item.StudentId.UserID == Guid.Parse(userId) && item.Status == true).ToList();
        }

        public Require GetByID(string Id)
        {
            return dbContext.Requires.Where(item => item.RequireID == Guid.Parse(Id)).FirstOrDefault();
        }
        
    }
}
