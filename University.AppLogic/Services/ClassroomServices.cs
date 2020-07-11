using System;
using System.Collections.Generic;
using System.Text;
using University.AppLogic.Repository;
using University.AppLogic.Models;


namespace University.AppLogic.Services
{
    public class ClassroomServices
    {
        private readonly IClassroomRepository classroomRepository;
        public ClassroomServices(IClassroomRepository classroomRepository)
        {
            this.classroomRepository = classroomRepository;
        }

        public void AddClassroom(string UserID, string Name, string ClassCode)
        {
            Guid ID = Guid.Empty;
            if (Guid.TryParse(UserID, out ID) == true)
            {
                classroomRepository.Add(new Classroom() { ClassroomID = Guid.NewGuid(), UserID = ID, Name = Name, ClassCode = ClassCode });
            }
            else
            {
                throw new Exception("Invalid Guid Format");
            }
        }
       public Boolean ExistingClass(string ClassCode)
        {
            return classroomRepository.Exist(ClassCode);
           
        }
        public IEnumerable<Classroom> GetAllByID(string UserID)
        {
            return classroomRepository.GetUserClasses(UserID);
        }
        public Classroom GetByID(string Id)
        {
            return classroomRepository.GetByID(Id);
        }
        public Classroom GetByClassCode(string ClassCode)
        {
            return classroomRepository.GetByClassCode(ClassCode);
        }
    }
}
