using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Website.ViewModels;
using StudentManagementSystemLibrary;
using StudentManagementSystemLibrary.ModelProcessors;
using StudentManagementSystemLibrary.Models;
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
            studentViewModel.Students = new GroupProcessor(GlobalConfig.SqlRepository).GetStudents_ByGroup(groupId);

            studentViewModel.CurrentGroupName = groupName;
            studentViewModel.CurrentGroupId = groupId;

            return View(studentViewModel);
        }

        public IActionResult StudentEdit(int studentId, int groupId, string groupName)
        {
            StudentModel student = new StudentProcessor(GlobalConfig.SqlRepository).GetStudent_ById(studentId);
            
            var studentEditViewModel = new StudentEditViewModel();
            studentEditViewModel.StudentId = student.StudentId;
            studentEditViewModel.FirstName = student.FirstName;
            studentEditViewModel.LastName = student.LastName;
            studentEditViewModel.GroupId = groupId;
            studentEditViewModel.GroupName = groupName;

            return View(studentEditViewModel);
        }

        [HttpPost]
        public IActionResult StudentEdit(StudentEditViewModel model)
        {
            new StudentProcessor(GlobalConfig.SqlRepository).UpdateStudentName(model.StudentId, model.FirstName, model.LastName);

            return RedirectToAction("StudentList", new { groupId = model.GroupId, groupName = model.GroupName });
        }
    }
}
