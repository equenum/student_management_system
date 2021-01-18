using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Website.ViewModels;
using StudentManagementSystemLibrary;
using StudentManagementSystemLibrary.ModelProcessors;
using StudentManagementSystemLibrary.Models;
using StudentManagementSystemLibrary.UnitOfWorkServices;
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

            if (UOWManager.StudentUOW.LookupStudentsByGroup(groupId) == false)
            {
                if (UOWManager.StudentUOW.TryRegisterStudentsByGroup(groupId) == false)
                {
                    Response.StatusCode = 404;
                    return View("NotFound");
                }
            }

            studentViewModel.Students = UOWManager.StudentUOW.GetStudentsByGroup(groupId);
            studentViewModel.CurrentGroupName = groupName;
            studentViewModel.CurrentGroupId = groupId;

            return View(studentViewModel);
        }

        public IActionResult StudentEdit(int studentId, int groupId, string groupName)
        {
            StudentModel student = UOWManager.StudentUOW.GetStudentById(studentId);

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
            if (ModelState.IsValid)
            {
                var updatedStudent = new StudentModel() 
                { 
                    StudentId = model.StudentId, 
                    FirstName = model.FirstName, 
                    LastName = model.LastName, 
                    GroupId = model.GroupId 
                };

                UOWManager.StudentUOW.RegisterDirty(updatedStudent);
                UOWManager.StudentUOW.Commit();

                return RedirectToAction("StudentList", new { groupId = model.GroupId, groupName = model.GroupName });
            }

            return View(model);
        }
    }
}
