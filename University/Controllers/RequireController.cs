using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using University.AppLogic.Services;
using University.ViewModel;

namespace University.Controllers
{
    public class RequireController : Controller
    {
        private readonly ClassroomServices classroomServices;
        private readonly UserServices userServices;
        private readonly RequireServices requireServices;
        private readonly UserManager<IdentityUser> userManager;
        
        public RequireController(ClassroomServices classroomServices, UserServices userServices, RequireServices requireServices, UserManager<IdentityUser> userManager)
        {
            this.classroomServices = classroomServices;
            this.userServices = userServices;
            this.requireServices = requireServices;
            this.userManager = userManager;
        }
        public IActionResult Require()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Require(MultipleModels models)
        {
            var classroom = classroomServices.GetByClassCode(models.Classroom.ClassCode);
            var student = userServices.GetById(userManager.GetUserId(User));
            requireServices.AddRequest(classroom, student);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Accept(string Id)
        {
            requireServices.Update(Id);
            return RedirectToAction("Index", "Home");
        }
    }
}