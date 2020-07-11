using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using University.AppLogic.Models;
using University.AppLogic.Repository;

namespace University.DataAccess.BaseRepository
{
    public class ClassroomRepository: BaseRepository<Classroom>, IClassroomRepository
    {
        public ClassroomRepository(UniversityDbContext dbContext): base(dbContext)
        {
        }

        public bool Exist(string ClassroomCode)
        {
            var item = dbContext.Classroom.Where(classroom => classroom.ClassCode == ClassroomCode).FirstOrDefault();
            if(item != null)
            {
                return true;
            }
            return false;
        }

        public Classroom GetByClassCode(string ClassCode)
        {
            return dbContext.Classroom.Where(classroom => classroom.ClassCode == ClassCode).FirstOrDefault();
        }

        public Classroom GetByID(string Id)
        {
            return dbContext.Classroom.Where(classroom => classroom.ClassroomID == Guid.Parse(Id)).FirstOrDefault();
        }

        public IEnumerable<Classroom> GetUserClasses(string UserID)
        {
            return dbContext.Classroom.Where(item => item.UserID == Guid.Parse(UserID)).ToList();
        }
    }
}
