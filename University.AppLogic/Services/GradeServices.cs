using System;
using System.Collections.Generic;
using System.Text;
using University.AppLogic.Models;
using University.AppLogic.Repository;

namespace University.AppLogic.Services
{
    public class GradeServices
    {
        private readonly IGradeRepository gradeRepository;
        public GradeServices(IGradeRepository gradeRepository)
        {
            this.gradeRepository = gradeRepository;
        }
        public void Add(Homework homework, User student, float mark)
        {
            var item = gradeRepository.getByUserIdAndAssignmentId(student.UserID.ToString(), homework.Assignment.AssignmentID.ToString());
            if (item == null)
            {
                gradeRepository.Add(new Grades() { Id = Guid.NewGuid(), StudentId = student, Homework = homework, Mark = mark });
            }
            else
            {
                item.Mark = mark;
                gradeRepository.Update(item);
            }

        }
        public IEnumerable<Grades> getByAssignmentId(string id)
        {
            return gradeRepository.getByAssignmentId(id);
        }
        public Grades getByUserAndAssignment(string Userid, string AssignmentId)
        {
            return gradeRepository.getByUserIdAndAssignmentId(Userid, AssignmentId);
        }
    }
}
