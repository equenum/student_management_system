using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentManagementSystem.Website.Models;
using StudentManagementSystem.Website.ViewModels;
using StudentManagementSystemLibrary;
using StudentManagementSystemLibrary.ModelProcessors;
using StudentManagementSystemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Website.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel();

            if(UOWManager.CourseUOW.LookupCourses() == false)
            {
                if (UOWManager.CourseUOW.TryRegisterCoursesAll() == false)
                {
                    Response.StatusCode = 404;
                    return View("NotFound");
                }
            }

            homeViewModel.Courses = UOWManager.CourseUOW.GetCoursesAll();

            return View(homeViewModel);
        }
    }
}
