using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Website.ViewModels;
using StudentManagementSystemLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Website.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult StudentList(int groupId, string groupName)
        {
            var studentViewModel = new StudentViewModel();
            studentViewModel.Students = GlobalConfig.Repository.GetStudents_ByGroup(groupId);
            studentViewModel.CurrentGroup = groupName;

            return View(studentViewModel);
        }
    }
}
