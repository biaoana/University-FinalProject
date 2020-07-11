using System;
using System.Collections.Generic;
using System.Text;
using University.AppLogic.Models;
using University.AppLogic.Repository;

namespace University.AppLogic.Services
{

    public class AssignmentsServices
    {
        private readonly IAssignmentsRepository assignmentsRepository;
        public AssignmentsServices(IAssignmentsRepository assignmentsRepository)
        {
            this.assignmentsRepository = assignmentsRepository;
        }
       public void AddAssignment(Classroom classroom, string link, DateTime dueto, string type, string description)
        {
            assignmentsRepository.Add(new Assignments() { Classroom = classroom, Link = link, DueTo = dueto, WorkPosted = DateTime.UtcNow, Type = type, Description = description });

        }
        public IEnumerable<Assignments> GetByClassroomId(string Id)
        {
            return assignmentsRepository.GetByClassroomID(Id);
        }
        public Assignments GetByID(string Id)
        {
            return assignmentsRepository.GetByID(Id);
        }
    }
}
