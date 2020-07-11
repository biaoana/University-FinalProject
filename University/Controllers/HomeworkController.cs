using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using University.AppLogic.Services;
using University.ViewModel;

namespace University.Controllers
{
    public class HomeworkController : Controller
    {
        private readonly HomeworkServices homeworkServices;
        private readonly AssignmentsServices assignmentServices;
        private readonly UserServices userServices;
        private readonly UserManager<IdentityUser> userManager;

        public HomeworkController(HomeworkServices homeworkServices, AssignmentsServices assignmentService, UserServices userServices, UserManager<IdentityUser> userManager)
        {
            this.homeworkServices = homeworkServices;
            this.assignmentServices = assignmentService;
            this.userServices = userServices;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Index(AssignmentViewModel model)
        {
            var assignment = assignmentServices.GetByID(model.Id.ToString());
            var user = userServices.GetById(userManager.GetUserId(User));
            homeworkServices.Add(assignment, user, model.HomeworkLink);
            return RedirectToAction("Assignment", "Assignment", new { id = model.Id });
        }
    }
}