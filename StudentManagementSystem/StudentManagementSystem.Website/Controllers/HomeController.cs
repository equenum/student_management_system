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

            if (CacheManager.CourseIdentityMap.IsNotEmpty() == false)
            {
                List<CourseModel> tempList = new CourseProcessor(GlobalConfig.SqlRepository).GetCourses_All();

                foreach (var course in tempList)
                {
                    CacheManager.CourseCache.Add(course);
                }
            }

            homeViewModel.Courses = CacheManager.CourseCache;

            return View(homeViewModel);
        }
    }
}
