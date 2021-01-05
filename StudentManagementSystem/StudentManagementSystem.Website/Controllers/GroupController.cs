using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Website.ViewModels;
using StudentManagementSystemLibrary;
using StudentManagementSystemLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Website.Controllers
{
    public class GroupController : Controller
    {
        public IActionResult GroupList(int courseId, string courseName)
        {

            var groupViewModel = new GroupViewModel();
            groupViewModel.Groups = GlobalConfig.Repository.GetGroups_ByCourse(courseId);
            groupViewModel.CurrentCourse = courseName;

            foreach (var group in groupViewModel.Groups)
            {
                group.Students = GlobalConfig.Repository.GetStudents_ByGroup(group.GroupId);
            }

            return View(groupViewModel);
        }
    }
}
