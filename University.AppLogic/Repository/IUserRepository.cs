using System;
using System.Collections.Generic;
using System.Text;
using University.AppLogic.Models;
using University.AppLogic.Repository;

namespace University.AppLogic.Repository
{
    public interface IUserRepository:IRepository<User>
    {
        IEnumerable<Classroom> GetAllByUser(string userID);
        User GetById(string Id);
    }
    
}
