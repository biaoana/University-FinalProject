using System;
using System.Collections.Generic;
using System.Text;
using University.AppLogic.Models;
using University.AppLogic.Repository;

namespace University.AppLogic.Services
{
    public class HomeworkServices
    {
        private readonly IHomeworkRepository homeworkRepository;
        public HomeworkServices(IHomeworkRepository homeworkRepository)
        {
            this.homeworkRepository = homeworkRepository;
        }
        public Homework Add(Assignments assignment, User student, string link)
        {
            return homeworkRepository.Add(new Homework() { Id = Guid.NewGuid(), Assignment = assignment, StudentId = student, Link = link, Status = true });
        }
        public IEnumerable<Homework> getByAssignmentId(string assignmentId)
        {
            return homeworkRepository.getByAssignmentId(assignmentId);
        }
        public Boolean getbyUserAndAssignment(string User, string assignmentId)
        {
            return homeworkRepository.getByUserAndAssignment(User, assignmentId);
        }
        public Homework getById(string Id)
        {
            return homeworkRepository.getById(Id);
        }
    }
}
