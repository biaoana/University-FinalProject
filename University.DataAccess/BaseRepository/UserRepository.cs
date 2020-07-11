using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using University.AppLogic.Models;
using University.AppLogic.Repository;
using University.DataAccess;
using University.DataAccess.BaseRepository;

namespace University.DataAcces.BaseRepository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(UniversityDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Classroom> GetAllByUser(string userID)
        {
            throw new NotImplementedException();
        }

        public User GetById(string Id)
        {
            return dbContext.Users.Where(users => users.UserID == Guid.Parse(Id)).FirstOrDefault();
        }
    }
}
