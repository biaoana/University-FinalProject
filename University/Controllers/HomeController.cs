using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using University.AppLogic.Models;
using University.AppLogic.Services;
using University.Models;
using University.ViewModel;

namespace University.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ClassroomServices classroomServices;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RequireServices requireServices;
        private readonly UserServices userServices;

        public HomeController(ILogger<HomeController> logger, ClassroomServices classroomServices, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RequireServices requireServices, UserServices userServices)
        {
            this.requireServices = requireServices;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.classroomServices = classroomServices;
            this.userServices = userServices;
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (signInManager.IsSignedIn(User))
            {

                var user = userManager.GetUserAsync(User).GetAwaiter().GetResult();
                var role = userManager.GetRolesAsync(user).GetAwaiter().GetResult();
                if (role[0] == "Teacher")
                {
                    var list = classroomServices.GetAllByID(userManager.GetUserId(User));
                    var student = userServices.GetById(userManager.GetUserId(User));
                    var requireList = requireServices.GetAll();
                    var viewModel = new MultipleModels()
                    {
                        classrooms = list,
                        requires = requireList,
                        Student = student
                    };

                    return View(viewModel);



                }
                else
                if (role[0] == "Student")
                {
                    var requireList = requireServices.GetAcceptedRequests(userManager.GetUserId(User));
                    var viewModel = new MultipleModels()
                    {

                        requires = requireList,

                    };

                    return View(viewModel);

                }
            }

            else
            {
                return View();
            }
            return View();
        }
       

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
