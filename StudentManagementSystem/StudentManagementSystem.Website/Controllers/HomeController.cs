using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentManagementSystem.Website.Models;
using StudentManagementSystem.Website.ViewModels;
using StudentManagementSystemLibrary;
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
        //private IEnumerable<CourseModel> courses = GlobalConfig.Repository.GetCourses_All();

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel();
            homeViewModel.Courses = GlobalConfig.Repository.GetCourses_All();

            return View(homeViewModel);
        }
    }
}
