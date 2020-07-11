using System;
using System.Collections.Generic;
using System.Text;
using University.AppLogic.Models;
using University.AppLogic.Repository;

namespace University.AppLogic.Services
{
    public class RequireServices
    {
        private readonly IRequireRepository requireRepository;
        public RequireServices(IRequireRepository requireRepository)
        {
            this.requireRepository = requireRepository;
        }
        public void AddRequest(Classroom ClassroomID, User StudentID)

        {
            requireRepository.Add(new Require() { ClassroomId = ClassroomID, StudentId = StudentID, Status = false, RequireID = Guid.NewGuid()});
        }
        public IEnumerable<Require> GetAll()
        {
            return requireRepository.GetAll();
        }
        public Require GetByID(string Id)
        {
            return requireRepository.GetByID(Id);
        }
        public void Update(string Id)
        {
            var request = requireRepository.GetByID(Id);
            request.Status = true;
            requireRepository.Update(request);
        }
        public IEnumerable<Require> GetAcceptedRequests(string userId)
        {
            return requireRepository.AcceptedRequest(userId);
        }
    }
}
