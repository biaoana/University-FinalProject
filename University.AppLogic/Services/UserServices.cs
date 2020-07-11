using System;
using System.Collections.Generic;
using System.Text;
using University.AppLogic.Models;
using University.AppLogic.Repository;

namespace University.AppLogic.Services
{
    public class UserServices
    {
        private readonly IUserRepository userRepository;
        public UserServices(IUserRepository user)
        {
            this.userRepository = user;
        }
       
        public User Add(string userId,string Name,string surname,string phoneNr)
        {
            return userRepository.Add(new User { UserID=Guid.Parse(userId), Name = Name, Surname = surname,PhoneNr =phoneNr});
        }
        public User GetById(string Id)
        {
            return userRepository.GetById(Id);
        }
    }
}
