using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.ViewModel;
using Microsoft.AspNetCore.Mvc;
using University.AppLogic.Services;
using University.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace University.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly AssignmentsServices assignmentsServices;
        private readonly ClassroomServices classroomServices;
        private readonly HomeworkServices homeworkServices;
        private readonly GradeServices gradeServices;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public AssignmentController(AssignmentsServices assignmentsServices,ClassroomServices classroomServices,HomeworkServices homeworkServices , GradeServices gradeServices, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.assignmentsServices = assignmentsServices;
            this.classroomServices = classroomServices;
            this.homeworkServices = homeworkServices;
            this.gradeServices = gradeServices;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index(string Id)
        {
            var assignment = assignmentsServices.GetByClassroomId(Id);
            var clasroom = classroomServices.GetByID(Id);
            var viewModel = new AssignmentViewModel()
            {
                Classroom = clasroom,
                Assignments = assignment,
                DueTo = DateTime.UtcNow
            };
            return View(viewModel);
        }
        [HttpPost]
       public IActionResult Index(AssignmentViewModel model)
        {
            var classroom = classroomServices.GetByID(model.Classroom.ClassroomID.ToString());
            if(model.Type=="course")
            {
                string type = model.Type;
                assignmentsServices.AddAssignment(classroom, model.Link, default(DateTime), type,  model.Description);
            }
            else
                if(model.Type=="assignment")
            {
                string type = model.Type;
                assignmentsServices.AddAssignment(classroom, model.Link, model.DueTo, type, model.Description);

            }
            else
            {
                string type = "announcment";
                assignmentsServices.AddAssignment(classroom, null, default(DateTime), type, model.Description);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Assignment(string Id)
        {
            var user = userManager.GetUserAsync(User).GetAwaiter().GetResult();
            var role = userManager.GetRolesAsync(user).GetAwaiter().GetResult();
            
            if (role[0] == "Teacher")
            {
                var homework = homeworkServices.getByAssignmentId(Id);
                var grade = gradeServices.getByAssignmentId(Id);
                var assignment = assignmentsServices.GetByID(Id);
                var viewModel = new AssignmentViewModel()
                {
                    Grades = grade,
                    Homeworks = homework,
                    Link=assignment.Link,
                    Type=assignment.Type
                    
                };
                return View(viewModel);
            }
            else
                if (role[0] == "Student")
            {
                float grade = 0;
                var assignment = assignmentsServices.GetByID(Id);
                var homework = homeworkServices.getbyUserAndAssignment(userManager.GetUserId(User), assignment.AssignmentID.ToString());
                if(homework == true)
                {
                    var mark = gradeServices.getByUserAndAssignment(userManager.GetUserId(User), Id);
                    if(mark != null)
                    {
                        grade = mark.Mark;
                    }

                }
                var viewModel = new AssignmentViewModel()
                {
                    Id = Guid.Parse(Id),
                    DueTo = assignment.DueTo,
                    Link = assignment.Link,
                    Description = assignment.Description,
                    Type = assignment.Type,
                    Status = homework,
                    Mark = grade



                };

                return View(viewModel);
            }
            return View();
        }


    }
   

}