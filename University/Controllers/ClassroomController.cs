using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using University.AppLogic.Services;
using University.ViewModel;

namespace University.Controllers
{
        [Authorize(Roles = "Teacher")]
        public class ClassroomController : Controller
    {
        private readonly ClassroomServices classroomServices;
        private readonly UserManager<IdentityUser> userManager;

        public ClassroomController(ClassroomServices classroomServices, UserManager<IdentityUser> userManager)
        {
            this.classroomServices = classroomServices;
            this.userManager = userManager;
        }
        public IActionResult CreateClassroom()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateClassroom(ClassroomViewModel Model)
        {
            classroomServices.AddClassroom(userManager.GetUserId(User), Model.Name, Model.ClassCode);
            return RedirectToAction("Index", "Home");
        }

    }
  
}