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

            if (CacheManager.StudentIdentityMap.LookupStudentByGroup(groupId) == false)
            {
                List<StudentModel> tempList = new StudentProcessor(GlobalConfig.SqlRepository).GetStudents_ByGroup(groupId);

                foreach (var student in tempList)
                {
                    CacheManager.StudentCache.Add(student);
                }
            }

            studentViewModel.Students = CacheManager.StudentCache.Where(x => x.GroupId == groupId).ToList();

            studentViewModel.CurrentGroupName = groupName;
            studentViewModel.CurrentGroupId = groupId;

            return View(studentViewModel);
        }

        public IActionResult StudentEdit(int studentId, int groupId, string groupName)
        {
            StudentModel student = CacheManager.StudentCache.Where(x => x.StudentId == studentId).First();

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
                
                var suow = new StudentUnitOfWork(GlobalConfig.SqlRepository);
                suow.RegisterDirty(updatedStudent);
                suow.Commit();

                // Updating cache
                CacheManager.StudentCache.Where(x => x.StudentId == updatedStudent.StudentId).First().FirstName = updatedStudent.FirstName;
                CacheManager.StudentCache.Where(x => x.StudentId == updatedStudent.StudentId).First().LastName = updatedStudent.LastName;

                return RedirectToAction("StudentList", new { groupId = model.GroupId, groupName = model.GroupName });
            }

            return View(model);
        }
    }
}
